using NexGenMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NexGenMVC.Controllers
{
    public class ManagerController : Controller
    {
        DefaultConnectionEntities _context = new DefaultConnectionEntities();

        public ManagerController() { }
        

        public ManagerController(DefaultConnectionEntities context)
        {
            _context = context;
        }
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Interventions()
        {
            var objIntervention = _context.Fn_GetProposedInterventions(User.Identity.Name).ToList();
            ViewBag.OtherInterventions = _context.Fn_GetInterventionForManager(User.Identity.Name).ToList();
            ViewData.Model = objIntervention;
            return View();
           

        }
        public ActionResult EditIntervention(string id)
        {
            var objInterventionForEdit = _context.Fn_GetInterventionForEdit(id).ToList();
            ViewData.Model = objInterventionForEdit;
            return View();
        }
        [HttpPost]
        public ActionResult EditIntervention(FormCollection frmEditIntervention)
        {
            try
            {
                _context.Fn_EditInterventionSE(frmEditIntervention["ddlStatus"], frmEditIntervention["txtInterventionId"],2,User.Identity.Name);
                var objIntervention = _context.Fn_GetProposedInterventions(User.Identity.Name).ToList();
                ViewBag.OtherInterventions = _context.Fn_GetInterventionForManager(User.Identity.Name).ToList();
                ViewData.Model = objIntervention;
                return View("Interventions");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}