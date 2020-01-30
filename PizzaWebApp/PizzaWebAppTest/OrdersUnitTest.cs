using PizzaWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaWebAppTest
{
    [TestClass]
    public class OrdersUnitTest
    {
        [TestMethod]
        public void OrderTestMethod()
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
