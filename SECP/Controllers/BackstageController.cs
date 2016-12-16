using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;
namespace SECP.Controllers
{
    public class BackstageController : Controller
    {
        //
        // GET: /Backstage/
        SECPDataContext db = new SECPDataContext();
        /// <summary>
        /// 各表中的行数识别，时间现实
        /// </summary>
        public void Mains()
        {//获得各个表的行数
            var Ach = from a in db.Achievements
                      select a;
            ViewData["Achievements"] =Ach.Count();

            var Pro = from a in db.Project
                      select a;
            ViewData["Project"] = Pro.Count();

            var Ta = from a in db.Talent
                      select a;
            ViewData["Talent"] = Ta.Count();

            var Tr = from a in db.Train
                      select a;
            ViewData["Train"] = Tr.Count();

            var En = from a in db.Enterprise
                      select a;
            ViewData["Enterprise"] = En.Count();

            var pr = from a in db.Products
                     select a;

            ViewData["Products"] = pr.Count();

            ViewData["Time"] = DateTime.Now.ToShortTimeString();
        }
        /// <summary>
        /// 项目平台信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BSHome(int? pageIndex)
        {
            Mains();
            int pagesize = 7;
            var pro = from c in db.Project
                      select c;
            PagedList<Project> _pro = pro.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        //遍历表 利用插件进行分页 ，并通过return view（）进行显示
        /// <summary>
        /// 项目平台升降序显示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BSHome(int? pageIndex,string a)
        {
            Mains();
            int pagesize = 7;
            string ts = Request.Form["te"];
            if (ts == "升序")
            {
                var pro = from c in db.Project
                          orderby c.Project_Id ascending
                          select c;
                PagedList<Project> _pro = pro.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
            else
            {
                var pro = from c in db.Project
                          orderby c.Project_Id descending
                          select c;
                PagedList<Project> _pro = pro.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
        }
        //升降序  数据读取通过linq 信息分类通过PageList插件
        //16/11/22至此
        /// <summary>
        /// 研发平台信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BSAchievement(int? pageIndex)
        {
            Mains();
            int pagesize = 7;
            var Ach = from c in db.Achievements
                      select c;
            PagedList<Achievements> _Ach = Ach.ToPagedList(pageIndex, pagesize);
            return View(_Ach);
        }
        /// <summary>
        /// 研发平台升降序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BSAchievement(int? pageIndex, string a)
        {
            Mains();
            int pagesize = 7;
            string ts = Request.Form["te"];
            if (ts == "升序")
            {
                var p = from c in db.Achievements
                          orderby c.Achievements_Id ascending
                          select c;
                PagedList<Achievements> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
            else
            {
                var p = from c in db.Achievements
                          orderby c.Achievements_Id descending
                          select c;
                PagedList<Achievements> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
        }
        /// <summary>
        /// 人才平台信息显示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BSTalent(int? pageIndex)
        {
            Mains();
            int pagesize = 7;
            var Ta  = from c in db.Talent
                      select c;
            PagedList<Talent> _Ta = Ta.ToPagedList(pageIndex, pagesize);
            return View(_Ta);
        }
        /// <summary>
        /// 人才平台升降序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BSTalent(int? pageIndex, string a)
        {
            Mains();
            int pagesize = 7;
            string ts = Request.Form["te"];
            if (ts == "升序")
            {
                var p = from c in db.Talent
                        orderby c.Talent_Id ascending
                        select c;
                PagedList<Talent> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
            else
            {
                var p = from c in db.Talent
                        orderby c.Talent_Id descending
                        select c;
                PagedList<Talent> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
        }
        /// <summary>
        /// 企业信息显示
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BSEnterprise(int? pageIndex)
        {
            Mains();
            int pagesize = 7;
            var En = from c in db.Enterprise
                     select c;
            PagedList<Enterprise> _En = En.ToPagedList(pageIndex, pagesize);
            return View(_En);
        }
        /// <summary>
        /// 企业平台信息升降序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BSEnterprise(int? pageIndex, string a)
        {
            Mains();
            int pagesize = 7;
            string ts = Request.Form["te"];
            if (ts == "升序")
            {
                var p = from c in db.Enterprise
                        orderby c.Enterprise_Id ascending
                        select c;
                PagedList<Enterprise> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
            else
            {
                var p = from c in db.Enterprise
                        orderby c.Enterprise_Id descending
                        select c;
                PagedList<Enterprise> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
        }
        /// <summary>
        /// 实训基地信息
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BSTrain(int? pageIndex)
        {
            Mains();
            int pagesize = 7;
            var Tr = from c in db.Train
                     select c;
            PagedList<Train> _Tr = Tr.ToPagedList(pageIndex, pagesize);
            return View(_Tr);
        }
        /// <summary>
        /// 实训基地信息升降序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BSTrain(int? pageIndex, string a)
        {
            Mains();
            int pagesize = 7;
            string ts = Request.Form["te"];
            if (ts == "升序")
            {
                var p = from c in db.Train
                        orderby c.Train_Id ascending
                        select c;
                PagedList<Train> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
            else
            {
                var p = from c in db.Train
                        orderby c.Train_Id descending
                        select c;
                PagedList<Train> _pro = p.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
        }

        /// <summary>
        /// 项目信息页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MProject()
        {
            Mains();
            string num=Request.QueryString["Pro"];
            var res = from c in db.Project
                    where c.Project_Id==int.Parse(num)
                    select c;
              foreach (var k in res)
                {
                    ViewData["Id"] = k.Project_Id;
                    ViewData["Type"] = k.Project_Type;
                    ViewData["Name"] = k.Project_Name;
                    ViewData["STime"] = k.Project_STime;
                    ViewData["State"] = k.Project_State;
                    ViewData["Money"] = k.Project_Money;
                    ViewData["TimeLimit"] = k.Project_TimeLimeit;
                    ViewData["Requirement"] = k.Project_Requirement;
                    ViewData["Content"] = k.Project_Content;
                    ViewData["contact"] = k.Project_Contact;
                    ViewData["Publisher"] = k.Project_Publisher;
                    ViewData["PublisherType"] = k.Project_PubilsherType;
                    ViewData["Evaluation"] = k.Project_Evaluation;
                    ViewData["Checks"] = k.Project_Checks;
                    ViewData["Sendee"] = k.Project_Sendee;
                    ViewData["SendeeType"] = k.Project_SendeeType;
                }
                return View();
        }
        /// <summary>
        /// 修改项目是否通过
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MProject(string a)
        {
            Mains();
            string num = Request.QueryString["Pro"];
            string t = Request.Form["TK"];
            var res = from c in db.Project
                      where c.Project_Id == int.Parse(num)
                      select c;
            foreach (var b in res)
            {
                if (t == "该信息无错！审核通过！")
                    b.Project_Checks = "已通过";
                else
                    b.Project_Checks = "不通过";
                db.SubmitChanges();
            }
            return Redirect("BSHome");
        }
        /// <summary>
        /// 招聘详细信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MTalent()
        {
            Mains();
            string num = Request.QueryString["Ta"];
            var res = from c in db.Talent
                      where c.Talent_Id == int.Parse(num)
                      select c;
            foreach (var k in res)
            {
                ViewData["Id"] = k.Talent_Id;
                ViewData["Type"] = k.Talent_Type;
                ViewData["Name"] = k.Talent_Name;
                ViewData["Time"] = k.Talent_Time;
                ViewData["State"] = k.Talent_State;
                ViewData["Money"] = k.Talent_Money;
                ViewData["Num"] = k.Talent_Num;
                ViewData["Content"] = k.Talent_Content;
                ViewData["Publisher"] = k.Talent_Publisher;
                ViewData["Checks"] = k.Talent_Checks;
                ViewData["Welfare"] = k.Talent_Welfare;
                ViewData["Place"] = k.Talent_Place;
            }
            return View();
        }
        /// <summary>
        /// 修改招聘信息是否通过
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MTalent(string a)
        {
            Mains();
            string num = Request.QueryString["Ta"];
            string t = Request.Form["TK"];
            var res = from c in db.Talent
                      where c.Talent_Id == int.Parse(num)
                      select c;
            foreach (var b in res)
            {
                if (t == "该信息无错！审核通过！")
                    b.Talent_Checks = "已通过";
                else
                    b.Talent_Checks = "不通过";
                db.SubmitChanges();
            }
            return Redirect("BSTalent");
        }
        /// <summary>
        /// 实训页详细信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MTrain()
        {
            Mains();
            string num = Request.QueryString["Tr"];
            var res = from c in db.Train
                      where c.Train_Id == int.Parse(num)
                      select c;
            foreach (var k in res)
            {
                ViewData["Id"] = k.Train_Id;
                ViewData["Type"] = k.Train_Type;
                ViewData["Name"] = k.Train_Name;
                ViewData["Time"] = k.Train_Time;
                ViewData["State"] = k.Train_State;
                ViewData["Objective"] = k.Train_Objective;
                ViewData["Content"] = k.Train_Content;
                ViewData["Publisher"] = k.Train_Publisher;
                ViewData["Checks"] = k.Train_Checks;
                ViewData["Major"] = k.Train_Major;
                ViewData["Place"] = k.Train_Place;
            }
            return View();
        }
        /// <summary>
        /// 实训是否通过
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MTrain(string a)
        {
            Mains();
            string num = Request.QueryString["Tr"];
            string t = Request.Form["TK"];
            var res = from c in db.Train
                      where c.Train_Id == int.Parse(num)
                      select c;
            foreach (var b in res)
            {
                if (t == "该信息无错！审核通过！")
                    b.Train_Checks = "已通过";
                else
                    b.Train_Checks = "不通过";
                db.SubmitChanges();
            }
            return Redirect("BSTrain");
        }
        /// <summary>
        /// 企业信息页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MEnterprise()
        {
            Mains();
            string num = Request.QueryString["En"];
            var res = from c in db.Enterprise
                      where c.Enterprise_Id == int.Parse(num)
                      select c;
            foreach (var k in res)
            {
                ViewData["Id"] = k.Enterprise_Id;
                ViewData["UserName"] = k.Enterprise_UserName;
                ViewData["Name"] = k.Enterprise_Name;
                ViewData["Type"] = k.Enterprise_Type;
                ViewData["Scale"] = k.Enterprise_Scale;
                ViewData["Brief"] = k.Enterprise_Brief;
                ViewData["Place"] = k.Enterprise_Place;
                ViewData["Industry"] = k.Enterprise_Industry;
                ViewData["Postcode"] = k.Enterprise_Postcode;
                ViewData["Contact"] = k.Enterprise_Contact;
                ViewData["Business"] = k.Enterprise_Business;
                ViewData["Culture"] = k.Enterprise_Culture;
                ViewData["EMail"] = k.Enterprise_Email;
                ViewData["Telephone"] = k.Enterprise_Tel;
                ViewData["Checks"] = k.Enterprise_Checks;
                ViewData["QQ"] = k.Enterprise_QQ;
            }
            return View();
        }
        /// <summary>
        /// 审核企业信息
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MEnterprise(string a)
        {
            Mains();
            string num = Request.QueryString["En"];
            string t = Request.Form["TK"];
            var res = from c in db.Enterprise
                      where c.Enterprise_Id == int.Parse(num)
                      select c;
            foreach (var b in res)
            {
                if (t == "该信息无错！审核通过！")
                    b.Enterprise_Checks = "已通过";
                else
                    b.Enterprise_Checks = "不通过";
                db.SubmitChanges();
            }
            return Redirect("BSEnterprise");
        }
        /// <summary>
        /// 研发信息页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MAchievement()
        {
            Mains();
            string num = Request.QueryString["Ach"];
            var res = from c in db.Achievements
                      where c.Achievements_Id == int.Parse(num)
                      select c;
            foreach (var k in res)
            {
                ViewData["Id"] = k.Achievements_Id;
                ViewData["Type"] = k.Achievements_Type;
                ViewData["Theme"] = k.Achievements_Theme;
                ViewData["Time"] = k.Achievements_Time;
                ViewData["Publisher"] = k.Achievements_Publisher;
                ViewData["contact"] = k.Achievemetns_contact;
                ViewData["Specialty"] = k.Achievements_Specialty;
                ViewData["Checks"] = k.Achievements_Checks;
            }
            return View();
        }
        /// <summary>
        /// 审核信息
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MAchievement(string a)
        {
            Mains();
            string num = Request.QueryString["Ach"];
            string t = Request.Form["TK"];
            var res = from c in db.Achievements
                      where c.Achievements_Id == int.Parse(num)
                      select c;
            foreach (var b in res)
            {
                if (t == "该信息无错！审核通过！")
                    b.Achievements_Checks = "已通过";
                else
                    b.Achievements_Checks = "不通过";
                db.SubmitChanges();
            }
            return Redirect("BSAchievement");
        }
        [HttpGet]
        public ActionResult PicChange()
        {
            Mains();
            string Id = Request.QueryString["Id"];
            if (Id == "1")
                ViewData["Pic"] = "项目信息平台图片";
            else if (Id == "4")
                ViewData["Pic"] = "研发信息平台图片";
            else if (Id == "3")
                ViewData["Pic"] = "人才信息平台图片";
            else if (Id == "2")
                ViewData["Pic"] = "实训信息平台图片";
            else if(Id=="5")
                ViewData["Pic"] = "企业信息平台图片";
            return View();
        }
        [HttpPost]
        public ActionResult PicChange(string a)
        {
            Mains();
            if (Request.QueryString["Id"] == "1")
            {
                HttpPostedFileBase file1 = Request.Files["file1"];
                HttpPostedFileBase file2 = Request.Files["file2"];
                HttpPostedFileBase file3 = Request.Files["file3"];
                HttpPostedFileBase file4 = Request.Files["file4"];
                //存入文件
                bool check = false;
                if (file1.ContentLength > 0)
                {
                    file1.SaveAs(Server.MapPath("~/images/Project/") + System.IO.Path.GetFileName("Slider-1.jpg"));
                    check = true;
                }
                if (file2.ContentLength > 0)
                {
                    file2.SaveAs(Server.MapPath("~/images/Project/") + System.IO.Path.GetFileName("Slider-2.jpg"));
                    check = true;
                }
                if (file3.ContentLength > 0)
                {
                    file3.SaveAs(Server.MapPath("~/images/Project/") + System.IO.Path.GetFileName("Slider-3.jpg"));
                    check = true;
                }
                if (file4.ContentLength > 0)
                {
                    file4.SaveAs(Server.MapPath("~/images/Project/") + System.IO.Path.GetFileName("Slider-4.jpg"));
                    check = true;
                }
                if (check == true)
                {
                    Response.Write("<script type='text/javascript'>alert('上传成功！');</script >");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('上传失败！');</script >");
                }
                return View();
            }
            else if (Request.QueryString["Id"] == "2")
            {
                HttpPostedFileBase file1 = Request.Files["file1"];
                HttpPostedFileBase file2 = Request.Files["file2"];
                HttpPostedFileBase file3 = Request.Files["file3"];
                HttpPostedFileBase file4 = Request.Files["file4"];
                //存入文件
                bool check = false;
                if (file1.ContentLength > 0)
                {
                    file1.SaveAs(Server.MapPath("~/images/train/") + System.IO.Path.GetFileName("001.jpg"));
                    check = true;
                }
                if (file2.ContentLength > 0)
                {
                    file2.SaveAs(Server.MapPath("~/images/train/") + System.IO.Path.GetFileName("002.jpg"));
                    check = true;
                }
                if (file3.ContentLength > 0)
                {
                    file3.SaveAs(Server.MapPath("~/images/train/") + System.IO.Path.GetFileName("003.jpg"));
                    check = true;
                }
                if (file4.ContentLength > 0)
                {
                    file4.SaveAs(Server.MapPath("~/images/train/") + System.IO.Path.GetFileName("004.jpg"));
                    check = true;
                }
                if (check == true)
                {
                    Response.Write("<script type='text/javascript'>alert('上传成功！');</script >");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('上传失败！');</script >");
                }
                return View();
            }
           else if (Request.QueryString["Id"] == "3")
            {
                HttpPostedFileBase file1 = Request.Files["file1"];
                HttpPostedFileBase file2 = Request.Files["file2"];
                HttpPostedFileBase file3 = Request.Files["file3"];
                HttpPostedFileBase file4 = Request.Files["file4"];
                //存入文件
                bool check = false;
                if (file1.ContentLength > 0)
                {
                    file1.SaveAs(Server.MapPath("~/images/talent/") + System.IO.Path.GetFileName("001.jpg"));
                    check = true;
                }
                if (file2.ContentLength > 0)
                {
                    file2.SaveAs(Server.MapPath("~/images/talent/") + System.IO.Path.GetFileName("002.jpg"));
                    check = true;
                }
                if (file3.ContentLength > 0)
                {
                    file3.SaveAs(Server.MapPath("~/images/talent/") + System.IO.Path.GetFileName("003.jpg"));
                    check = true;
                }
                if (file4.ContentLength > 0)
                {
                    file4.SaveAs(Server.MapPath("~/images/talent/") + System.IO.Path.GetFileName("004.jpg"));
                    check = true;
                }
                if (check == true)
                {
                    Response.Write("<script type='text/javascript'>alert('上传成功！');</script >");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('上传失败！');</script >");
                }
                return View();
            }
            else  if (Request.QueryString["Id"] == "4")
            {
                HttpPostedFileBase file1 = Request.Files["file1"];
                HttpPostedFileBase file2 = Request.Files["file2"];
                HttpPostedFileBase file3 = Request.Files["file3"];
                HttpPostedFileBase file4 = Request.Files["file4"];
                //存入文件
                bool check = false;
                if (file1.ContentLength > 0)
                {
                    file1.SaveAs(Server.MapPath("~/images/achievements/") + System.IO.Path.GetFileName("001.jpg"));
                    check = true;
                }
                if (file2.ContentLength > 0)
                {
                    file2.SaveAs(Server.MapPath("~/images/achievements/") + System.IO.Path.GetFileName("002.jpg"));
                    check = true;
                }
                if (file3.ContentLength > 0)
                {
                    file3.SaveAs(Server.MapPath("~/images/achievements/") + System.IO.Path.GetFileName("003.jpg"));
                    check = true;
                }
                if (file4.ContentLength > 0)
                {
                    file4.SaveAs(Server.MapPath("~/images/achievements/") + System.IO.Path.GetFileName("004.jpg"));
                    check = true;
                }
                if (check == true)
                {
                    Response.Write("<script type='text/javascript'>alert('上传成功！');</script >");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('上传失败！');</script >");
                }
                return View();
            }
            else
            {
                HttpPostedFileBase file1 = Request.Files["file1"];
                HttpPostedFileBase file2 = Request.Files["file2"];
                HttpPostedFileBase file3 = Request.Files["file3"];
                HttpPostedFileBase file4 = Request.Files["file4"];
                //存入文件
                bool check = false;
                if (file1.ContentLength > 0)
                {
                    file1.SaveAs(Server.MapPath("~/images/enterprise/") + System.IO.Path.GetFileName("001.jpg"));
                    check = true;
                }
                if (file2.ContentLength > 0)
                {
                    file2.SaveAs(Server.MapPath("~/images/enterprise/") + System.IO.Path.GetFileName("002.jpg"));
                    check = true;
                }
                if (file3.ContentLength > 0)
                {
                    file3.SaveAs(Server.MapPath("~/images/enterprise/") + System.IO.Path.GetFileName("003.jpg"));
                    check = true;
                }
                if (file4.ContentLength > 0)
                {
                    file4.SaveAs(Server.MapPath("~/images/enterprise/") + System.IO.Path.GetFileName("004.jpg"));
                    check = true;
                }
                if (check == true)
                {
                    Response.Write("<script type='text/javascript'>alert('上传成功！');</script >");
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('上传失败！');</script >");
                }
                return View();
            }
        }
        [HttpGet]
        public ActionResult BSChangePassword()
        {
            Mains();
            return View();
        }
        [HttpPost]
        public ActionResult BSChangePassword(string code, string pwd, string pwd1, string pwd2)
        {
            Mains();
            SECPDataContext db = new SECPDataContext();
            string name = Request.Cookies["UserName"].Value;
            string Id = Request.Cookies["Type"].Value;
            var res = from c in db.Admin
                      where c.admin_Password == pwd
                      select c;
            if (res.Count() != 0)
            {
                if (pwd1 == pwd2)
                {
                    if (Session["ValidateCode"].ToString() == code)
                    {
                        var k = from c in db.Admin
                                where c.admin_UserName == name
                                select c;
                        foreach (var s in k)
                        {
                            s.admin_Password = pwd1;
                            db.SubmitChanges();
                        }
                        Response.Write("<script type='text/javascript'>alert('修改成功');</script >");
                        return View();
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('验证码错误');</script >");
                        return View();
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('新密码前后不一致');</script >");
                    return View();
                }
            }
            else
            {
                Response.Write("<script type='text/javascript'>alert('密码错误');</script >");
                return View();
            }
        }
        [HttpGet]
        public ActionResult BSProducts(int? pageIndex)
        {
            Mains();
            int pagesize = 7;
            var pro = from c in db.Products
                      select c;
            PagedList<Products> _pro = pro.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        [HttpPost]
        public ActionResult BSProducts(int? pageIndex, string a)
        {
            Mains();
            int pagesize = 7;
            string ts = Request.Form["te"];
            if (ts == "升序")
            {
                var pro = from c in db.Products
                          orderby c.Products_Id ascending
                          select c;
                PagedList<Products> _pro = pro.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
            else
            {
                var pro = from c in db.Products
                          orderby c.Products_Id descending
                          select c;
                PagedList<Products> _pro = pro.ToPagedList(pageIndex, pagesize);
                return View(_pro);
            }
        }

        [HttpGet]
        public ActionResult MProducts()
        {
            Mains();
            string num = Request.QueryString["Pr"];
            var res = from c in db.Products
                      where c.Products_Id == int.Parse(num)
                      select c;
            return View(res);
        }
        [HttpPost]
        public ActionResult MProducts(string a)
        {
            Mains();
            string num = Request.QueryString["Pr"];
            string t = Request.Form["TK"];
            var res = from c in db.Products
                      where c.Products_Id == int.Parse(num)
                      select c;
            foreach (var b in res)
            {
                if (t == "该信息无错！审核通过！")
                    b.Products_Checks = "已通过";
                else
                    b.Products_Checks = "不通过";
                db.SubmitChanges();
            }
            return Redirect("BSProducts");
        }
    }
}
