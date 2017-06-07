using Microsoft.Reporting.WebForms;
using NexGenMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NexGenMVC.Controllers
{
    public class AccountantController : Controller
    {
        DefaultConnectionEntities _context = new DefaultConnectionEntities();

        public AccountantController() { }

        public AccountantController(DefaultConnectionEntities context)
        {
            _context = context;
        }


        // GET: Accountant
        public ActionResult Index()
        {
            return View();
        }
     
        public ActionResult Report()
        {
            return View();
        }
        public ActionResult TotCostEngineer()
        {
            try
            {
                var objR = _context.Fn_Report(1, "");
                ViewData.Model = objR.ToList();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult CostByDistrict()
        {
            try
            {
                var objR = _context.Fn_GetDistrictReport();
                ViewData.Model = objR.ToList();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult AvgCostEngineer()
        {
            try
            {
                var objR = _context.Fn_Report(2, "");
                ViewData.Model = objR.ToList();
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CostByMonthDistrict(FormCollection frmReport)
        {
            try
            {
                var objR = _context.Fn_ReportMonthDis(frmReport["ddlDistrict"]);
                ViewData.Model = objR.ToList();
;                return View("ReportMonDis");
            }
            catch(Exception)
            {
                return View();
            }
        }

        public ActionResult CostByMonthDistrict()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }
        }
}