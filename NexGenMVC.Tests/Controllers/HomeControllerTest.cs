using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexGenMVC;
using NexGenMVC.Controllers;

namespace NexGenMVC.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
     /*   [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }*/
        [TestMethod]
        public void Login()
        {
            HomeController contoller = new HomeController();
            ViewResult result = contoller.Login() as ViewResult;
            Assert.IsNotNull(result);
        }

      [TestMethod]
      public void CheckDefaultCostHigher()
        {
            HomeController contoller = new HomeController();
            ViewResult result = contoller.Login() as ViewResult;
            Assert.AreNotEqual("View1", result.ViewName);
        }
       
    }
}
