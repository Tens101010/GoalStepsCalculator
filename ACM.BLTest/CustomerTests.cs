using System;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValid()
        {
            // -- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "2000";
            decimal expected = 40M;

            // -- Actual
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidAndSame()
        {
            // -- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "5000";
            decimal expected = 100M;

            // -- Actual
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalStepsTestValidActualIsZero()
        {
            // -- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "0";
            decimal expected = 0M;

            // -- Actual
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // -- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        // Testing the exception thrown
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTestGoalIsNull()
        {
            // -- Arrange
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";

            // -- Actual
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // -- Assert
        }

        [TestMethod]
        // Testing the exception thrown
        [ExpectedException(typeof(ArgumentException))]
        public void CalculatePercentOfGoalStepsTestGoalIsNotNumeric()
        {
            // -- Arrange
            var customer = new Customer();
            string goalSteps = "one";
            string actualSteps = "2000";

            // -- Actual
            try
            {
                var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Goal must be numeric", ex.Message);
                throw;
            }
            // -- Assert
        }
    }
}