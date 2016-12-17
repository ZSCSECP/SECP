using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;
namespace SECP.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        /// <summary>
        /// 登陆显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login()
        {
            //移除cookies
            HttpCookie cookies = Request.Cookies["UserName"];
            if (cookies != null)
            {
                cookies.Expires = DateTime.Today.AddDays(-1);
                Response.Cookies.Add(cookies);
                Request.Cookies.Remove("UserName");
            }
            HttpCookie cookies1 = Request.Cookies["Type"];
            if (cookies1 != null)
            {
                cookies1.Expires = DateTime.Today.AddDays(-1);
                Response.Cookies.Add(cookies1);
                Request.Cookies.Remove("Type");
            }
            return View();
        }
        /// <summary>
        /// 登陆功能实现
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(Models.Login models)
        {
            try
            {   
                //读取按钮身份
                string sub = Request.Form["Login"];
                if (sub == "Access")
                {
                    //读取V层中的身份
                    string QX = Request.Form["QX"];
                    if (QX == "1")
                     return Redirect("Access");
                    else if(QX == "2")
                     return Redirect("Access1");
                    else if(QX == "3")
                     return Redirect("Access2");
                    else if (QX == "4")
                        return Redirect("Access3");
                    else if(QX=="5")
                    {
                        Response.Write("<script type='text/javascript'>alert('注册失败哦！管理员是不能注册的');</script >");
                        return View();
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('注册失败哦！科技局管理员是不能注册的');</script >");
                        return View();
                    }
                }
                else
                {
                    //读取V层中的身份
                    string QX = Request.Form["QX"];
                    SECPDataContext db = new SECPDataContext();
                    if (models.UserName == null || models.PassWord == null)
                    {
                        Response.Write("<script type='text/javascript'>alert('登陆失败哦！请输入完整数据');</script >");
                        return View();
                    }
                    else
                    {
                        //建立cookies来记录登陆名
                        HttpCookie UserName = new HttpCookie("UserName");
                        Response.Cookies.Add(UserName);
                        //建立cookies来记录身份
                        HttpCookie Type = new HttpCookie("Type");
                        Response.Cookies.Add(Type);
                        if (QX == "1")
                        {
                            //学生登陆
                            var student = from a in db.Student
                                          where models.UserName == a.student_UserName && models.PassWord == a.student_Password
                                          select a;
                            if (student.Count() != 0)
                            {
                                foreach (var a1 in student)
                                {
                                    Response.Cookies["UserName"].Value = a1.student_UserName;
                                    Response.Cookies["Type"].Value = "1"; //1代表学生
                                }
                                //if(Request.UrlReferrer!=null)
                                //{
                                //    return Redirect(Request.UrlReferrer.ToString());
                                //}
                                return Redirect("~/Home.html");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('登陆失败哦！请重新输入您的帐号密码');</script >");
                                return View();
                            }
                        }
                        else if (QX == "2")
                        {
                            //教师登陆
                            var tea = from a in db.Teacher
                                      where models.UserName == a.teacher_UserName && models.PassWord == a.teacher_Password
                                      select a;
                            if (tea.Count() != 0)
                            {
                                foreach (var a1 in tea)
                                {
                                    Response.Cookies["UserName"].Value = a1.teacher_UserName;
                                    Response.Cookies["Type"].Value = "2"; //2代表教师
                                }
                                return Redirect("~/Home.html");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('登陆失败哦！请重新输入您的帐号密码');</script >");
                                return View();
                            }
                        }
                        else if (QX == "3")
                        {
                            //企业代表人登陆
                            var ent = from a in db.Enterprise
                                      where models.UserName == a.Enterprise_UserName && models.PassWord == a.Enterprise_Password
                                      select a;
                            if (ent.Count() != 0)
                            {
                                foreach (var a1 in ent)
                                {
                                    Response.Cookies["UserName"].Value = a1.Enterprise_UserName;
                                    Response.Cookies["Type"].Value = "3"; //3代表企业代表人
                                }
                                return Redirect("~/Home.html");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('登陆失败哦！请重新输入您的帐号密码');</script >");
                                return View();
                            }
                        }
                        else if (QX == "4")
                        {
                            //客户登陆
                            var User = from a in db.User
                                       where models.UserName == a.User_UserName && models.PassWord == a.User_Password
                                       select a;
                            if (User.Count() != 0)
                            {
                                foreach (var a1 in User)
                                {
                                    Response.Cookies["UserName"].Value = a1.User_UserName;
                                    Response.Cookies["Type"].Value = "4"; //4代表客户
                                }
                                return Redirect("~/Home.html");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('登陆失败哦！请重新输入您的帐号密码');</script >");
                                return View();
                            }
                        }
                        else if(QX=="5")
                        {
                            //管理员
                            var Admin = from a in db.Admin
                                        where models.UserName == a.admin_UserName && models.PassWord == a.admin_Password
                                        select a;
                            if (Admin.Count() != 0)
                            {
                                foreach (var a1 in Admin)
                                {
                                    Response.Cookies["UserName"].Value = a1.admin_UserName;
                                    Response.Cookies["Type"].Value = "5"; //5代表管理员
                                }
                                return Redirect("~/Backstage/BSHome");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('登陆失败哦！请重新输入您的帐号密码');</script >");
                                return View();
                            }
                        }
                        else
                        {
                            //中山科技局
                            var Admin = from a in db.Admin
                                        where models.UserName == a.admin_UserName && models.PassWord == a.admin_Password
                                        select a;
                            if (Admin.Count() != 0)
                            {
                                foreach (var a1 in Admin)
                                {
                                    Response.Cookies["UserName"].Value = a1.admin_UserName;
                                    Response.Cookies["Type"].Value = "6"; //6代表中山科技局
                                }
                                return Redirect("~/Goverment/BSEnterprise");
                            }
                            else
                            {
                                Response.Write("<script type='text/javascript'>alert('登陆失败哦！请重新输入您的帐号密码');</script >");
                                return View();
                            }
                        }
                    }
                }
            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('登陆失败哦！请重新输入您的帐号密码');</script >");
                return View();
            }
        }
        /// <summary>
        /// 学生注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Access()
        {
            return View();
        }
        /// <summary>
        /// 学生注册功能实现
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Access(string a)
        {
            
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            //各类型注册
            try
            {
                //学生表数据自动递增标识
                Student stu = new Student();
                stu.student_UserName = Request.Form["uid"];
                stu.student_Password = Request.Form["psw1"];
                stu.student_Email = Request.Form["email"];
                stu.student_RealName = Request.Form["nickname"];
                stu.student_BornDate = Convert.ToDateTime(Request.Form["Year"]);
                stu.student_Sex = Request.Form["sex"];
                stu.student_Major = Request.Form["Major"];
                stu.student_GradSchool = Request.Form["school"];
                stu.student_Edu = Request.Form["student_Edu"];
                stu.student_Tel = Request.Form["student_Tel"];
                stu.student_Address = Request.Form["address"];
                stu.student_Glory = Request.Form["Glory"];
                stu.student_Practic = Request.Form["Practic"];
                stu.student_WorkPlace = Request.Form["place"];
                stu.student_Occupation = Request.Form["Ocp"];
                stu.student_Wage = Request.Form["Wage"];
                stu.student_SKill = Request.Form["SKill"];
                stu.student_Hobby = Request.Form["Hobby"];
                stu.student_QQ = Request.Form["QQ"];
                stu.stduent_Introduce=Request.Form["Introduce"];
                stu.student_Train = Request.Form["Train"];
                db.Student.InsertOnSubmit(stu);
                db.SubmitChanges();

                //建立cookies来记录登陆名
                HttpCookie UserName = new HttpCookie("UserName");
                Response.Cookies.Add(UserName);
                Response.Cookies["UserName"].Value = Request.Form["uid"];

                return Redirect("~/Home.html");


            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('注册失败哦！请完成所有数据填写');</script >");
                return View();
            }
        }
        /// <summary>
        /// 教师注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Access1()
        {
            return View();
        }
        /// <summary>
        /// 教师注册功能实现
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Access1(string a)
        {
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            //各类型注册
            try
            {
                //教师表数据自动递增标识
                Teacher tea = new Teacher();
                tea.teacher_UserName = Request.Form["tea_UserName"];
                tea.teacher_Password = Request.Form["tea_psw1"];
                tea.teacher_Email = Request.Form["tea_email"];
                tea.teacher_RealName = Request.Form["tea_nickname"];
                tea.teacher_BornDate = Convert.ToDateTime(Request.Form["tea_Year"]);
                tea.teacher_Sex = Request.Form["tea_sex"];
                tea.teacher_TeachClass = Request.Form["tea_class"];
                tea.teacher_GradSchool = Request.Form["tea_school"];
                tea.teacher_Edu = Request.Form["tea_edu"];
                tea.teacher_Tel = Request.Form["tea_tel"];
                tea.teacher_AtSchool = Request.Form["tea_AtSchool"];
                tea.teacher_Address = Request.Form["tea_address"];
                tea.teacher_Glory = Request.Form["tea_Glory"];
                tea.teacher_Position = Request.Form["tea_Position"];
                tea.teacher_QQ = Request.Form["QQ"];
                db.Teacher.InsertOnSubmit(tea);
                db.SubmitChanges();

                //建立cookies来记录登陆名
                HttpCookie UserName = new HttpCookie("UserName");
                Response.Cookies.Add(UserName);
                Response.Cookies["UserName"].Value = Request.Form["tea_UserName"];

                return Redirect("~/Home.html");


            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('注册失败哦！请完成所有数据填写');</script >");
                return View();
            }
        }
        /// <summary>
        /// 企业注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Access2()
        {
            return View();
        }
        /// <summary>
        /// 企业注册功能实现
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Access2(string a)
        {
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            //各类型注册
            try
            {
                //企业表数据自动递增标识
                Enterprise En = new Enterprise();
                En.Enterprise_UserName = Request.Form["En_UserName"];
                En.Enterprise_Password = Request.Form["En_psw1"];
                En.Enterprise_Email = Request.Form["En_email"];
                En.Enterprise_Name = Request.Form["En_nickname"];
                En.Enterprise_Type = Request.Form["En_type"];
                En.Enterprise_Scale = Request.Form["En_Scale"];
                En.Enterprise_Place = Request.Form["En_Place"];
                En.Enterprise_Industry = Request.Form["En_Industry"];
                En.Enterprise_Postcode = Request.Form["En_Postcode"];
                En.Enterprise_Tel = Request.Form["En_tel"];
                En.Enterprise_Contact = Request.Form["En_Contact"];
                En.Enterprise_Business = Request.Form["En_Business"];
                En.Enterprise_Brief = Request.Form["En_Brief"];
                En.Enterprise_Culture = Request.Form["En_Culture"];
                En.Enterprise_Checks = "0";//注册审核0为待审核，1为通过，2为未通过
                En.Enterprise_QQ = Request.Form["QQ"];
                db.Enterprise.InsertOnSubmit(En);
                db.SubmitChanges();

                //建立cookies来记录登陆名
                HttpCookie UserName = new HttpCookie("UserName");
                Response.Cookies.Add(UserName);
                Response.Cookies["UserName"].Value = Request.Form["En_UserName"];

                return Redirect("~/Home.html");


            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('注册失败哦！请完成所有数据填写');</script >");
                return View();
            }
        }
        /// <summary>
        /// 客户注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Access3()
        {
            return View();
        }
        /// <summary>
        /// 客户注册功能实现
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Access3(string a)
        { 
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            //各类型注册
            try
            {
                //企业表数据自动递增标识
                User user=new User();
                user.User_UserName=Request.Form["User_Name"];
                user.User_Password=Request.Form["user_psw1"];
                user.User_QQ = Request.Form["QQ"];
                db.User.InsertOnSubmit(user);
                db.SubmitChanges();

                //建立cookies来记录登陆名
                HttpCookie UserName = new HttpCookie("UserName");
                Response.Cookies.Add(UserName);
                Response.Cookies["UserName"].Value = Request.Form["User_Name"];

                return Redirect("~/Home.html");


            }
            catch
            {
                Response.Write("<script type='text/javascript'>alert('注册失败哦！请完成所有数据填写');</script >");
                return View();
            }
        
        }
    }
}
