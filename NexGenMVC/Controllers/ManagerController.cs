using NexGenMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

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
                // var body = "";
                MailMessage mail = new MailMessage();
                mail.To.Add(_context.Fn_GetUserIdToSendMail(frmEditIntervention["txtInterventionId"]).AsQueryable().First().ToString());
                mail.From = new MailAddress("krishpatel0704@gmail.com");
                mail.Subject = "Intervention Updated";
                string Body = frmEditIntervention["txtInterventionId"] + " Updated to " + frmEditIntervention["ddlStatus"];
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("krishpatel0704@gmail.com", "bhavikano74");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
               // message.Body = frmEditIntervention["txtInterventionId"] + " Updated to " + frmEditIntervention["ddlStatus"];
               
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