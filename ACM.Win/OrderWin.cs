using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACM.BL;
using Core.Common;

namespace ACM.Win

#region Defensive Coding Notes
/*
 * Its often difficult (or rather time consuming) to test an application on the fly
 * going through the entire process over and over to launch app, test, repeat, etc.
 * This project shows how to get around this by using class libraries and Tests
 * 
 * We start with the project AcmeCustomerManagement
 * We have a Windows Form project (namespace)
 * and a Business Logic project (namespace)
 * 
 * In the BL libraries, we have the classes
 * Property classes and their respective repository classes
 * Property classes (entity classes) - {get ; set }
 *      Entity information about the class: First Name, Last Name, etc.
 * Repository classes (handle the data access for the application) - manipulates the { get ; set }
 *      Retreives and saves customers
 *      
 * We add another project (namespace), Core.Common, to hold all the system functional code: email, saving, etc. 
 * When using other projects (namespaces), be sure to add the reference to that project
 * As well as ensuring the "using namespace;" is added to the using list
 * 
 * Going through all the necessary functions of the project
 * Can add the functions before they are actually created, sort of a quick build tool
 * VS intuitively knows/suggests that you should create the function and suggests where to have it added
 *   var emailLibrary = new EmailLibrary();
 *   emailLibrary.SendEmail(customer.EmailAddress, "Here is your receipt");
 *       VS will suggest to create a new "SendEmail" function in the EmailLibrary class
 *       With the parameters of 2 strings, as:
 *           public void SendEmail(string emailAddress, string hereIsYourReceipt)
 * 
 * Using the extraction tool to extract code blocks to create functions
 * Refactoring, etc.
 * 
 * Guard Clauses: Keeping garbage out.  Ensures valid arguements are sent as parameters
 * Added a new Windows Form, PedometerWin
 * Setting up some defensive coding and taken out some possible crash errors
 * Setting up "Try" scenarios and leaving them commented out as reference (customer.cs)
 * Error #1 - Cannot divide by 0 exception
 * Error #2 and 3 - Cannot have a null/blank value in either slot
 * 
 * Fail Fast Technique:
 * Using if statements to verify data or pass an exception dialog box to notify user of error
 * Using overloading as an alternate method of passing/validating information
 * 
 * Automated code testing:
 * Creating Unit Tests to run faster, automatic testing to verify data integrety
 * Testing folder created and new test project, ACM.BLTest
 * Created various unit tests to test possible scenarios
 * Installed extension for easier construction of unit tests
 *      Right-Click on a method and select "Generate Unit Test"
 * Code Snippet Note when using Resharper: testm + CNTL,J (or turn off R# intellisence override of VS commands)
 *      testm is a code snippet to generate a [Test Method] template
 * Running tests for exceptions thrown
 * 
 * Working with ValidateEmail();
 * Multiple passes trying to get it right
 * Experimenting with (ref foo), (out foo), and Tuple<bool,string>
 * None of these quite right, created a new class, OperationResult in Core.Common
 * 
 * Working with enum
 * best practice: enum's belong in the namespace area and not embedding in a class
 * This makes it accessible to any other class
 * 
 * Working with Casting: Altering button object performance 
 * When button1 is pressed, it can display "when pressed" text
 * Always include an if statement when casting with "as"
 * 
 * Running more tests with placing orders
 * 
 * Invariants and Assertions
 * Adding assertions to PlaceHolder() to throw debugging exceptions if not true
 * Adding Global exception handlers in Program.cs
 * Dont let global exceptions handle expected exceptions
 * for expected throwns exceptions that we put in the code (see OrderController.cs, ArgumentNullException),
 *      use try/catch blocks around the referenced code
 * 
 * More topics to look up for study:
 *      Multiple Catch Blocks
 *      Finally Clause
 *      Custom Exceptions
 */
#endregion

{
    public partial class OrderWin : Form
    {
        public OrderWin()
        {
            InitializeComponent();
            // to launch Pedometer window
            //Application.Run(new PedometerWin());
        }



        /// <summary>
        /// Windows form button press
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //Casting text onto the button once it is clicked
            //Need to cast the sender object to a button object
            //Using the "as" identifier to give sender a button alter ego
            //Useful when asking the sender object to act as a button
            //If it can't for w/e reason, program wont crash, just return null on the request
            Button button = sender as Button;
            if (button != null)
            {
                button.Text = "Processing...";
            }


            PlaceOrder();
        }

        private void PlaceOrder()
        {
            var customer = new Customer();
            // Populate the customer instance

            var order = new Order();
            // Populate the order instance

            var payment = new Payment();
            // Populate the payment info from the UI

            try
            {
                var orderController = new OrderController();
                var op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: false, emailReceipt: true);
            }
            catch (ArgumentNullException)
            {
                // dispaly a message to the user that the order was not successful
            }

        }
    }
}
