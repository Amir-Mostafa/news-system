using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using day5_asp.Models;
namespace day5_asp.Controllers
{
    public class newsController : Controller
    {
        // GET: news
        public ActionResult create()
        {

            if (Session["user_id"] != null)
            {
                company c = new company();
                ViewBag.dept = new SelectList(c.Catalogs.ToList(), "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("login","user");
            }
            
        }
        [HttpPost]
        public ActionResult create(news s,HttpPostedFileBase file )
        {

            if (Session["user_id"] != null)
            {
                company c = new company();
                file.SaveAs(Server.MapPath("~/attatch/" + Session["user_id"].ToString()+ file.FileName));
                s.img = Session["user_id"].ToString() + file.FileName;
                s.date = DateTime.Now;
                s.user_id = int.Parse(Session["user_id"].ToString());

                c.News.Add(s);
                c.SaveChanges();
                return RedirectToAction("usersNews");
            }
            else
            {
                return RedirectToAction("login", "user");
            }
        }
        public ActionResult userNews()
        {
            if (Session["user_id"] != null)
            {
                company c = new company();

                int id = int.Parse(Session["user_id"].ToString());
                List<news> all = c.News.Where(n => n.user_id == id).ToList();
                return View("allNews",all);
            }
            else
            {
                return RedirectToAction("login", "user");
            }

        }
        public ActionResult allNews()
        {

            if (Session["user_id"] != null)
            {
                company c = new company();
                int id = int.Parse(Session["user_id"].ToString());
                List<news> all = c.News.ToList();
                return View(all);
            }
            else
            {
                return RedirectToAction("login", "user");
            }
        }
        public ActionResult viewNews(int id)
        {
            if(Session["user_id"]!=null)
            {
                company c = new company();
                news news = c.News.Where(n => n.id == id).FirstOrDefault();
                return View(news);
            }
            else
            {
                return RedirectToAction("login", "user");
            }
        }
        public ActionResult newsPartial(int id)
        {
            if (Session["user_id"] != null)
            {
                company c = new company();
                List<news> news = c.News.Where(n => n.cat_id == id).ToList();
                return PartialView(news);
            }
            else
            {
                return RedirectToAction("login", "user");
            }
        }
        public ActionResult newsByCatalog()
        {
            if (Session["user_id"] != null)
            {
                company c = new company();
                ViewBag.cats = new SelectList(c.Catalogs.ToList(), "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("login", "user");
            }
        }
    }
}