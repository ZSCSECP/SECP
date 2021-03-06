﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;
using System.Data.Linq.SqlClient;
using System.Text;
namespace SECP.Controllers
{
    public class TrainController : Controller
    {
        //
        // GET: /Train/
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
        public ActionResult TrainHome()
        {
            Identity();
            return View();
        }

        [HttpGet]
        public ActionResult CLTrain(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            var res = from c in db.Train
                      where c.Train_Checks == "已通过" && c.Train_Type == "培训"
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult CLTrain(int? pageIndex,string a)
        {
            Identity();
            string ser = Request.Form["search"];
            int pagesize = 10;
            var res = from c in db.Train
                      where c.Train_Checks == "已通过" && c.Train_Type == "培训" && (SqlMethods.Like(c.Train_Name, "%" + ser + "%") || SqlMethods.Like(c.Train_Id.ToString(), "%" + ser + "%") || SqlMethods.Like(c.Train_Major, "%" + ser + "%"))
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult ENTrain(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            var res = from c in db.Train
                      where c.Train_Checks == "已通过" && c.Train_Type == "企业"
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult ENTrain(int? pageIndex,string a)
        {
            Identity();
            string ser = Request.Form["search"];
            int pagesize = 10;
            var res = from c in db.Train
                      where c.Train_Checks == "已通过" && c.Train_Type == "企业"&&(SqlMethods.Like(c.Train_Name, "%" + ser + "%") || SqlMethods.Like(c.Train_Id.ToString(), "%" + ser + "%")|| SqlMethods.Like(c.Train_Major, "%" + ser + "%"))
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult SCTrain(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            var res = from c in db.Train
                      where c.Train_Checks == "已通过" && c.Train_Type == "学校"
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult SCTrain(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            int pagesize = 10;
            var res = from c in db.Train
                      where c.Train_Checks == "已通过" && c.Train_Type == "学校" && (SqlMethods.Like(c.Train_Name, "%" + ser + "%") || SqlMethods.Like(c.Train_Id.ToString(), "%" + ser + "%") || SqlMethods.Like(c.Train_Major, "%" + ser + "%"))
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        public ActionResult ACTrain()
        {
            Identity();
            return View();
        }
        public ActionResult CKTrain()
        {
            Identity();
            string id = Request.QueryString["Id"];
            var res = from c in db.Train
                      where id == c.Train_Id.ToString()
                      select c;
            StringBuilder ad = new StringBuilder();
            if (db.Train.Where(s=>s.Train_Id==int.Parse(id)).Select(s=>s.Train_State).First().ToString()!="未开始")
            {
                        //                <div class="but-enter">
                        //    <a href="~/Train/JTrain?joinid=@k.Train_Id">加入</a>
                        //</div>
                ad.Append("<div class='but-enter'>");
                ad.Append("<a href='~/Train/JTrain?joinid=@k.Train_Id'>加入</a>");
                ad.Append("</div>");
            }
            return View(res);
        }
        /// <summary>
        /// 新增 加入实训
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult JTrain()
        {
            string id = Request.QueryString["joinid"];
            var res = from c in db.Train
                      where id == c.Train_Id.ToString()
                      select c;
            if (Request.Cookies["Type"] == null)
            {
                Response.Write("<script type='text/javascript'>alert('请先登陆！');</script >");
                return Redirect("~/Login/Login");
            }
            else
            {
                if (int.Parse(Request.Cookies["Type"].Value) != 1)
                {
                    
                    return Redirect("Train/TrainWrong");
                }
                else
                {
                    var newone = db.Student.Where(x => x.student_UserName == Request.Cookies["UserName"].Value).Select(s => s.student_RealName);
                    foreach (var k in newone)
                    {
                        ViewData["User"] = k.ToString();
                    }
                    return View(res);
                }

            }

        }
        /// <summary>
        /// 新增 加入实训
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult JTrain(string s)
        {
            Identity();
            string name = string.Empty;
            JTrain jt = new JTrain();
            string id = Request.QueryString["joinid"];
            var res = from c in db.Train
                      where id == c.Train_Id.ToString()
                      select c;
            jt.Train_Id = int.Parse(Request.Form["TrainID"]);
            jt.Train_Type = Request.Form["Type"];
            jt.Train_Name = Request.Form["Title"];
            jt.Train_OurName = Request.Form["OurName"];
            jt.Leader_ID = db.Student.Where(x => x.student_UserName == Request.Cookies["UserName"].Value).Select(v => v.student_Id).First();
            jt.Team_Num = int.Parse(Request.Form["teamNum"]);
            jt.Join_Time = DateTime.Now;
            jt.Leader_Name = Request.Form["LeaderName"];
            jt.Member_Name = Request.Form["MemberID"];
            var test = db.JTrain.Where(x => x.Train_Id == int.Parse(Request.Form["TrainID"]) && x.Leader_ID == jt.Leader_ID).Select(v => v);
            int i = test.Count();
            if (i > 0)
            {
                Response.Write("<script type='text/javascript'>alert('您已经接受该实训！');</script >");
                return Redirect("~/Train/HADJOIN");
            }
            else
            {
            db.JTrain.InsertOnSubmit(jt);
            db.SubmitChanges();
            return Redirect("~/Train/TrainHome");
            }


        }
        /// <summary>
        /// 企业培训班发布
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PCTrain()

        {
            try
            {
                Identity();
                string Type = Request.Cookies["Type"].Value;
                if (Type == "3")
                {
                    return View();
                }
                else
                {
                    return Redirect("TrainWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PCTrain(string a)
        {
            try
            {
                Identity();
                Train k = new Train();
                k.Train_Type = "培训";
                k.Train_Name = Request.Form["Train_Name"];
                k.Train_Time = DateTime.Now;
                k.Train_State = "未开始";
                k.Train_Publisher = Request.Cookies["UserName"].Value;
                k.Train_Place = Request.Form["Train_Place"];
                k.Train_Major = Request.Form["Train_Major"];
                k.Train_Content = Request.Form["Train_Content"];
                k.Train_Objective = Request.Form["Train_Objective"];
                k.Train_Checks = "待审核";
                k.Train_Date = Request.Form["Train_Date"];
                db.Train.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("TrainWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        /// <summary>
        /// 学校实训
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PSTrain()
        {
            try
            {
                Identity();
                string Type = Request.Cookies["Type"].Value;
                if (Type == "2")
                {
                    return View();
                }
                else
                {
                    return Redirect("TrainWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PSTrain(string a)
        {
            try
            {
                Identity();
                Train k = new Train();
                k.Train_Type = "学校";
                k.Train_Name = Request.Form["Train_Name"];
                k.Train_Time = DateTime.Now;
                k.Train_State = "未开始";
                k.Train_Publisher = Request.Cookies["UserName"].Value;
                k.Train_Place = Request.Form["Train_Place"];
                k.Train_Major = Request.Form["Train_Major"];
                k.Train_Content = Request.Form["Train_Content"];
                k.Train_Objective = Request.Form["Train_Objective"];
                k.Train_Checks = "待审核";
                k.Train_Date = Request.Form["Train_Date"];
                db.Train.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("TrainWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        /// <summary>
        /// 发布企业实训
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PETrain()
        {
            try
            {
                Identity();
                string Type = Request.Cookies["Type"].Value;
                if (Type == "3")
                {
                    return View();
                }
                else
                {
                    return Redirect("TrainWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PETrain(string a)
        {
            try
            {
                Identity();
                Train k = new Train();
                k.Train_Type = "企业";
                k.Train_Name = Request.Form["Train_Name"];
                k.Train_Time = DateTime.Now;
                k.Train_State = "未开始";
                k.Train_Publisher = Request.Cookies["UserName"].Value;
                k.Train_Place = Request.Form["Train_Place"];
                k.Train_Major = Request.Form["Train_Major"];
                k.Train_Content = Request.Form["Train_Content"];
                k.Train_Objective = Request.Form["Train_Objective"];
                k.Train_Checks = "待审核";
                k.Train_Date = Request.Form["Train_Date"];
                db.Train.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("TrainWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }

        public ActionResult PATrain()
        {
            Identity();
            return View();
        }
        /// <summary>
        /// 查看已发布资源
        /// </summary>
        /// <returns></returns>
        public ActionResult MOTrain()
        {
            try
            {
                Identity();
                string Type = Request.Cookies["Type"].Value;
                if (Type == "3"||Type=="2")
                {
                    return View();
                }
                else
                {
                    return Redirect("TrainWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        /// <summary>
        /// 实训/培训班发布后等待
        /// </summary>
        /// <returns></returns>
        public ActionResult TrainWait()
        {
            Identity();
            return View();
        }
        /// <summary>
        /// 权限失败
        /// </summary>
        /// <returns></returns>
        public ActionResult TrainWrong()
        {
            Identity();
            return View();
        }
        public ActionResult MOtrainAccept()
        {
            Identity();
            return View();
        }
        /// <summary>
        /// 查看已发布实训
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MOtrainRelease(int? pageIndex)
        {
            try
            {
                Identity();
                string Type = Request.Cookies["Type"].Value;
                if (Type == "3" || Type == "2")
                {
                    string name = Request.Cookies["UserName"].Value;
                    int pagesize = 10;
                    var res = from c in db.Train
                              where c.Train_Checks == "已通过" && name == c.Train_Publisher
                              select c;
                    ViewData["Num"] = res.Count();
                    PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
                    return View(_res);
                }
                else if(Type=="1")
                {
                    return Redirect("CheckTrain");
                }
                else
                {
                    return Redirect("TrainWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
            
        }
       [HttpPost]
        public ActionResult MOtrainRelease(int? pageIndex, string a)
        {
            Identity();
            //删除操作
            string id = Request.Form["QX"];
            var res1 = from c in db.Train
                       where int.Parse(id) == c.Train_Id
                       select c;
            db.Train.DeleteAllOnSubmit(res1);
            db.SubmitChanges();
            Response.Write("<script type='text/javascript'>alert('删除成功！');</script >");
            //数据显示
            string name = Request.Cookies["UserName"].Value;
            int pagesize = 10;
            var res = from c in db.Train
                      where c.Train_Checks == "已通过" && name==c.Train_Publisher
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Train> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        /// <summary>
        /// 修改已发布实训
        /// </summary>
        /// <returns></returns>
       [HttpGet]
       public ActionResult MKTrain()
       {
           Identity();
           string Id = Request.QueryString["Id"];
           string name = Request.Cookies["UserName"].Value;
           string Type = Request.Cookies["Type"].Value;
           if (Type == "3"||Type=="2")
           {
               var res = from c in db.Train
                         where c.Train_Id == int.Parse(Id)
                         select c;
               return View(res);
           }
           else
               return Redirect("TrainWrong");
       }
       [HttpPost]
       public ActionResult MKTrain(string a)
       {
           Identity();
           try
           {
               string name = Request.Cookies["UserName"].Value;
               string Type = Request.Cookies["Type"].Value;
               string Id = Request.QueryString["Id"];
               var res = from c in db.Train
                         where c.Train_Id == int.Parse(Id)
                         select c;
               foreach (var k in res)
               {
                   k.Train_Name = Request.Form["Train_Name"];
                   k.Train_Objective = Request.Form["Train_Objective"];
                   k.Train_Content = Request.Form["Train_Content"];
                   k.Train_Major = Request.Form["Train_Major"];
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
        /// <summary>
        /// 新增 重复加入提示
        /// </summary>
        /// <returns></returns>
        public ActionResult HADJOIN()
       {
           Identity();
           return View();
       }
        /// <summary>
        /// 新增 学生查看接受的实训
        /// </summary>
        /// <returns></returns>
       [HttpGet]
        public ActionResult CheckTrain(int?pageIndex)
        {
            Identity();
            string name = Request.Cookies["UserName"].Value;
            int pagesize = 10;
            int r = db.Student.Where(x => x.student_UserName == Request.Cookies["UserName"].Value).Select(v => v.student_Id).First();
            var res = db.JTrain.Where(x => x.Leader_ID == r).Select(x => x);
            ViewData["Num"] = res.Count();
            PagedList<JTrain> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);

        }
        [HttpPost]
        public ActionResult CheckTrain(int?pageIndex,string a)
       {
           Identity();
           //删除操作
           string id = Request.Form["QX"];
           var res1 = db.JTrain.Where(x => x.id == int.Parse(id)).Select(x => x);
           db.JTrain.DeleteAllOnSubmit(res1);
           db.SubmitChanges();
           Response.Write("<script type='text/javascript'>alert('删除成功！');</script >");
           //数据显示
           string name = Request.Cookies["UserName"].Value;
           int pagesize = 10;
           int r = db.Student.Where(x => x.student_UserName == Request.Cookies["UserName"].Value).Select(v => v.student_Id).First();
           var res = db.JTrain.Where(x => x.Leader_ID == r).Select(x => x);
           ViewData["Num"] = res.Count();
           PagedList<JTrain> _res = res.ToPagedList(pageIndex, pagesize);
           return View(_res);
       }
        /// <summary>
        /// 新增 修改加入的实训
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ChangeJoin()
        {
            Identity();
            var newone = db.Student.Where(x => x.student_UserName == Request.Cookies["UserName"].Value).Select(s => s.student_RealName);
            foreach (var k in newone)
            {
                ViewData["User"] = k.ToString();
            } 
            string Id = Request.QueryString["joinid"];
            string name = Request.Cookies["UserName"].Value;
            string Type = Request.Cookies["Type"].Value;
            if (Type == "1")
            {
                int r = db.Student.Where(x => x.student_UserName == Request.Cookies["UserName"].Value).Select(v => v.student_Id).First();
                var res = db.JTrain.Where(x => x.Leader_ID == r).Select(x => x);
                return View(res);
            }
            else
                return Redirect("TrainWrong");
        }
        [HttpPost]
        public ActionResult ChangeJoin(string a)
        {
            Identity();
            try
            {
                int r = db.Student.Where(x => x.student_UserName == Request.Cookies["UserName"].Value).Select(v => v.student_Id).First();
                var res = db.JTrain.Where(x => x.Leader_ID == r).Select(x => x);
                string Id = Request.QueryString["Id"];
                foreach (var jt in res)
                {
                    jt.Train_OurName = Request.Form["OurName"];
                    jt.Team_Num = int.Parse(Request.Form["teamNum"]);
                    jt.Member_Name = Request.Form["MemberID"];
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
