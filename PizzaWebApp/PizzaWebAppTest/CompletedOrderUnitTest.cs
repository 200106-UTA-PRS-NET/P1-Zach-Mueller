using PizzaWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaWebAppTest
{
    [TestClass]
    class CompletedOrderUnitTest
    {
        [TestMethod]
        public void CompletedOrderTestMethod()
        {
            //Arrange
            OrderController controller = new OrderController(new MockRepo());
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.Equals("Index", result.ViewName);
        }
    }
}
