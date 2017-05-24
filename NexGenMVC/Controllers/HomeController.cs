using NexGenMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NexGenMVC.Controllers
{
    public class HomeController : Controller
    {
        DefaultConnectionEntities db = new DefaultConnectionEntities();
   
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize(Roles = "Manager")]
        //public ActionResult Manager()
        //{
        //    return View();
        //}
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AspNetUsers users,string returnUrl)
        {
          
            var dataItem = db.AspNetUsers.Where(x => x.UserName == users.UserName && x.PasswordHash == users.Password).First();
            if(dataItem!=null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.UserName, false);
                if(Url.IsLocalUrl(returnUrl) && returnUrl.Length>1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    Session["UserId"] = users.UserName;
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Invalid User/Password");
                return View();
            }
        }

        public ActionResult CheckForDefaultCost(string UserID)
        {
            var DefaultCost = db.Users.Where(x => x.userId == UserID).FirstOrDefault().userCostAllowed;
            if(Convert.ToDouble(DefaultCost)<20)
            {
                return View("View1");
            }
            else
            {
                return View("View2");
            }
          //  return View();
        }
    }
}