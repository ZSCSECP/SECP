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
    public class EnterpriseController : Controller
    {
        //
        // GET: /Enterprise/
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
        public ActionResult EnterpriseHome()
        {
            Identity();
            return View();
        }
        [HttpGet]
        public ActionResult INEnterprise(int? pageIndex)
        {
            Identity();
            int pagesize = 10;
            var res = from c in db.Enterprise
                      where c.Enterprise_Checks=="已通过"
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Enterprise> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult INEnterprise(int? pageIndex,string a)
        {
            Identity();
            string ser = Request.Form["search"];
            int pagesize = 10;
            var res = from c in db.Enterprise
                      where c.Enterprise_Checks == "已通过" && (SqlMethods.Like(c.Enterprise_Place, "%" + ser + "%") || SqlMethods.Like(c.Enterprise_Id.ToString(), "%" + ser + "%") || SqlMethods.Like(c.Enterprise_Industry, "%" + ser + "%"))
                      select c;
            ViewData["Num"] = res.Count();
            PagedList<Enterprise> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult EPEnterprise(int? pageIndex)
        {
            Identity();
            var res = from c in db.Products
                      where c.Products_Checks == "已通过"
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Products> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpPost]
        public ActionResult EPEnterprise(int? pageIndex, string a)
        {
            Identity();
            string ser = Request.Form["search"];
            var res = from c in db.Products
                      where c.Products_Checks == "已通过"  && (SqlMethods.Like(c.Products_Theme, "%" + ser + "%") || SqlMethods.Like(c.Products_Type, "%" + ser + "%") || SqlMethods.Like(c.Products_Number, "%" + ser + "%") || SqlMethods.Like(c.Products_Id.ToString(), "%" + ser + "%"))
                      select c;
            int pagesize = 10;
            ViewData["Num"] = res.Count();
            PagedList<Products> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        public ActionResult PAEnterprise()
        {
            Identity();
            return View();
        }
        public ActionResult REEnterprise()
        {
            Identity();
            return View();
        }
        public ActionResult PIEnterprise()
        {
            Identity();
            return View();
        }
        [HttpGet]
        public ActionResult PEEnterprise()
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
                    return Redirect("EnterpriseWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult PEEnterprise(string a)
        {
            try
            {
                Identity();
                Products k = new Products();
                k.Products_Type = Request.Form["Products_Type"];
                k.Products_Time = DateTime.Now;
                k.Products_Publisher = Request.Cookies["UserName"].Value;
                k.Products_Theme = Request.Form["Products_Theme"];
                k.Products_Number = Request.Form["Products_Number"];
                k.Products_contact = Request.Form["Products_contact"];
                k.Products_Money = Request.Form["Products_Money"];
                k.Products_Checks = "待审核";
                db.Products.InsertOnSubmit(k);
                db.SubmitChanges();
                return Redirect("EnterpriseWait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        public ActionResult PPEnterprise()
        {
            Identity();
            return View();
        }
        public ActionResult PREnterprise()
        {
            Identity();
            return View();
        }
        public ActionResult MOEnterprise()
        {
            Identity();
            return View();
        }
        public ActionResult CKEnterprise()
        {
            Identity();
            string id = Request.QueryString["Id"];
            var res = from c in db.Enterprise
                      where c.Enterprise_Id == int.Parse(id)
                      select c;
            return View(res);
        }
        public ActionResult CKEnterpriseproduct()
        {
            Identity();
            string id = Request.QueryString["Id"];
            var res = from c in db.Products
                      where c.Products_Id == int.Parse(id)
                      select c;
            string pl="";
            foreach(var k in res)
            {
                pl = k.Products_Publisher;
            }
            var res1=from c in db.Enterprise
                     where c.Enterprise_UserName==pl
                     select c;
            foreach(var s in res1)
            {
               ViewData["Tel"]=s.Enterprise_Tel;
            }
            return View(res);
        }
        [HttpGet]
        public ActionResult EnterpriseWait()
        {
            Identity();
            return View();
        }
        [HttpPost]
        public ActionResult EnterpriseWait(string a)
        {
            return Redirect("EnterpriseHome");
        }
        public ActionResult EnterpriseWrong()
        {
            Identity();
            return View();
        }
        [HttpGet]
        public ActionResult MOEnterpriseAccept(int? pageIndex)
        {
            try
            {
                Identity();
                string Type = Request.Cookies["Type"].Value;
                string name= Request.Cookies["UserName"].Value;
                int pagesize = 10;
                if (Type == "3")
                {
                    var res = from c in db.Products
                              where c.Products_Publisher == name
                              select c;
                    ViewData["Q"] = res.Count();
                    PagedList<Products> _res = res.ToPagedList(pageIndex, pagesize);
                    return View(_res);
                }
                else
                {
                    return Redirect("EnterpriseWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        public ActionResult MOEnterpriseAccept(int? pageIndex, string a)
        {
            Identity();
            string Type = Request.Cookies["Type"].Value;
            string name = Request.Cookies["UserName"].Value;

            //删除操作
            string id = Request.Form["QX"];
            //删除操作
            var re = from c in db.Products
                     where int.Parse(id) == c.Products_Id
                     select c;
            db.Products.DeleteAllOnSubmit(re);
            db.SubmitChanges();
            Response.Write("<script type='text/javascript'>alert('删除数据成功！');</script >");

            //显示数据
            int pagesize = 10;
            var res = from c in db.Products
                      where c.Products_Publisher == name
                      select c;
            ViewData["Q"] = res.Count();
            PagedList<Products> _res = res.ToPagedList(pageIndex, pagesize);
            return View(_res);
        }
        [HttpGet]
        public ActionResult MKproduct()
        {
            try
            {
                Identity();
                string Id = Request.QueryString["Id"];
                string name = Request.Cookies["UserName"].Value;
                string Type = Request.Cookies["Type"].Value;
                if (Type == "3" || Type == "2")
                {
                    var res = from c in db.Products
                              where c.Products_Id == int.Parse(Id)
                              select c;
                    var res1 = from c in db.Enterprise
                               where c.Enterprise_UserName == name
                               select c;

                    foreach (var k in res1)
                    {
                        ViewData["Tel"] = k.Enterprise_Tel;
                    }
                    return View(res);
                }
                else
                {
                    return Redirect("EnterpriseWrong");
                }
            }
            catch
            {
                return Redirect("../Login/Login");
            }
        }
        [HttpPost]
        public ActionResult MKproduct(string a)
        {
            try
            {
                Identity();
                string Id = Request.QueryString["Id"];
                var res = from c in db.Products
                          where c.Products_Id == int.Parse(Id)
                          select c;
                foreach (var k in res)
                {
                    k.Products_contact = Request.Form["Products_contact"];
                    k.Products_Money = Request.Form["Products_Money"];
                    k.Products_Theme = Request.Form["Products_Theme"];
                    k.Products_Number = Request.Form["Products_Number"];
                    k.Products_Type = Request.Form["Products_Type"];
                }
                db.SubmitChanges();
                Response.Write("<script type='text/javascript'>alert('修改数据成功！');</script >");
                return View(res);
            }
            catch {
                Identity();
                string Id = Request.QueryString["Id"];
                var res = from c in db.Products
                          where c.Products_Id == int.Parse(Id)
                          select c;
                Response.Write("<script type='text/javascript'>alert('修改数据失败！');</script >");
                return View(res);
            }
        }
    }
}
