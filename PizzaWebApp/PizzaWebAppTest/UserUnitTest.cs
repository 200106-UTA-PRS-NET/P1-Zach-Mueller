using PizzaWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzaWebAppTest
{
    [TestClass]
    class UserUnitTest
    {
        [TestMethod]
        public void UserTestMethod()
        {
            //Arrange
            UserController controller = new UserController(new MockRepo());
            //Act
            var result = controller.Index() as ViewResult;
            //Assert
            Assert.Equals("Index", result.ViewName);
        }
    }
}
