using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using day5_asp.Models;
namespace day5_asp.Controllers
{
    public class userController : Controller
    {
        // GET: user
        company db = new company();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            if(Request.Cookies["route"]!=null)
            {
                Session.Add("user_id", Request.Cookies["route"].Values["id"]);
                return RedirectToAction("profile");
            }
            if (Session["user_id"] == null)
                return View();
            else
                return RedirectToAction("profile");
        }

        [HttpPost]
        public ActionResult login(user u,string check)
        {
            if (Session["user_id"] == null)
            {
                List<user> users = db.Users.ToList();
                user s = db.Users.Where(n => n.email == u.email && n.password == u.password).FirstOrDefault();
                if (s != null)
                {

                    if(check=="true")
                    {
                        HttpCookie co = new HttpCookie("route");
                        co.Values.Add("id", s.id.ToString());
                        co.Values.Add("name", s.name);
                        co.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(co);
                    }

                    Session["user_id"] = s.id.ToString();
                    return RedirectToAction("profile");
                }
                else
                {
                    ViewBag.status = "invalid username or password";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("profile");
            }
        }
        public ActionResult profile()
        {
            if (Session["user_id"] != null)
            {
                int id = int.Parse(Session["user_id"].ToString());
                user u = db.Users.Where(n => n.id == id).FirstOrDefault();
                return View(u);
            }
            else
            {
                return RedirectToAction("login");
            }

        }
        public ActionResult logout()
        {

            HttpCookie co = new HttpCookie("route");
            co.Expires = DateTime.Now.AddDays(-15);
            Response.Cookies.Add(co);
            if(Session["user_id"]!=null)
            {
                Session["user_id"] = null;
                return RedirectToAction("login");
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}