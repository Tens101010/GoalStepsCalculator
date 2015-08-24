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
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Core.Common;

namespace ACM.BL
{
    /// <summary>
    /// Manages a single customer
    /// </summary>
    public class Customer
    {
        public int CustomerId { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Calculates the percent of the step goal reached.  Try blocks left intact
        /// </summary>
        public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        {
            #region Try blocks 1-5
            // Try 1 - doesn't account for 0, cannot divide by zero error
            //return (Convert.ToDecimal(actualSteps) / Convert.ToDecimal(goalSteps)) * 100;


            // Try 2 - doesn't account for null values/empty strings
            //decimal result = 0;
            //var goalStepCount = Convert.ToDecimal(goalSteps);
            //
            //if (goalStepCount > 0)
            //{
            //    result = (Convert.ToDecimal(actualSteps) / goalStepCount) * 100;
            //}
            //return result;


            // Try 3 - adding TryParse technique, this still doesn't account for ALL null values 
            //decimal result = 0;
            //decimal goalStepCount = 0;
            //decimal.TryParse(goalSteps, out goalStepCount);

            //if (goalStepCount > 0)
            //{
            //    result = (Convert.ToDecimal(actualSteps) / goalStepCount) * 100;
            //}
            //return result;


            // Try 4 - This one functions properly in that it results in no thrown exceptions
            // However, we can make this better by letting the user know if they did something wrong
            //decimal result = 0;

            //decimal goalStepCount = 0;
            //decimal.TryParse(goalSteps, out goalStepCount);

            //decimal actualStepCount = 0;
            //decimal.TryParse(actualSteps, out actualStepCount);

            //if (goalStepCount > 0)
            //{
            //    result = (actualStepCount / goalStepCount) * 100;
            //}
            //return result;


            // Try 5 - Adding "Fail Fast" technique
            // This one works, looks nicer, and is readable to know what each line does
            // If a user doesn't enter info as expected, a warning box displays
            // But this is still a lot of code for one calculation
            //decimal goalStepCount = 0;
            //decimal actualStepCount = 0;

            //if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentException("Goal must be entered", "goalSteps");
            //if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentException("Actual steps must be entered", "actualSteps");

            //if (!decimal.TryParse(goalSteps, out goalStepCount)) throw new ArgumentException("Goal must be numeric", "goalSteps");
            //if (!decimal.TryParse(actualSteps, out actualStepCount)) throw new ArgumentException("Actual steps must be numeric", "actualSteps");

            //if (goalStepCount <= 0) throw new ArgumentException("Goal must be greater than 0", "goalSteps");

            //return (actualStepCount / goalStepCount) * 100;
            #endregion
            // Try 6 - Creating an "Overload" in the CalculatePercentOfGoalSteps();
            // now this method has 2 overloads, one for string input and one for decimal

            decimal goalStepCount = 0;
            if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentException("Goal must be entered", "goalSteps");
            if (!decimal.TryParse(goalSteps, out goalStepCount)) throw new ArgumentException("Goal must be numeric");

            decimal actualStepCount = 0;
            if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentException("Actual steps must be entered", "actualSteps");
            if (!decimal.TryParse(actualSteps, out actualStepCount)) throw new ArgumentException("Actual steps must be numeric", "actualSteps");

            return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
        }

        // Overloaded method to allow for decimal input
        public decimal CalculatePercentOfGoalSteps(decimal goalStepCount, decimal actualStepCount)
        {
            if (goalStepCount <= 0) throw new ArgumentException("Goal must be greater than 0", "goalSteps");

            // Math.Round(interger, # of decimal spaces) that will keep the result to 2 decimal places
            return Math.Round((actualStepCount / goalStepCount) * 100, 2);
        }

        public OperationResult ValidateEmail()
        {
            #region Original code: Multiple reconstructing passes done
            //-- Send an email receipt
            //If the user requested a receipt
            //Get the customer data
            //Ensure a valid email address was provided
            //If not, request an email address from the user

            // --1st pass:
            //public boolean ValidateEmail()
            //var valid = true;
            //if (string.IsNullOrWhiteSpace(this.EmailAddress))
            //{
            //    valid = false;
            //}

            //var isValidFormat = true;
            //// Code here that validates the format of the email using regular expressions
            //if (!isValidFormat)
            //{
            //    valid = false;
            //}

            //var isRealDomain = true;
            //// Code here that confirms whether domain exists
            //if (!isRealDomain)
            //{
            //    valid = false;
            //}

            //return valid;

            // --2nd Pass:
            //public void ValidateEmail()
            //if (string.IsNullOrWhiteSpace(this.EmailAddress)) throw  new ArgumentException("Email address is null");

            //var isValidFormat = true;
            //// Code here that validates the format of the email using regular expressions
            //if (!isValidFormat) throw new ArgumentException("Email address is not in a correct format");

            //var isRealDomain = true;
            //// Code here that confirms whether domain exists
            //if (!isRealDomain) throw new ArgumentException("Email address does not include a valid domain");

            // 3rd Pass
            //public Tuple<bool, string> ValidateEmail()
            //Tuple<bool, string> result = Tuple.Create(true, "");

            //if (string.IsNullOrWhiteSpace(this.EmailAddress))
            //{
            //    result = Tuple.Create(false, "Email address is null");
            //}

            //if (result.Item1 == true)
            //{
            //    // Code here that validates the format of the email using regular expressions
            //    var isValidFormat = true;

            //    if (!isValidFormat)
            //    {
            //        result = Tuple.Create(false, "Email address is not in a correct format");
            //    }
            //}

            //if (result.Item1 == true)
            //{
            //    var isRealDomain = true;
            //    // Code here that confirms whether domain exists
            //    if (!isRealDomain)
            //    {
            //        result = Tuple.Create(false, "Email address does not include a valid domain");
            //    }
            //}

            //return result;
            #endregion
            // 4th Pass (new Operation Result Class in Core.Common)

            var op = new OperationResult();

            if (string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                op.Success = false;
                op.AddMessage("Email address is null");
            }

            if (op.Success)
            {
                // Code here that validates the format of the email using regular expressions
                var isValidFormat = true;

                if (!isValidFormat)
                {
                    op.Success = false;
                    op.AddMessage("Email address is not in a correct format");
                }
            }

            if (op.Success)
            {
                var isRealDomain = true;
                // Code here that confirms whether domain exists
                if (!isRealDomain)
                {
                    op.Success = false;
                    op.AddMessage("Email address does not include a valid domain");
                }
            }

            return op;
        }
    }
}
