using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NexGenMVC;
using NexGenMVC.Controllers;
using Moq;
using NexGenMVC.Models;
using System.Data.Entity.Core.Objects;

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
        public void Should_have_empty_page_when_creating_new_client()
        {
            var mockObject = new Mock<DefaultConnectionEntities>();
            mockObject.Setup(cc => cc.Fn_GetClientId(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new TestableObjectResult());

            var c = new SiteEngineerController(mockObject.Object);
            var result =(ViewResult) c.NewClient();
           // Assert.IsNotNull(result.Model);
            Assert.AreEqual("", result.Model as string);
        }
        [TestMethod]
        public void Should_have_empty_page_when_creating_new_intervention()
        {
            var mockObject = new Mock<DefaultConnectionEntities>();
            mockObject.Setup(cc => cc.Fn_GetInterventionId()).Returns(new TestableObjectResult()) ;
            var objSE = new SiteEngineerController(mockObject.Object);
           // objSE.
            var result = objSE.NewInterventionIDGenerate();
            Assert.AreEqual("", result as string);
        }
        [TestMethod]
        public void Check_For_Default_Cost()
        {

        }
        [TestMethod]
        public void CheckDefaultCostHigher()
        {
            HomeController contoller = new HomeController();
            ViewResult result = contoller.Login() as ViewResult;
            Assert.AreNotEqual("View1", result.ViewName);
        }

    }

    public class TestableObjectResult : ObjectResult<string>
        {
        }
}
