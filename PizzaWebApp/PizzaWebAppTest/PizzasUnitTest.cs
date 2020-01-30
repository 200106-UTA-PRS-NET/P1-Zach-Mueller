using PizzaWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaWebAppTest
{
    [TestClass]
    public class PizzasUnitTest
    {
        [TestMethod]
        public void PizzaTestMethod()
        {
            //Arrange
            PizzaController controller = new PizzaController(new MockRepo());
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.Equals("Index", result.ViewName);
        }
    }
}
