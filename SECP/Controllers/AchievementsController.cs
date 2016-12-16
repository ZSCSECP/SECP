using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;
using System.Data.Linq.SqlClient;
using System.IO;

namespace SECP.Controllers
{
    public class AchievementsController : Controller
    {
        //
        // GET: /Achievements/
        SECPDataContext db = new SECPDataContext();
        public void Identity()
        {
            if (Request.Cookies["UserName"] == null)
            {
                ViewData["UserName"] = "欢迎您 游客";
                ViewData["TimeNow"] = DateTime.Now;
                ViewData["State"] = "登陆";
                ViewData["YState"] = "Login";
            }
            else
            {
                ViewData["UserName"] = Request.Cookies["UserName"].Value;
                ViewData["TimeNow"] = DateTime.Now;
                ViewData["State"] = "注销";
                ViewData["YState"] = "Cancel";
            }
        }
        //平台主页
        public ActionResult AchievementsHome()
        {
            Identity();
            return View();
        }
        [HttpGet]
        public ActionResult TAchievements(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            var res = from c in db.Teacher
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Teacher> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult TAchievements(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            int pagesize = 10;
            var res = from c in db.Teacher
                      where SqlMethods.Like(c.teacher_TeachClass, "%" + ser + "%") || SqlMethods.Like(c.teacher_Id.ToString(), "%" + ser + "%")
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Teacher> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        public ActionResult PSAchievements()
        {
            Identity();
            string a = Request.QueryString["Id"];
            ViewData["src"] = "../images/talent/CKT-test1.jpg";
            var res = from c in db.Teacher
                      where c.teacher_Id == int.Parse(a)
                      select c;
            return View(res);
        }
        [HttpGet]
        public ActionResult CIAchievements(int? pageIndex)
        {
            Identity();
            var res = from c in db.Achievements
                      where c.Achievements_Checks == "已通过" && c.Achievements_Type == "论文"
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult CIAchievements(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            var res = from c in db.Achievements
                      where c.Achievements_Checks == "已通过" && c.Achievements_Type == "论文" && (SqlMethods.Like(c.Achievements_Theme, "%" + ser + "%") || SqlMethods.Like(c.Achievements_Specialty, "%" + ser + "%") || SqlMethods.Like(c.Achievements_Publisher, "%" + ser + "%") || SqlMethods.Like(c.Achievements_Id.ToString(), "%" + ser + "%"))
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult CCAchievements(int? pageIndex)
        {
            Identity();
            var res = from c in db.Achievements
                      where c.Achievements_Checks == "已通过" && c.Achievements_Type == "产品"
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult CCAchievements(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            var res = from c in db.Achievements
                      where c.Achievements_Checks == "已通过" && c.Achievements_Type == "产品" && (SqlMethods.Like(c.Achievements_Theme, "%" + ser + "%") || SqlMethods.Like(c.Achievements_Specialty, "%" + ser + "%") || SqlMethods.Like(c.Achievements_Publisher, "%" + ser + "%") || SqlMethods.Like(c.Achievements_Id.ToString(), "%" + ser + "%"))
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult PIAchievements()
        {
            try
            {
                Identity();
                string type = Request.Cookies["Type"].Value;
                if (type == "3" || type == "2")
                {
                    return View();
                }
                else
                {
                    return Redirect("AchievementsWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PIAchievements(string a)
        {
            try
            {
                Identity();
                HttpPostedFileBase file = Request.Files["file1"];
                //存入文件    
                if (file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~/Poper_File/") + System.IO.Path.GetFileName(file.FileName));
                }
                string File = "../Poper_File/" + file.FileName;


                Achievements k = new Achievements();
                k.Achievements_Time = DateTime.Now;
                k.Achievements_Theme = Request.Form["Achievements_Theme"];
                k.Achievements_Type = "论文";
                k.Achievemetns_contact = Request.Form["Achievemetns_contact"];
                k.Achievements_Specialty = Request.Form["Achievements_Specialty"];
                k.Achievements_Checks = "待审核";
                k.Achievements_Thesis = File;
                k.Achievements_Publisher = Request.Cookies["UserName"].Value;
                db.Achievements.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("AchievementsWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        [HttpGet]
        public ActionResult PCAchievements()
        {
            try
            {
                Identity();
                string type = Request.Cookies["Type"].Value;
                if (type == "3" || type == "2")
                {
                    return View();
                }
                else
                {
                    return Redirect("AchievementsWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PCAchievements(string a)
        {
            try
            {
                Identity();
                HttpPostedFileBase file = Request.Files["file1"];
                //存入文件    
                if (file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~/Project_File/") + System.IO.Path.GetFileName(file.FileName));
                }
                string File = "../Project_File/" + file.FileName;


                Achievements k = new Achievements();
                k.Achievements_Time = DateTime.Now;
                k.Achievements_Theme = Request.Form["Achievements_Theme"];
                k.Achievements_Type = "产品";
                k.Achievemetns_contact = Request.Form["Achievemetns_contact"];
                k.Achievements_Specialty = Request.Form["Achievements_Specialty"];
                k.Achievements_Checks = "待审核";
                k.Achievements_Pro = File;
                k.Achievements_Publisher = Request.Cookies["UserName"].Value;
                db.Achievements.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("AchievementsWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        [HttpGet]
        public ActionResult AchievementsWait()
        {
            Identity();
            return View();
        }
        [HttpPost]
        public ActionResult AchievementsWait(string a)
        {
            return Redirect("AchievementsHome");
        }
        public ActionResult AchievementsWrong()
        {
            Identity();
            return View();
        }
        public ActionResult MOAchievements()
        {
            Identity();
            return View();
        }
        [HttpGet]
        public ActionResult MOproject(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            string name = Request.Cookies["UserName"].Value;
            var res = from c in db.Achievements
                      where name == c.Achievements_Publisher && c.Achievements_Type == "产品"
                      select c;
            ViewData["Q"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult MOproject(string a, int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            string id = Request.Form["QX"];
            //删除操作
            var re = from c in db.Achievements
                     where int.Parse(id) == c.Achievements_Id
                     select c;
            db.Achievements.DeleteAllOnSubmit(re);
            db.SubmitChanges();
            Response.Write("<script type='text/javascript'>alert('删除数据成功！');</script >");


            string name = Request.Cookies["UserName"].Value;
            var res = from c in db.Achievements
                      where name == c.Achievements_Publisher && c.Achievements_Type == "产品"
                      select c;
            ViewData["Q"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult MOpoper(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            string name = Request.Cookies["UserName"].Value;
            var res = from c in db.Achievements
                      where name == c.Achievements_Publisher && c.Achievements_Type == "论文"
                      select c;
            ViewData["Q"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult MOpoper(string a, int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            string id = Request.Form["QX"];
            //删除操作
            var re = from c in db.Achievements
                     where int.Parse(id) == c.Achievements_Id
                     select c;
            db.Achievements.DeleteAllOnSubmit(re);
            db.SubmitChanges();
            Response.Write("<script type='text/javascript'>alert('删除数据成功！');</script >");

            string name = Request.Cookies["UserName"].Value;
            var res = from c in db.Achievements
                      where name == c.Achievements_Publisher && c.Achievements_Type == "论文"
                      select c;
            ViewData["Q"] = res.Count();
            PagedList<Achievements> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult CKAchievements()
        {
            Identity();
            string Id = Request.QueryString["Id"];
            var res = from c in db.Achievements
                      where c.Achievements_Id == int.Parse(Id)
                      select c;
            return View(res);
        }
        [HttpPost]
        public ActionResult CKAchievements(string a)
        {
            Identity();
            string Id = Request.QueryString["Id"];
            DownLoad(Id);
            var res = from c in db.Achievements
                      where c.Achievements_Id == int.Parse(Id)
                      select c;
            return View(res);
        }
        public void DownLoad(string Id)
        {
            var res = from c in db.Achievements
                      where c.Achievements_Id == int.Parse(Id)
                      select c;
            string a = "";
            foreach (var k in res)
            {
                if (k.Achievements_Type == "论文")
                    a = k.Achievements_Thesis;
                else
                    a = k.Achievements_Pro;
            }
            string filePath = Server.MapPath(a);//这里注意了,你得指明要下载文件的路径.

            if (System.IO.File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8"); //解决中文乱码
                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(file.Name)); //解决中文文件名乱码    
                Response.AddHeader("Content-length", file.Length.ToString());
                Response.ContentType = "appliction/octet-stream";
                Response.WriteFile(file.FullName);
                Response.End();
            }
        }
        [HttpGet]
        public ActionResult MIAchievements()
        {
            try
            {
                Identity();
                string Id = Request.QueryString["Id"];
                string name = Request.Cookies["UserName"].Value;
                string Type = Request.Cookies["Type"].Value;
                if (Type == "3" || Type == "2")
                {
                    var res = from c in db.Achievements
                              where c.Achievements_Id == int.Parse(Id)
                              select c;
                    return View(res);
                }
                else
                {
                    return Redirect("AchievementsWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult MIAchievements(string a)
        {
            try
            {
                Identity();
                string Id = Request.QueryString["Id"];
                string File = null;

                var res = from c in db.Achievements
                          where c.Achievements_Id == int.Parse(Id)
                          select c;
                foreach (var c in res)
                {
                    File = c.Achievements_Thesis;
                }
                HttpPostedFileBase file = Request.Files["file1"];
                //存入文件    
                if (file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~/Poper_File/") + System.IO.Path.GetFileName(file.FileName));
                    File = "../Poper_File/" + file.FileName;
                }
                foreach (var k in res)
                {
                    k.Achievements_Thesis = File;
                    k.Achievemetns_contact = Request.Form["Achievemetns_contact"];
                    k.Achievements_Theme = Request.Form["Achievements_Theme"];
                    k.Achievements_Specialty = Request.Form["Achievements_Specialty"];
                }
                db.SubmitChanges();
                Response.Write("<script type='text/javascript'>alert('修改数据成功！');</script >");
                return View(res);
            }
            catch {
                Identity();
                string Id = Request.QueryString["Id"];
             //   string File = null;

                var res = from c in db.Achievements
                          where c.Achievements_Id == int.Parse(Id)
                          select c;
                Response.Write("<script type='text/javascript'>alert('修改数据失败！');</script >");
                return View(res);
            }
        }
        [HttpGet]
        public ActionResult MPAchievements()
        {
            try
            {
                Identity();
                string Id = Request.QueryString["Id"];
                string name = Request.Cookies["UserName"].Value;
                string Type = Request.Cookies["Type"].Value;
                if (Type == "3" || Type == "2")
                {
                    var res = from c in db.Achievements
                              where c.Achievements_Id == int.Parse(Id)
                              select c;
                    return View(res);
                }
                else
                {
                    return Redirect("AchievementsWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult MPAchievements(string a)
        {
            try
            {
                Identity();
                string Id = Request.QueryString["Id"];
                string File = null;

                var res = from c in db.Achievements
                          where c.Achievements_Id == int.Parse(Id)
                          select c;
                foreach (var c in res)
                {
                    File = c.Achievements_Pro;
                }
                HttpPostedFileBase file = Request.Files["file1"];
                //存入文件    
                if (file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~/Project_File/") + System.IO.Path.GetFileName(file.FileName));
                    File = "../Project_File/" + file.FileName;
                }
                 
                foreach (var k in res)
                {
                    k.Achievements_Pro = File;
                    k.Achievemetns_contact = Request.Form["Achievemetns_contact"];
                    k.Achievements_Theme = Request.Form["Achievements_Theme"];
                    k.Achievements_Specialty = Request.Form["Achievements_Specialty"];
                }
                db.SubmitChanges();
                Response.Write("<script type='text/javascript'>alert('修改数据成功！');</script >");
                return View(res);
            }
            catch
            {
                Identity();
                string Id = Request.QueryString["Id"];
                //   string File = null;

                var res = from c in db.Achievements
                          where c.Achievements_Id == int.Parse(Id)
                          select c;
                Response.Write("<script type='text/javascript'>alert('修改数据失败！');</script >");
                return View(res);
            }
        }
    }
}
