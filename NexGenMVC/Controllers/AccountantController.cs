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
        public ActionResult Report(string strId)
        {
            try
            {
                using (DefaultConnectionEntities dc = new DefaultConnectionEntities())
                {
                    var customers = dc.Fn_Report(Convert.ToInt32(strId), null);
                    //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/RPTReports/rptCustomer.rdlc");
                    //ReportViewer1.LocalReport.DataSources.Clear();
                    //ReportDataSource rdc = new ReportDataSource("MyDataset", customers);
                    //ReportViewer1.LocalReport.DataSources.Add(rdc);
                    //ReportViewer1.LocalReport.Refresh();

                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
            
        }
        public ActionResult TotCostEngineer()
        {
            try
            {
                var objR = _context.Fn_Report(1, "");
                ViewData.Model = objR.ToList();
                return View();
            }catch(Exception)
            {
                return View();
            }
        }

        //public ActionResult TotCostEngineer(string strId)
        //{
        //    try
        //    {   
        //        using (DefaultConnectionEntities dc = new DefaultConnectionEntities())
        //        {
        //            var customers = dc.Fn_Report(Convert.ToInt32(strId),null);
        //            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/RPTReports/rptCustomer.rdlc");
        //            ReportViewer1.LocalReport.DataSources.Clear();
        //            ReportDataSource rdc = new ReportDataSource("MyDataset", customers);
        //            ReportViewer1.LocalReport.DataSources.Add(rdc);
        //            ReportViewer1.LocalReport.Refresh();
        //        }
        //        //CRM.Models.ReportModel obj = new CRM.Models.ReportModel();
        //        //CRM.Models.cdbConnection objConn = new CRM.Models.cdbConnection();
        //        //DataSet ds = new DataSet();

        //        //SqlCommand cmd = new SqlCommand();
        //        //cmd.CommandText = "GetAllLocationHistory";
        //        //cmd.CommandType = CommandType.StoredProcedure;

        //        //cmd.Parameters.Clear();
        //        //cmd.Parameters.AddWithValue("@SalesPersonID", Convert.ToString(SID));
        //        //cmd.Parameters.AddWithValue("@FromDate", Convert.ToString(Date));
        //        //cmd.Parameters.AddWithValue("@Chk", 1);

        //        //obj.ReportTrackingDs = objConn.getDataBy_DataSet(cmd);

        //        //if (obj.ReportTrackingDs != null && obj.ReportTrackingDs.Tables.Count > 0 && obj.ReportTrackingDs.Tables[0].Rows.Count > 0)
        //        //{
        //        //    if (obj.ReportTrackingDs.Tables[0].Columns.Contains("SalesPersonId"))
        //        //    {
        //        //        obj.ReportTrackingDs.Tables[0].Columns.Remove("SalesPersonId");
        //        //    }

        //        //    return new CsvActionResult(obj.ReportTrackingDs.Tables[0]) { FileDownloadName = "AllLogReport.csv" };
        //        //}
        //        //else
        //        //{
        //        return View();
        //        //}
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}