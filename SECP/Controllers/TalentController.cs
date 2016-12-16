using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;
using System.Data.Linq.SqlClient;

namespace SECP.Controllers
{
    public class TalentController : Controller
    {
        //
        // GET: /Talent/
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
        public ActionResult TalentHome()
        {
            Identity();
            return View();
        }
        [HttpGet]
        public ActionResult SRTalent(int? pageIndex)
        {
            Identity();
            var res = from c in db.Student
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Student> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult SRTalent(int? pageIndex, string key)
        {
            Identity();
            string ser = Request.Form["search"];
            var res = from c in db.Student
                      where SqlMethods.Like(c.student_Major, "%" + ser + "%") || SqlMethods.Like(c.student_Occupation, "%" + ser + "%") || SqlMethods.Like(c.student_Id.ToString(), "%" + ser + "%")
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Student> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult INTalent(int? pageIndex)
        {
            Identity();
            var res = from c in db.Talent
                      where c.Talent_Checks == "已通过" && c.Talent_Type == "实习"
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Talent> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult INTalent(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            var res = from c in db.Talent
                      where c.Talent_Checks == "已通过" && c.Talent_Type == "实习" && (SqlMethods.Like(c.Talent_Name, "%" + ser + "%") || SqlMethods.Like(c.Talent_Publisher, "%" + ser + "%"))
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Talent> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult RETalent(int? pageIndex)
        {
            Identity();
            var res = from c in db.Talent
                      where c.Talent_Checks == "已通过" && c.Talent_Type == "全职"
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Talent> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult RETalent(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            var res = from c in db.Talent
                      where c.Talent_Checks == "已通过" && c.Talent_Type == "全职" && (SqlMethods.Like(c.Talent_Name, "%" + ser + "%") || SqlMethods.Like(c.Talent_Publisher, "%" + ser + "%"))
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Talent> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult COTalent(int? pageIndex)
        {
            Identity();
            var res = from c in db.Talent
                      where c.Talent_Checks == "已通过" && c.Talent_Type == "合作"
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Talent> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult COTalent(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            var res = from c in db.Talent
                      where c.Talent_Checks == "已通过" && c.Talent_Type == "合作" && (SqlMethods.Like(c.Talent_Name, "%" + ser + "%") || SqlMethods.Like(c.Talent_Publisher, "%" + ser + "%"))
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Talent> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }

        public ActionResult MOTalent()
        {
            try
            {
                Identity();
                string type = Request.Cookies["Type"].Value;
                if (type == "2" || type == "4")
                    return Redirect("TalentWrong");
                else
                    return View();
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpGet]
        public ActionResult CKTalent()
        {
            Identity();
            try
            {
                string id = Request.QueryString["Id"];
                string pb = "";
                var res = from c in db.Talent
                          where c.Talent_Id == int.Parse(id)
                          select c;
                foreach (var s in res)
                {
                    pb = s.Talent_Publisher;
                }
                var res1 = from c in db.Enterprise
                           where c.Enterprise_UserName == pb
                           select c;
                foreach (var k in res1)
                {
                    ViewData["Tel"] = k.Enterprise_Tel;
                    ViewData["Address"] = k.Enterprise_Place;
                }
                return View(res);
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult CKTalent(string a)
        {
                Identity();
                //显示数据
                string id = Request.QueryString["Id"];
                string pb = "";
                string Enid = "";
                string Stid="";
                var res = from c in db.Talent
                          where c.Talent_Id == int.Parse(id)
                          select c;
                foreach (var s in res)
                {
                    pb = s.Talent_Publisher;
                }
                var res1 = from c in db.Enterprise
                           where c.Enterprise_UserName == pb
                           select c;
                foreach (var k in res1)
                {
                    ViewData["Tel"] = k.Enterprise_Tel;
                    ViewData["Address"] = k.Enterprise_Place;
                    Enid = k.Enterprise_Id.ToString();
                }
                if (Request.Cookies["Type"].Value == "1")
                {
                    var res2 = from c in db.Student
                               where c.student_UserName == Request.Cookies["UserName"].Value
                               select c;
                    foreach (var l in res2)
                    {
                        Stid = l.student_Id.ToString();
                    }
                    var res3 = from c in db.Resume
                               where c.Talent_Id == int.Parse(id) && c.sudent_Id == int.Parse(Stid)
                               select c;
                    if (res3.Count() == 0)
                    {
                        //建表
                        Resume re = new Resume();
                        re.Resume_Time = DateTime.Now;
                        re.Resume_State = "待审核";
                        re.Talent_Id = int.Parse(id);
                        re.company_Id = int.Parse(Enid);
                        re.sudent_Id = int.Parse(Stid);
                        re.Resume_reply = "未回复";
                        db.Resume.InsertOnSubmit(re);
                        db.SubmitChanges();
                        Response.Write("<script type='text/javascript'>alert('申请成功！');</script >");
                        return View(res);
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('申请失败！您已经申请过这个工作');</script >");
                        return View(res);
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('申请失败!您并不是学生，无法申请工作！');</script >");
                    return View(res);
                }
        }
        public ActionResult CKTalentresume()
        {
            Identity();
            return View();
        }
        public ActionResult PSTalent()
        {
            Identity();
            string a = Request.QueryString["Id"];
            ViewData["src"] = "../images/student/CKT-test1.jpg";
            var res = from c in db.Student
                      where c.student_Id == int.Parse(a)
                      select c;
            foreach (var k in res)
            {
                if (k.student_Photo != null)
                {
                    ViewData["src"] = k.student_Photo;
                    ViewData["QQ"] = k.student_QQ;
                }
            }
            return View(res);
        }
        [HttpGet]
        public ActionResult PITalent()
        {
            try
            {
                Identity();
                string type = Request.Cookies["Type"].Value;
                if (type == "3")
                {
                    return View();
                }
                else
                {
                    return Redirect("TalentWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PITalent(string a)
        {
            try
            {
                Identity();
                Talent k = new Talent();
                k.Talent_Time = DateTime.Now;
                k.Talent_Name = Request.Form["Talent_Name"];
                k.Talent_Num = Request.Form["Talent_Num"];
                k.Talent_Money = Request.Form["Talent_Money"];
                k.Talent_Content = Request.Form["Talent_Content"];
                k.Talent_Checks = "待审核";
                k.Talent_Place = Request.Form["Talent_Place"];
                k.Talent_Welfare = Request.Form["Talent_Welfare"];
                k.Talent_State = "正在招聘";
                k.Talent_Type = "实习";
                k.Talent_Publisher = Request.Cookies["UserName"].Value;
                db.Talent.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("TalentWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        [HttpGet]
        public ActionResult PRTalent()
        {
            try
            {
                Identity();
                string type = Request.Cookies["Type"].Value;
                if (type == "3")
                {
                    return View();
                }
                else
                {
                    return Redirect("TalentWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PRTalent(string a)
        {
            try
            {
                Identity();
                Talent k = new Talent();
                k.Talent_Time = DateTime.Now;
                k.Talent_Name = Request.Form["Talent_Name"];
                k.Talent_Num = Request.Form["Talent_Num"];
                k.Talent_Money = Request.Form["Talent_Money"];
                k.Talent_Content = Request.Form["Talent_Content"];
                k.Talent_Checks = "待审核";
                k.Talent_Place = Request.Form["Talent_Place"];
                k.Talent_Welfare = Request.Form["Talent_Welfare"];
                k.Talent_State = "正在招聘";
                k.Talent_Type = "全职";
                k.Talent_Publisher = Request.Cookies["UserName"].Value;
                db.Talent.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("TalentWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        [HttpGet]
        public ActionResult PCTalent()
        {
            try
            {
                Identity();
                string type = Request.Cookies["Type"].Value;
                if (type == "3")
                {
                    return View();
                }
                else
                {
                    return Redirect("TalentWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PCTalent(string a)
        {
            try
            {
                Identity();
                Talent k = new Talent();
                k.Talent_Time = DateTime.Now;
                k.Talent_Name = Request.Form["Talent_Name"];
                k.Talent_Num = Request.Form["Talent_Num"];
                k.Talent_Money = Request.Form["Talent_Money"];
                k.Talent_Content = Request.Form["Talent_Content"];
                k.Talent_Checks = "待审核";
                k.Talent_Place = Request.Form["Talent_Place"];
                k.Talent_Welfare = Request.Form["Talent_Welfare"];
                k.Talent_State = "正在招聘";
                k.Talent_Type = "合作";
                k.Talent_Publisher = Request.Cookies["UserName"].Value;
                db.Talent.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("TalentWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        public ActionResult MOTalentAccept(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            string name = Request.Cookies["UserName"].Value;
            string type = Request.Cookies["Type"].Value;
            if (type == "1")
            {
                var k = (from c in db.Student
                         where c.student_UserName == name
                         select c.student_Id).First();
                var res = from c in db.Resume
                          where k == c.sudent_Id
                          select c;
                ViewData["Q"] = res.Count();
                PagedList<Resume> _res = res.ToPagedList(pageIndex, pagesize);
                return View(_res);
            }
            else if (type == "3")
            {
                var k = (from c in db.Enterprise
                         where c.Enterprise_UserName == name
                         select c.Enterprise_Id).First();
                var res = from c in db.Resume
                          where k == c.company_Id
                          select c;
                ViewData["Q"] = res.Count();
                PagedList<Resume> _res = res.ToPagedList(pageIndex, pagesize);
                return View(_res);
            }
            else
            {
                return Redirect("TalentWrong");
            }
        }
        [HttpPost]
        public ActionResult MOTalentAccept(string a, int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            string name = Request.Cookies["UserName"].Value;
            string type = Request.Cookies["Type"].Value;
            string id = Request.Form["QX"];
            if (type == "1")
            {
                //删除申请操作
                var res1 = from c in db.Resume
                           where c.Resume_Id == int.Parse(id)
                           select c;
                db.Resume.DeleteAllOnSubmit(res1);
                db.SubmitChanges();
                Response.Write("<script type='text/javascript'>alert('删除数据成功！');</script >");
                //学生数据
                var k = (from c in db.Student
                         where c.student_UserName == name
                         select c.student_Id).First();
                var res = from c in db.Resume
                          where k == c.sudent_Id
                          select c;
                ViewData["Q"] = res.Count();
                PagedList<Resume> _res = res.ToPagedList(pageIndex, pagesize);
                return View(_res);
            }
            else if (type == "3")
            {
                //删除申请操作
                var res1 = from c in db.Resume
                           where c.Resume_Id == int.Parse(id)
                           select c;
                db.Resume.DeleteAllOnSubmit(res1);
                db.SubmitChanges();
                Response.Write("<script type='text/javascript'>alert('删除数据成功！');</script >");
                //企业数据
                var k = (from c in db.Enterprise
                         where c.Enterprise_UserName == name
                         select c.Enterprise_Id).First();
                var res = from c in db.Resume
                          where k == c.company_Id
                          select c;
                ViewData["Q"] = res.Count();
                PagedList<Resume> _res = res.ToPagedList(pageIndex, pagesize);
                return View(_res);
            }
            else
            {
                return Redirect("TalentWrong");
            }
        }
        [HttpGet]
        public ActionResult MOTalentRelease(int? pageIndex)
        {
            try
            {
                if (Request.Cookies["Type"].Value == "3")
                {
                    Identity();
                    int pagesize = 10;
                    string name = Request.Cookies["UserName"].Value;
                    string type = Request.Cookies["Type"].Value;
                    var res = from c in db.Talent
                              where c.Talent_Publisher == name
                              select c;
                    ViewData["Q"] = res.Count();
                    PagedList<Talent> _res = res.ToPagedList(pageIndex, pagesize);
                    return View(_res);
                }
                else
                {
                    return Redirect("TalentWrong");
                }
            }
            catch
            {
                return Redirect("TalentHome");
            }
        }
        [HttpPost]
        public ActionResult MOTalentRelease(string a,int? pageIndex)
        {
            Identity();
            string id = Request.Form["QX"];
            //删除项目前先删除申请表中和该项目关联的信息
            var res2 = from c in db.Resume
                       where c.Talent_Id == int.Parse(id)
                       select c;
            db.Resume.DeleteAllOnSubmit(res2);
            db.SubmitChanges();
            //删除项目
            var res = from c in db.Talent
                      where int.Parse(id) == c.Talent_Id
                      select c;
            db.Talent.DeleteAllOnSubmit(res);
            db.SubmitChanges();
            Response.Write("<script type='text/javascript'>alert('删除成功！');</script >");
            //显示数据
            int pagesize = 10;
            string name = Request.Cookies["UserName"].Value;
            string type = Request.Cookies["Type"].Value;
            var res1 = from c in db.Talent
                      where c.Talent_Publisher == name
                      select c;
            ViewData["Q"] = res.Count();
            PagedList<Talent> _res = res1.ToPagedList(pageIndex, pagesize);
            return View(_res);

        }
        [HttpGet]
        public ActionResult TalentWait()
        {
            Identity();
            return View();
        }
        [HttpPost]
        public ActionResult TalnetWait(string a)
        {
            return Redirect("TalentHome"); 
        }
        public ActionResult TalentWrong()
        {
            Identity();
            return View();
        }
        [HttpGet]
        public ActionResult MKTalent()
        {
            Identity();
            string Id = Request.QueryString["Id"];
            string name = Request.Cookies["UserName"].Value;
            string Type = Request.Cookies["Type"].Value;
            if (Type == "3")
            {
                var res = from c in db.Talent
                          where c.Talent_Id == int.Parse(Id)
                          select c;
                var res1 = from c in db.Enterprise
                           where c.Enterprise_UserName == name
                           select c;
                foreach (var k in res1)
                {
                    ViewData["Tel"] = k.Enterprise_Tel;
                    ViewData["Adress"]=k.Enterprise_Place;
                }
                return View(res);
            }
            else
                return Redirect("TalentWrong");
        }
        [HttpPost]
        public ActionResult MKTalent(string a)
        {
            Identity();
            try
            {
                string name = Request.Cookies["UserName"].Value;
                string Type = Request.Cookies["Type"].Value;
                string Id = Request.QueryString["Id"];
                var res = from c in db.Talent
                          where c.Talent_Id == int.Parse(Id)
                          select c;
                foreach (var k in res)
                {
                    k.Talent_Name = Request.Form["Talent_Name"];
                    k.Talent_Money = Request.Form["Talent_Money"];
                    k.Talent_Content = Request.Form["Talent_Content"];
                    k.Talent_Welfare = Request.Form["Talent_Welfare"];
                }
                db.SubmitChanges();
                Response.Write("<script type='text/javascript'>alert('修改成功！');</script >");
                return View(res);
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('修改失败！');</script >");
                return View();
            }
        }
    }
}
