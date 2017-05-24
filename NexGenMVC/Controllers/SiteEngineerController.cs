using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexGenMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace NexGenMVC.Controllers
{
    public class SiteEngineerController : Controller
    {
        DefaultConnectionEntities _context = new DefaultConnectionEntities();

        // GET: SiteEngineer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Client()
        {
            
            var objClient = _context.Fn_GetClient(User.Identity.Name, 1).ToList();
            ViewData.Model = objClient;
            return View();

        }
        public ActionResult NewClient()
        {
            var ClientId = _context.Fn_GetClientId("", 2);
            //ViewData.Model = ClientId;
            return View(model:"");
        }
        [HttpPost]
        public ActionResult NewClient(Client objClient)
        {
            return View();
        }
    }
}