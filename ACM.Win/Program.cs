//Please note: This application is purely for my own education, to run through coding 
//examples by following tutorials, and to just tinker around with coding.  
//I know it’s bad practice to heavily comment code (code smell), but comments in all of my 
//exercises will largely be left intact as this serves me 2 purposes:
//    I want to retain what my original thought process was at the time
//    I want to be able to look back in 1..5..10 years to see how far I’ve come
//    And I enjoy commenting on things, however redundant this may be . . . 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACM.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // For UI thread exceptions
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);

            // Force all Windows Forms errors to go through the handler
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // For Non-UI thread exceptions
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new OrderWin());
            Application.Run(new PedometerWin());
        }

        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            // Log the issue here (psuedo code)
            MessageBox.Show("There was a problem with this application. Please contact support");
            System.Windows.Forms.Application.Exit();
        }
    }
}
