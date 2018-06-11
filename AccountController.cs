using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YellowGroupCST247.Models;

namespace YellowGroupCST247.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (MyDBContext db = new MyDBContext())
            {
                return View(db.userAccount.ToList());
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                using (MyDBContext db = new MyDBContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
            
            ModelState.Clear();
            ViewBag.Message = account.FirstName + " " + account.LastName + " "+ "Successfully Registered.";
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                var usr = db.userAccount.Single(u => u.Username == user.Username && u.Password == user.Password);
                if (usr.Password != null)
                {
                    Session["UserID"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("GameView");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect.");
                }
                return View();
            }
        }
        public ActionResult GameView()
        {
            if(Session["UserID"] != null)
            {
                return View("~/Views/Game/GameView.cshtml");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
   
}