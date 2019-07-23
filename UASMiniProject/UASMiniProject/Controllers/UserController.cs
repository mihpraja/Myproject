using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UASMiniProject.Models;

namespace UASMiniProject.Controllers
{
    public class UserController : Controller
    {
        private UAScontextss db = new UAScontextss();
        // GET: User
        public ActionResult RegisterForAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterForAdmin(User user)
        {
            if (user == null)
            {
                ViewBag.Message = "Please enter the Data";
            }
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                ViewBag.Message = "Sucessfully Added";
                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                using (UAScontextss db = new UAScontextss())
                {         
                    var usr = db.Users.Where(u => u.Login_id.Equals(user.Login_id) && u.Password.Equals(user.Password)).First();
                    if (usr != null)
                    {
                        Session["DummyID_User"] = usr.DummyID_User.ToString();
                        Session["Login_id"] = usr.Login_id.ToString();
                        Session["Role"] = usr.Role.ToString();
                        if (Session["Role"].ToString().ToLower() == "admin")
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        else if (Session["Role"].ToString().ToLower() == "mac")
                        {

                            return RedirectToAction("Index", "MAC");
                        }
                        else
                        {
                            return RedirectToAction("Login", "User");
                        }
                    }
                    else
                    {
                        TempData["message"] = "Incorrect Credentials or you are not an existing user";
                        return RedirectToAction("Login", "User");

                    }
                }
            }
            catch (Exception)
            {
                TempData["message"] = "Incorrect Credentials";
                return RedirectToAction("Login", "User");

            }
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}