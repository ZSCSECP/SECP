using SECP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SECP.Controllers
{
    public class GovermentController : Controller
    {
        //
        // GET: /Goverment/
        SECPDataContext db = new SECP.Models.SECPDataContext();
        public void Identity()//需要VIEW页面存在相应的显示信息
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
        //public ActionResult Index()
        //{
        //    var contente = from a in db.SimpleInfo
        //                   select new
        //                   {
        //                       a.Title
        //                   };
        //    ViewData["scroll"] = contente.First().ToString();
        //    return View(contente);
        //}
        //    //
        //    // GET: /News/

        //    public ActionResult News()
        //    {
        //        return View();
        //    }

        //}
        [HttpGet]
        public ActionResult TechHome()
        {
            Identity();
            return View();
        }
        public ActionResult GTechInfo()
        {
            Identity();
            ShowAll all = new ShowAll();
            return View(all);
        }
        [HttpGet]
        public ActionResult TechInfoEnter()//信息录入
        {
            try
            {
                if (Request.Cookies["Type"] == null)
                {
                    Response.Write("<script type='text/javascript'>alert('请先登陆！');</script >");
                    return Redirect("~/Login/Login");
                }
                else
                {
                    if (Request.Cookies["Type"].Value == "6")
                    {
                        Identity();
                        return View();
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alter('抱歉！你没有信息录入权限');</script>");
                        return Redirect("Goverment/GWrong");
                    }

                }
            }
            catch
            {
                return Redirect("~/Login/Login");
            }
        }
        [HttpPost]
        public ActionResult TechInfoEnter(string a, HttpPostedFileBase submitImg)//信息录入
        {
            Identity();
            //   try
            //   {

            SimpleInfo sp = new SimpleInfo();
            sp.Title = Request.Form["Title"];
            sp.BriefInfo = Request.Form["BriefInfo"];
            sp.LinkUrl = "Http://" + Request.Form["LinkUrl"];
            sp.PublishDate = DateTime.Now;
            if (submitImg.FileName != null)
            {
                string file = System.IO.Path.GetFileName(submitImg.FileName);
                string physical = Server.MapPath("~/images/SimpleInfo/" + file);
                submitImg.SaveAs(physical);
                sp.ImageUrl = physical;
            }
            else sp.ImageUrl = "NULL";
            sp.Category1 = int.Parse(Request.Form["category_1"]);
            sp.Category2 = int.Parse(Request.Form["category_2"]);
            db.SimpleInfo.InsertOnSubmit(sp);
            db.SubmitChanges();
            Response.Write("<script type='text/javascript'>alter('录入成功！');</script>");
            return View();
            //}
            //catch
            //{
            //    return Redirect("~/Login/Login");
            //}
        }
        [HttpGet]
        public ActionResult GStatic(int? pageIndex)//科技动态
        {
            Identity();
            int pagesize = 10;
            PagedList<SimpleInfo> _pro;
            if (Request.QueryString["type"] != null)
            {
                ViewData["tle"] = "";
                if (int.Parse(Request.QueryString["type"]) == 1)
                {
                    ViewData["tle"] = "要闻";
                }
                if (int.Parse(Request.QueryString["type"]) == 2)
                {
                    ViewData["tle"] = "图片新闻";
                }
                if (int.Parse(Request.QueryString["type"]) == 3)
                {
                    ViewData["tle"] = "地方科技工作";
                }
                if (int.Parse(Request.QueryString["type"]) == 4)
                {
                    ViewData["tle"] = "科技部工作";
                }
                if (int.Parse(Request.QueryString["type"]) == 5)
                {
                    ViewData["tle"] = "国内外科技工作";
                }          
                int nowy = int.Parse(Request.QueryString["type"]);
                var content = db.SimpleInfo.Where(x => x.Category1 == 2 && x.Category2 == nowy).Select(x => x);
                _pro = content.ToPagedList(pageIndex, pagesize);
            }
            else
            {
                var content = db.SimpleInfo.Where(x => x.Category1 == 2 && x.Category2 == 0).Select(x => x);
                _pro = content.ToPagedList(pageIndex, pagesize);
            }
            return View(_pro);
        }
        [HttpPost]
        public ActionResult GStatic(int? pageIndex, string tyoe)//科技动态
        {
            int nowy = int.Parse(Request.QueryString["type"]);
            Identity();
            int pagesize = 10;
            var content = db.SimpleInfo.Where(x => x.Category1 == 2 && x.Category2 == nowy).Select(x => x);
            PagedList<SimpleInfo> _pro = content.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        [HttpGet]
        public ActionResult GSTPolicy(int? pageIndex)//科技政策
        {
            Identity();
            int pagesize = 10;
            PagedList<SimpleInfo> _pro;
            if (Request.QueryString["type"] != null)
            {
                ViewData["zc"] = "";
                if(int.Parse(Request.QueryString["type"])==0)
                {
                    ViewData["zc"] = "地方科技政策";
                }
                if(int.Parse(Request.QueryString["type"])==1)
                {
                    ViewData["zc"] = "国家科技政策";
                }
                int nowy = int.Parse(Request.QueryString["type"]);
                    var content = db.SimpleInfo.Where(x => x.Category1 == 0 && x.Category2 == nowy).Select(x => x);
                    _pro = content.ToPagedList(pageIndex, pagesize);
            }
            else
            {
                ViewData["zc"] = "地方科技政策";
                var content = db.SimpleInfo.Where(x => x.Category1 == 0 && x.Category2 == 0).Select(x => x);
                _pro = content.ToPagedList(pageIndex, pagesize);
            }
            return View(_pro);
        }
        [HttpPost]
        public ActionResult GSTPolicy(int? pageIndex, string tyoe)//科技政策~
        {
            int nowy = int.Parse(Request.QueryString["type"]);
            Identity();
            int pagesize = 10;
            var content = db.SimpleInfo.Where(x => x.Category1 == 0 && x.Category2 == nowy).Select(x => x);
            PagedList<SimpleInfo> _pro = content.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        [HttpGet]
        public ActionResult GTechnologyPublish(int? pageIndex)//信息公开~
        {
           
            Identity();
            return View();
            
        }
        [HttpGet]
        public ActionResult GTEPublish(int? pageIndex, string tyoe)//信息公开~
        {
            Identity();
            int pagesize = 10;
            var content = db.SimpleInfo.Where(x => x.Category1 == 1 && x.Category2 == 1).Select(x => x);
            PagedList<SimpleInfo> _pro = content.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        [HttpGet]
        public ActionResult Gwrong()//错误跳转
        {
            Identity();
            return View();
        }
    }
}
