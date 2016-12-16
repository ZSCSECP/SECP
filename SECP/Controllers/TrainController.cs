using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;
using System.Data.Linq.SqlClient;
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
            return View(res);
        }
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
        public ActionResult TrainWait()
        {
            Identity();
            return View();
        }
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
       public ActionResult MJoinJob()
       {
           Identity();

           return View();
       }
        [HttpPost]
       public ActionResult MJoinJOb(string a)
       {
           return View();
       }
    }
}
