using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NexGenMVC.Models;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;


namespace NexGenMVC.Controllers
{
    public class SiteEngineerController : Controller
    {
        DefaultConnectionEntities _context = new DefaultConnectionEntities();

        public SiteEngineerController() { }

        public SiteEngineerController(DefaultConnectionEntities context)
        {
            _context = context;
        }

        // GET: SiteEngineer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Client()
        {
            
            var objClient = _context.Fn_GetClient(User.Identity.Name, 1,"","","").ToList();
            ViewData.Model = objClient;
            return View();

        }
        public ActionResult Audit()
        {
            var objAudit = _context.Fn_GetAuditIntervention(User.Identity.Name);
            ViewData.Model = objAudit;
            return View();
        }
        public ActionResult Intervention()
        {

            var objIntervention = _context.Fn_GetIntervention(User.Identity.Name).ToList();
            ViewData.Model = objIntervention;
            return View();

        }
        public ActionResult EditIntervention(string id)
        {
            var objInterventionForEdit = _context.Fn_GetInterventionForEdit(id).ToList();
            ViewData.Model = objInterventionForEdit;
            return View();
        }

        public ActionResult NewClient()
        {
          //  string ClientId = _context.Fn_GetClientId("", 2, "", "", "").AsQueryable().First().ToString();
          //  ViewData.Model = ClientId;
            return View((object)NewClientIDGenerate());
        }
        public ActionResult NewAudit()
        {
            var objInterventions = _context.Fn_GetInterventionForAudit(User.Identity.Name);
            ViewBag.Intervention = objInterventions;
            ViewBag.Count = objInterventions.ToList().Count;
            return View((object)NewAuditIDGenerate());
        }

       
        public ActionResult NewIntervention()
        {
            try
            {
              //  ViewData["InterventionId"] = _context.Fn_GetClientId(User.Identity.Name, 1, "", "", "");
                var defaultIntervention = _context.Fn_GetDefaultIntervention().ToList();
               
               var cost = _context.Fn_GetDefaultCostHour(User.Identity.Name).ToList();


                ViewBag.Clients = _context.Fn_GetClient(User.Identity.Name, 1, "", "", "");
                ViewBag.DefaultCost = cost[0].userCostAllowed;

                ViewBag.DefaultHours = cost[0].userHourAllowed;
                ViewBag.InterventionId = NewInterventionIDGenerate();
                ViewData.Model = defaultIntervention;
          
                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult NewIntervention(FormCollection frmNewIntervention)
        {
            try
            {

                var k=_context.Fn_InsertIntervention(frmNewIntervention["txtInterventionId"], frmNewIntervention["ddlClientId"],User.Identity.Name, Convert.ToDouble(frmNewIntervention["txtInterventionHours"]), Convert.ToDouble(frmNewIntervention["txtInterventionCosts"]), frmNewIntervention["ddlStatus"].Trim(), frmNewIntervention["ddlInterType"]);
                var objIntervention = _context.Fn_GetIntervention(User.Identity.Name).ToList();
                ViewData.Model = objIntervention;
                return View("Intervention");
                // return View();
            }
            catch (Exception e)
            {
                return View();
              //  return View();
            }
        }
        [HttpPost]
        public ActionResult NewAudit(FormCollection frmNewAudit)
        {
            try
            {
                _context.Fn_InsertAuditIntervention(frmNewAudit["txtAuditId"], frmNewAudit["ddlInterventionID"], Convert.ToInt32(frmNewAudit["txtInterventionLife"]), frmNewAudit["txtComment"], User.Identity.Name);
                var objAudit = _context.Fn_GetAuditIntervention(User.Identity.Name);
                ViewData.Model = objAudit;
                return View("Audit");
            }
            catch(Exception e)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult NewClient(FormCollection frmNewClient)
        {
            try
            {
             
                _context.Fn_InsertClient(User.Identity.Name, 3, frmNewClient["txtClientId"], frmNewClient["txtClientName"], frmNewClient["txtClientDecLoc"]);
                var objClient = _context.Fn_GetClient(User.Identity.Name, 1, "", "", "").ToList();
                ViewData.Model = objClient;
                return View("Client");
            }
            catch(Exception e)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult EditIntervention(FormCollection frmEditIntervention)
        {
            try
            {
                _context.Fn_EditInterventionSE(frmEditIntervention["ddlStatus"], frmEditIntervention["txtInterventionId"],1,User.Identity.Name);
                var objIntervention = _context.Fn_GetIntervention(User.Identity.Name).ToList();
                ViewData.Model = objIntervention;
                return View("Intervention");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        public  string NewClientIDGenerate()
        {
            string cID = _context.Fn_GetClientId("", 2, "", "", "").AsQueryable().First().ToString();
            if (cID != "")
            {

                string[] splitClienID = cID.Split('C');

                return "C" + (Convert.ToInt32(splitClienID[1]) + 1);

            }
            else
            {
                return "C1";
            }
            //var clientNumber = _context.Fn_GetClientId("", 2, "", "", "").ToList();
            //if (clientNumber.Count == 0)
            //{
            //    return "C1";
            //}else
            //{
            //    return "C" + (Convert.ToInt32(clientNumber[1]) + 1);
            //}


        }
        public string NewInterventionIDGenerate()
        {
            string interventionID = _context.Fn_GetInterventionId().AsQueryable().First().ToString();
            if (interventionID != "")
            {

                string[] splitInterventionID = interventionID.Split('I');

                return "I" + (Convert.ToInt32(splitInterventionID[1]) + 1);

            }
            else
            {
                return "I1";
            }

        }
        public string NewAuditIDGenerate()
        {
            string auditID = _context.Fn_GetAuditId().AsQueryable().First().ToString();
            if (auditID != "")
            {

                string[] splitAuditID = auditID.Split('A');

                return "A" + (Convert.ToInt32(splitAuditID[1]) + 1);

            }
            else
            {
                return "A1";
            }

        }
    }
}