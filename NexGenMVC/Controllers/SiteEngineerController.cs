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
        public ActionResult Intervention()
        {

            var objIntervention = _context.Fn_GetIntervention(User.Identity.Name).ToList();
            ViewData.Model = objIntervention;
            return View();

        }

        //public ActionResult NewClient()
        //{
        //    var ClientId = _context.Fn_GetClientId("", 2,"","","");
        //    //ViewData.Model = ClientId;
        //    return View(model:"");
        //}
        public ActionResult NewIntervention()
        {
            try
            {
                ViewData["InterventionId"] = _context.Fn_GetClientId(User.Identity.Name, 1, "", "", "");
                var defaultIntervention = _context.Fn_GetDefaultIntervention();
                ViewData.Model = defaultIntervention;
                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }
        [HttpPost]
        public void NewIntervention(FormCollection frmNewIntervention)
        {
            try
            {

                var k=_context.Fn_InsertIntervention(frmNewIntervention["txtInterventionId"], frmNewIntervention["txtClientId"],User.Identity.Name, Convert.ToDouble(frmNewIntervention["txtInterventionHours"]), Convert.ToDouble(frmNewIntervention["txtInterventionCosts"]), frmNewIntervention["ddlStatus"], frmNewIntervention["ddlInterType"]);

                var j = 5;
                // return View();
            }
            catch (Exception e)
            {
              //  return View();
            }
        }
        [HttpPost]
        public ActionResult NewClient(FormCollection frmNewClient)
        {
            try
            {

                _context.Fn_InsertClient(User.Identity.Name, 3, frmNewClient["txtClientId"], frmNewClient["txtClientName"], frmNewClient["txtClientDecLoc"]);
                return View();
            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}