using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;

namespace SECP.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        /// <summary>
        /// 平台主页现实，判断用户身份并显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ProjectHome()
        {
            ViewData["H"] = "current_page_item";
            ViewData["Q"] = ViewData["S"] = ViewData["Z"] = ViewData["W"] = ViewData["X"] = "Sub";
            Identity();
            return View();
        }
        /// <summary>
        /// 查看企业项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CEProject(int? pageIndex)
        {
            ViewData["Q"] = "current_page_item";
            ViewData["H"] = ViewData["S"] = ViewData["Z"] = ViewData["W"] = ViewData["X"] = "Sub";
            SECPDataContext db = new SECPDataContext();
            Identity();
            string time = Request.QueryString["Ftime"];
            string re = Request.QueryString["Re"];
            string ktime = Request.QueryString["Ktime"];
            string money = Request.QueryString["Money"];
            //string Type = Request.QueryString["Type"];
            int pagesize = 10;
            int Time;
            string Re;
            int Ktime;
            int Money;
            if (time == "1") Time = 90;
            else if (time == "2") Time = 180;
            else if (time == "3") Time = 360;
            else if (time == "4") Time = 360;
            else { Time = 0; }

            if (re == "5") Re = "无需经验";
            else if (re == "6") Re = "半年";
            else if (re == "7") Re = "1年";
            else if (re == "8") Re = "2年及以上";
            else { Re = null; }

            if (ktime == "9") Ktime = 30;
            else if (ktime == "10") Ktime = 90;
            else if (ktime == "11") Ktime = 180;
            else if (ktime == "12") Ktime = 180;
            else { Ktime = 0; }

            if (money == "13") Money = 500;
            else if (money == "14") Money = 1000;
            else if (money == "15") Money = 5000;
            else if (money == "16") Money = 5000;
            else { Money = 0; }

            if (Time != 0 && time != "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else if (time == "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "企业" && c.Project_Checks == "已通过"
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult CEProject(int? pageIndex, string a)
        {
            ViewData["Q"] = "current_page_item";
            ViewData["H"] = ViewData["S"] = ViewData["Z"] = ViewData["W"] = ViewData["X"] = "Sub";
            Identity();
            string ser = Request.Form["search"];
            SECPDataContext db = new SECPDataContext();
            int pagesize = 10;
            var res = from c in db.Project
                      where c.Project_Type == "企业" && c.Project_Checks == "已通过" && c.Project_Checks == "已通过" && SqlMethods.Like(c.Project_Name, "%" + ser + "%")
                      select c;
            ViewData["num"] = res.Count();
            PagedList<Project> _pro = res.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        /// <summary>
        /// 发布企业项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PEProject()
        {
            if (Request.Cookies["Type"] == null)
            {
                return Redirect("Wrong");
            }
            else
            {
                if (Request.Cookies["Type"].Value == "3")
                {
                    Identity();
                    return View();
                }
                else
                {
                    return Redirect("Wrong");
                }
            }
        }
        [HttpPost]
        public ActionResult PEProject(string  a)
        {
            Identity();
            try
            {
                SECPDataContext db = new SECPDataContext();
                Project pr = new Project();
                pr.Project_Name = Request.Form["Project_Name"];
                pr.Project_Money = int.Parse(Request.Form["Project_Money"]);
                pr.Project_Contact = Request.Form["Project_Contact"];
                pr.Project_Content = Request.Form["Project_Content"];
                pr.Project_Type = "企业";
                pr.Project_TimeLimeit = int.Parse(Request.Form["Project_TimeLimeit"]);
                pr.Project_STime = DateTime.Now;
                pr.Project_State = "待接";
                pr.Project_Requirement = Request.Form["Requirement"];
                pr.Project_PubilsherType = "企业";
                pr.Project_Publisher = Request.Cookies["UserName"].Value;
                pr.Project_Sendee = "";
                pr.Project_SendeeType = "";
                pr.Project_Checks = "待审核";
                db.Project.InsertOnSubmit(pr);
                db.SubmitChanges();
                return Redirect("Wait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        /// <summary>
        /// 查看师生项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CSProject(int? pageIndex)
        {
            ViewData["S"] = "current_page_item";
            ViewData["H"] = ViewData["Q"] = ViewData["Z"] = ViewData["W"] = ViewData["X"] = "Sub";
            SECPDataContext db = new SECPDataContext();
            Identity();
            string time = Request.QueryString["Ftime"];
            string re = Request.QueryString["Re"];
            string ktime = Request.QueryString["Ktime"];
            string money = Request.QueryString["Money"];
            //string Type = Request.QueryString["Type"];
            int pagesize = 10;
            int Time;
            string Re;
            int Ktime;
            int Money;
            if (time == "1") Time = 90;
            else if (time == "2") Time = 180;
            else if (time == "3") Time = 360;
            else if (time == "4") Time = 360;
            else { Time = 0; }

            if (re == "5") Re = "无需经验";
            else if (re == "6") Re = "半年";
            else if (re == "7") Re = "1年";
            else if (re == "8") Re = "2年及以上";
            else { Re = null; }

            if (ktime == "9") Ktime = 30;
            else if (ktime == "10") Ktime = 90;
            else if (ktime == "11") Ktime = 180;
            else if (ktime == "12") Ktime = 180;
            else { Ktime = 0; }

            if (money == "13") Money = 500;
            else if (money == "14") Money = 1000;
            else if (money == "15") Money = 5000;
            else if (money == "16") Money = 5000;
            else { Money = 0; }

            if (Time != 0 && time != "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else if (time == "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "师生" && c.Project_Checks == "已通过"
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult CSProject(int? pageIndex, string a)
        {
            ViewData["S"] = "current_page_item";
            ViewData["H"] = ViewData["Q"] = ViewData["Z"] = ViewData["W"] = ViewData["X"] = "Sub";
            Identity();
            string ser = Request.Form["search"];
            SECPDataContext db = new SECPDataContext();
            int pagesize = 10;
            var res = from c in db.Project
                      where c.Project_Type == "师生" && c.Project_Checks == "已通过" && c.Project_Checks == "已通过" && SqlMethods.Like(c.Project_Name, "%" + ser + "%")
                      select c;
            ViewData["num"] = res.Count();
            PagedList<Project> _pro = res.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        /// <summary>
        /// 发布师生项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PSProject()
        {
            if (Request.Cookies["Type"] == null)
            {
                return Redirect("Wrong");
            }
            else
            {
                if (Request.Cookies["Type"].Value == "2")
                {
                    Identity();
                    return View();
                }
                else
                {
                    return Redirect("Wrong");
                }
            }
        }
        [HttpPost]
        public ActionResult PSProject(string a)
        {
            Identity();
            try
            {
                SECPDataContext db = new SECPDataContext();
                Project pr = new Project();
                pr.Project_Name = Request.Form["Project_Name"];
                pr.Project_Money = int.Parse(Request.Form["Project_Money"]);
                pr.Project_Contact = Request.Form["Project_Contact"];
                pr.Project_Content = Request.Form["Project_Content"];
                pr.Project_Type = "师生";
                pr.Project_TimeLimeit = int.Parse(Request.Form["Project_TimeLimeit"]);
                pr.Project_STime = DateTime.Now;
                pr.Project_State = "待接";
                pr.Project_Requirement = Request.Form["Requirement"];
                pr.Project_PubilsherType = "教师";
                pr.Project_Publisher = Request.Cookies["UserName"].Value;
                pr.Project_Sendee = "";
                pr.Project_SendeeType = "";
                pr.Project_Checks = "待审核";
                db.Project.InsertOnSubmit(pr);
                db.SubmitChanges();
                return Redirect("Wait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        /// <summary>
        /// 查看合作项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CCProject(int? pageIndex)
        {
            ViewData["Z"] = "current_page_item";
            ViewData["H"] = ViewData["Q"] = ViewData["S"] = ViewData["W"] = ViewData["X"] = "Sub";
            SECPDataContext db = new SECPDataContext();
            Identity();
            string time = Request.QueryString["Ftime"];
            string re = Request.QueryString["Re"];
            string ktime = Request.QueryString["Ktime"];
            string money = Request.QueryString["Money"];
            //string Type = Request.QueryString["Type"];
            int pagesize = 10;
            int Time;
            string Re;
            int Ktime;
            int Money;
            if (time == "1") Time = 90;
            else if (time == "2") Time = 180;
            else if (time == "3") Time = 360;
            else if (time == "4") Time = 360;
            else { Time = 0; }

            if (re == "5") Re = "无需经验";
            else if (re == "6") Re = "半年";
            else if (re == "7") Re = "1年";
            else if (re == "8") Re = "2年及以上";
            else { Re = null; }

            if (ktime == "9") Ktime = 30;
            else if (ktime == "10") Ktime = 90;
            else if (ktime == "11") Ktime = 180;
            else if (ktime == "12") Ktime = 180;
            else { Ktime = 0; }

            if (money == "13") Money = 500;
            else if (money == "14") Money = 1000;
            else if (money == "15") Money = 5000;
            else if (money == "16") Money = 5000;
            else { Money = 0; }

            if (Time != 0 && time != "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else if (time == "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过" && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "合作" && c.Project_Checks == "已通过"
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult CCProject(string a, int? pageIndex)
        {
            ViewData["Z"] = "current_page_item";
            ViewData["H"] = ViewData["Q"] = ViewData["S"] = ViewData["W"] = ViewData["X"] = "Sub";
            Identity();
            string ser = Request.Form["search"];
            SECPDataContext db = new SECPDataContext();
            int pagesize = 10;
            var res = from c in db.Project
                      where c.Project_Type == "合作" && c.Project_Checks == "已通过" && SqlMethods.Like(c.Project_Name, "%" + ser + "%")
                      select c;
            ViewData["num"] = res.Count();
            PagedList<Project> _pro = res.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        /// <summary>
        /// 发布合作项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PCProject()
        {
            if (Request.Cookies["Type"] == null)
            {
                return Redirect("Wrong");
            }
            else
            {
                if (Request.Cookies["Type"].Value == "3")
                {
                    Identity();
                    return View();
                }
                else
                {
                    return Redirect("Wrong");
                }
            }
        }
        [HttpPost]
        public ActionResult PCProject(string a)
        {
            Identity();
            try
            {
                SECPDataContext db = new SECPDataContext();
                Project pr = new Project();
                pr.Project_Name = Request.Form["Project_Name"];
                pr.Project_Money = int.Parse(Request.Form["Project_Money"]);
                pr.Project_Contact = Request.Form["Project_Contact"];
                pr.Project_Content = Request.Form["Project_Content"];
                pr.Project_Type = "合作";
                pr.Project_TimeLimeit = int.Parse(Request.Form["Project_TimeLimeit"]);
                pr.Project_STime = DateTime.Now;
                pr.Project_State = "待接";
                pr.Project_Requirement = Request.Form["Requirement"];
                pr.Project_PubilsherType = "合作";
                pr.Project_Publisher = Request.Cookies["UserName"].Value;
                pr.Project_Sendee = "";
                pr.Project_SendeeType = "";
                pr.Project_Checks = "待审核";
                db.Project.InsertOnSubmit(pr);
                db.SubmitChanges();
                return Redirect("Wait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        /// <summary>
        /// 查看外包项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult COProject(int? pageIndex)
        {
            ViewData["W"] = "current_page_item";
            ViewData["H"] = ViewData["Q"] = ViewData["S"] = ViewData["Z"] = ViewData["X"] = "Sub";
            SECPDataContext db = new SECPDataContext();
            Identity();
            string time = Request.QueryString["Ftime"];
            string re = Request.QueryString["Re"];
            string ktime = Request.QueryString["Ktime"];
            string money = Request.QueryString["Money"];
            //string Type = Request.QueryString["Type"];
            int pagesize = 10;
            int Time;
            string Re;
            int Ktime;
            int Money;
            if (time == "1") Time = 90;
            else if (time == "2") Time = 180;
            else if (time == "3") Time = 360;
            else if (time == "4") Time = 360;
            else { Time = 0; }

            if (re == "5") Re = "无需经验";
            else if (re == "6") Re = "半年";
            else if (re == "7") Re = "1年";
            else if (re == "8") Re = "2年及以上";
            else { Re = null; }

            if (ktime == "9") Ktime = 30;
            else if (ktime == "10") Ktime = 90;
            else if (ktime == "11") Ktime = 180;
            else if (ktime == "12") Ktime = 180;
            else { Ktime = 0; }

            if (money == "13") Money = 500;
            else if (money == "14") Money = 1000;
            else if (money == "15") Money = 5000;
            else if (money == "16") Money = 5000;
            else { Money = 0; }

            if (Time != 0 && time != "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days <= Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else if (time == "4")
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && (DateTime.Now - c.Project_STime).Days > Time
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
            else
            {
                if (Re != null)
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Requirement == Re
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
                else
                {
                    if (Ktime != 0 && ktime != "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_TimeLimeit <= Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else if (ktime == "12")
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_TimeLimeit > Ktime
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                    else
                    {
                        if (Money != 0 && money != "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Money <= Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else if (money == "16")
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过" && c.Project_Money > Money
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                        else
                        {
                            var k = from c in db.Project
                                    where c.Project_Type == "外包" && c.Project_Checks == "已通过"
                                    select c;
                            ViewData["num"] = k.Count();
                            PagedList<Project> _pro = k.ToPagedList(pageIndex, pagesize);
                            return View(_pro);
                        }
                    }
                }
            }
        }
        [HttpPost]
        public ActionResult COProject(int? pageIndex, string a)
        {
            ViewData["W"] = "current_page_item";
            ViewData["H"] = ViewData["Q"] = ViewData["S"] = ViewData["Z"] = ViewData["X"] = "Sub";
            Identity();
            string ser = Request.Form["search"];
            SECPDataContext db = new SECPDataContext();
            int pagesize = 10;
            var res = from c in db.Project
                      where c.Project_Type == "外包" && c.Project_Checks == "已通过" && SqlMethods.Like(c.Project_Name, "%" + ser + "%")
                      select c;
            ViewData["num"] = res.Count();
            PagedList<Project> _pro = res.ToPagedList(pageIndex, pagesize);
            return View(_pro);
        }
        /// <summary>
        /// 发布外包项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult POProject()
        {
            if (Request.Cookies["Type"] == null)
            {
                return Redirect("Wrong");
            }
            else
            {
                if (Request.Cookies["Type"].Value == "4")
                {
                    Identity();
                    return View();
                }
                else
                {
                    return Redirect("Wrong");
                }
            }
        }
        [HttpPost]
        public ActionResult POProject(string a)
        {
            Identity();
            try
            {
                SECPDataContext db = new SECPDataContext();
                Project pr = new Project();
                pr.Project_Name = Request.Form["Project_Name"];
                pr.Project_Money = int.Parse(Request.Form["Project_Money"]);
                pr.Project_Contact = Request.Form["Project_Contact"];
                pr.Project_Content = Request.Form["Project_Content"];
                pr.Project_Type = "外包";
                pr.Project_TimeLimeit = int.Parse(Request.Form["Project_TimeLimeit"]);
                pr.Project_STime = DateTime.Now;
                pr.Project_State = "待接";
                pr.Project_Requirement = Request.Form["Requirement"];
                pr.Project_PubilsherType = "外包";
                pr.Project_Publisher = Request.Cookies["UserName"].Value;
                pr.Project_Sendee = "";
                pr.Project_SendeeType = "";
                pr.Project_Checks = "待审核";
                db.Project.InsertOnSubmit(pr);
                db.SubmitChanges();
                return Redirect("Wait");
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('发布失败!请审核您的输入信息是否有错！');</script >");
                return View();
            }
        }
        /// <summary>
        /// 项目展示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MOProject()
        {
            try
            {
                Identity();
                SECPDataContext db = new SECPDataContext();
                string name = Request.Cookies["UserName"].Value;
                string Id = Request.Cookies["Type"].Value;
                string Type;
                if (Id == "1")
                {
                    Type = "学生";
                }
                else if (Id == "2")
                {
                    Type = "教师";
                }
                else if (Id == "3")
                {
                    Type = "企业";
                }
                else if (Id == "4")
                {
                    Type = "用户";
                }
                else
                {
                    Type = "游客";
                }
                var res = from c in db.Project
                          where c.Project_Sendee == name && c.Project_SendeeType == Type
                          select c;
                ViewData["JS"] = res.Count();
                var res1 = from c in db.Project
                           where c.Project_Publisher == name && c.Project_PubilsherType == Type
                           select c;
                ViewData["FB"] = res1.Count();
                return View();
            }
            catch
            {
                return Redirect("~/Login/Login");
            }
        }
        [HttpPost]
        public ActionResult MOProject(string QX,string XQ)
        {
            if (QX != null)
            {
                Identity();
                SECPDataContext db = new SECPDataContext();
                string name = Request.Cookies["UserName"].Value;
                string Id = Request.Cookies["Type"].Value;
                var res = from c in db.Project
                          where QX == c.Project_Id.ToString()
                          select c;
                ViewData["FB"] = res.Count();
                foreach (var k in res)
                {
                    k.Project_Sendee = "";
                    k.Project_SendeeType = "";
                    k.Project_State = "待接";
                    db.SubmitChanges();
                }
                Response.Write("<script type='text/javascript'>alert('取消成功');</script >");
                return View();
            }
            else
            {
                //识别身份
                Identity();
                SECPDataContext db = new SECPDataContext();
                //读取身份
                string name = Request.Cookies["UserName"].Value;
                string Id = Request.Cookies["Type"].Value;
                //删除操作开始,因为接项目和发布项目都在同一条记录，因此删除操作双向有效
                var res = from c in db.Project
                          where name == c.Project_Publisher && XQ == c.Project_Id.ToString()
                          select c;
                db.Project.DeleteAllOnSubmit(res);
                db.SubmitChanges();
                var res1 = from c in db.Project
                          where name == c.Project_Publisher
                          select c;
                ViewData["JS"] = res1;
                Response.Write("<script type='text/javascript'>alert('删除成功');</script >");
                return View();
            }
        }
        /// <summary>
        /// 判断当前身份
        /// </summary>
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
        /// <summary>
        /// 发布完成等待页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Wait()
        {
            Identity();
            return View();
        }
        [HttpPost]
        public ActionResult Wait(string a)
        {
            return Redirect("ProjectHome");
        }
        /// <summary>
        /// 权限不足显示页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Wrong()
        {
            Identity();
            return View();
        }
        /// <summary>
        /// 修改密码页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CKProject()
        {
            Identity();
            string Id = Request.QueryString["Id"];
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.Project
                      where c.Project_Id == int.Parse(Id)
                      select c;
            return View(res);
        }
        [HttpPost]
        public ActionResult CKProject(string a)
        {
            try
            {
                Identity();
                string Id = Request.QueryString["Id"];
                string name = Request.Cookies["UserName"].Value;
                string Type = Request.Cookies["Type"].Value;
                SECPDataContext db = new SECPDataContext();
                if (Type == "1" || Type == "2")
                {
                    string Type1;
                    if (Type == "1")
                    { Type1 = "学生"; }
                    else
                    { Type1 = "教师"; }
                    var k = from c in db.Project
                            where Id == c.Project_Id.ToString() && c.Project_State == "待接"
                            select c;
                    if (k.Count() != 0)
                    {
                        var s = from c in db.Project
                                where Id == c.Project_Id.ToString()
                                select c;
                        foreach (var ss in s)
                        {
                            ss.Project_Sendee = name;
                            ss.Project_SendeeType = Type1;
                            ss.Project_State = "已接";
                            db.SubmitChanges();
                        }
                        var res = from c in db.Project
                                  where c.Project_Id == int.Parse(Id)
                                  select c;
                        Response.Write("<script type='text/javascript'>alert('接受成功！');</script >");
                        return View(res);
                    }
                    else
                    {
                        var res = from c in db.Project
                                  where c.Project_Id == int.Parse(Id)
                                  select c;
                        Response.Write("<script type='text/javascript'>alert('该项目已经被人接下了，请寻找新项目');</script >");
                        return View(res);
                    }
                }
                else
                {
                    var res = from c in db.Project
                              where c.Project_Id == int.Parse(Id)
                              select c;
                    Response.Write("<script type='text/javascript'>alert('你没有权限接受项目');</script >");
                    return View(res);
                }
            }
            catch
            {
                return Redirect("~/Login/Login");
            }
        }
        [HttpGet]
        public ActionResult ChangeMO()
        {
            Identity();
            string Id = Request.QueryString["id"];
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.Project
                      where c.Project_Id.ToString() == Id
                      select c;
            foreach (var k in res)
            {
                if (k.Project_Requirement == "无需经验")
                {
                    ViewData["a"] = "selected";
                    ViewData["c"] = ViewData["d"] = ViewData["b"] = "a";
                }
                else if (k.Project_Requirement == "半年")
                {
                    ViewData["b"] = "selected";
                    ViewData["c"] = ViewData["d"] = ViewData["a"] = "a";
                }
                else if (k.Project_Requirement == "1年")
                {
                    ViewData["c"] = "selected";
                    ViewData["a"] = ViewData["d"] = ViewData["b"] = "a";
                }
                else
                {
                    ViewData["d"] = "selected";
                    ViewData["c"] = ViewData["a"] = ViewData["b"] = "a";
                }
            }
            return View(res);
        }
        [HttpPost]
        public ActionResult ChangeMO(string a)
        { 
            SECPDataContext db = new SECPDataContext();
            string Id = Request.QueryString["id"];
            try
            {
                Identity();
                var res = from c in db.Project
                          where c.Project_Id.ToString() == Id
                          select c;
                foreach (var k in res)
                {
                    k.Project_Name = Request.Form["Project_Name"];
                    k.Project_Money = int.Parse(Request.Form["Project_Money"]);
                    k.Project_Requirement = Request.Form["Project_Requirement"];
                    k.Project_Contact = Request.Form["Project_Contact"];
                    k.Project_Content = Request.Form["Project_Content"];
                    k.Project_TimeLimeit = int.Parse(Request.Form["Project_TimeLimeit"]);
                    db.SubmitChanges();
                }
                Response.Write("<script type='text/javascript'>alert('修改成功!');</script >");
                var res1 = from c in db.Project
                          where c.Project_Id.ToString() == Id
                          select c;
                return View(res1);
            }
            catch
            {
                var res = from c in db.Project
                          where c.Project_Id.ToString() == Id
                          select c;
                Response.Write("<script type='text/javascript'>alert('修改失败！请核实资料是否有错');</script >");
                return View(res);
            }
        }
        
        /// <summary>
        /// 接受
        /// </summary>
        /// <returns></returns>
        public JsonResult Get_Json()
        {
            SECPDataContext db=new SECPDataContext();
            List<CProject> slist = new List<CProject>();
            string name=Request.Cookies["UserName"].Value;
            string Id = Request.Cookies["Type"].Value;
            string Type;
            if(Id=="1")
            {
                Type = "学生";
            }
            else if(Id=="2")
            {
                Type = "教师";
            }
            else if(Id=="3")
            {
                Type="企业";
            }
            else if(Id=="4")
            {
                Type="用户";
            }
            else
            {
                Type="游客";
            }
            var res = from c in db.Project
                      where c.Project_Sendee==name&&c.Project_SendeeType==Type
                      select c;
            ViewData["JS"]=res.Count();
            foreach (var k in res)
            {
                CProject pro = new CProject();
                pro.Id = k.Project_Id.ToString();
                pro.Title = k.Project_Name;
                pro.Money = k.Project_Money.ToString();
                pro.Date = k.Project_STime.Date.ToString("yyyy-MM-dd");
                pro.Litmit = Convert.ToString(k.Project_TimeLimeit);
                pro.Added_by = k.Project_Publisher;
                if (k.Project_PubilsherType == "学生")
                {
                    var res1 = from c in db.Student
                               where k.Project_Publisher == c.student_UserName
                               select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.student_QQ;
                    }
                }
                else if (k.Project_PubilsherType == "教师")
                {
                    var res1 = from c in db.Teacher
                                where k.Project_Publisher == c.teacher_UserName
                                select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.teacher_QQ;
                    }
                }
                else if (k.Project_PubilsherType == "企业")
                {
                    var res1 = from c in db.Enterprise
                                where k.Project_Publisher == c.Enterprise_UserName
                                select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.Enterprise_QQ;
                    }
                }
                else
                {
                    var res1 = from c in db.User
                                where k.Project_Publisher == c.User_UserName
                                select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.User_QQ;
                    }
                }
                if (pro != null)
                {
                    slist.Add(pro);
                }
            }
            return Json(slist, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 发布
        /// </summary>
        /// <returns></returns>
        public JsonResult Get_Json1()
        {
            SECPDataContext db = new SECPDataContext();
            List<CProject> slist = new List<CProject>();
            string name = Request.Cookies["UserName"].Value;
            string Id = Request.Cookies["Type"].Value;
            string Type;
            if (Id == "1")
            {
                Type = "学生";
            }
            else if (Id == "2")
            {
                Type = "教师";
            }
            else if (Id == "3")
            {
                Type = "企业";
            }
            else if (Id == "4")
            {
                Type = "用户";
            }
            else
            {
                Type = "游客";
            }
            var res = from c in db.Project
                      where c.Project_Publisher == name && c.Project_PubilsherType == Type
                      select c;
            ViewData["FB"] = res.Count();
            foreach (var k in res)
            {
                CProject pro = new CProject();
                pro.Id = k.Project_Id.ToString();
                pro.Title = k.Project_Name;
                pro.Money = k.Project_Money.ToString();
                pro.Date = k.Project_STime.Date.ToString("yyyy-MM-dd");
                pro.Litmit = Convert.ToString(k.Project_TimeLimeit);
                pro.Added_by = k.Project_Sendee;
                if (k.Project_SendeeType == "学生")
                {
                    var res1 = from c in db.Student
                               where k.Project_Sendee == c.student_UserName
                               select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.student_QQ;
                    }
                }
                else if (k.Project_SendeeType == "教师")
                {
                    var res1 = from c in db.Teacher
                               where k.Project_Sendee == c.teacher_UserName
                               select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.teacher_QQ;
                    }
                }
                else if (k.Project_SendeeType == "企业")
                {
                    var res1 = from c in db.Enterprise
                               where k.Project_Sendee == c.Enterprise_UserName
                               select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.Enterprise_QQ;
                    }
                }
                else
                {
                    var res1 = from c in db.User
                               where k.Project_Sendee == c.User_UserName
                               select c;
                    foreach (var s in res1)
                    {
                        pro.QQ = s.User_QQ;
                    }
                }
                if (pro != null)
                {
                    slist.Add(pro);
                }
            }
            
            return Json(slist, JsonRequestBehavior.AllowGet);
        }
     
    }
}
