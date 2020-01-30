using PizzaWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaWebAppTest
{
    [TestClass]
    class StoreUnitTest
    {
        [TestMethod]
        public void StoreTestMethod()
        {
            //Arrange
            StoreController controller = new StoreController(new MockRepo());
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.Equals("Index", result.ViewName);
        }
    }
}
