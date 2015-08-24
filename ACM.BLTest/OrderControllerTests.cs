using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACM.BL;
using Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ACM.BLTests
{
    [TestClass]
    public class OrderControllerTests
    {
        [TestMethod]
        public void PlaceOrderTest()
        {
            // -- Arrange
            var orderController = new OrderController();
            var customer = new Customer() { EmailAddress = "someOne@gmail.com" };
            var order = new Order();
            var payment = new Payment() { PaymentType = 1 };

            // -- Actual
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true,
                emailReceipt: true);

            // -- Assertion
            Assert.AreEqual(true, op.Success);
            Assert.AreEqual(0, op.MessageList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderTestNullCustomer()
        {
            // -- Arrange
            var orderController = new OrderController();
            Customer customer = null;
            var order = new Order();
            var payment = new Payment() { PaymentType = 1 };

            // -- Actual
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true,
                emailReceipt: true);

            // -- Assertion
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderTestNullOrder()
        {
            // -- Arrange
            var orderController = new OrderController();
            var customer = new Customer() { EmailAddress = "someOne@gmail.com" };
            Order order = null;
            var payment = new Payment() { PaymentType = 1 };

            // -- Actual
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true,
                emailReceipt: true);

            // -- Assertion
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceOrderTestNullPayment()
        {
            // -- Arrange
            var orderController = new OrderController();
            var customer = new Customer() { EmailAddress = "someOne@gmail.com" };
            var order = new Order();
            Payment payment = null;

            // -- Actual
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true,
                emailReceipt: true);

            // -- Assertion
        }

        [TestMethod]
        public void PlaceOrderTestInvalidEmail()
        {
            // -- Arrange
            var orderController = new OrderController();
            var customer = new Customer() { EmailAddress = "" };
            var order = new Order();
            var payment = new Payment() { PaymentType = 1 };

            // -- Actual
            OperationResult op = orderController.PlaceOrder(customer, order, payment, allowSplitOrders: true,
                emailReceipt: true);

            // -- Assertion
            Assert.AreEqual(true, op.Success);
            Assert.AreEqual(1, op.MessageList.Count);
            Assert.AreEqual("Email address is null", op.MessageList[0]);
        }
    }
}
