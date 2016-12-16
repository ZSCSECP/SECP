using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SECP.Models;
namespace SECP.Controllers
{
    public class PersonalInformationController : Controller
    {
        //
        // GET: /PersonalInformation/
        [HttpGet]
        public ActionResult PIstudent()
        {
            try
            {
                Identity();
                string name = Request.Cookies["UserName"].Value;
                string Id = Request.Cookies["Type"].Value;
                if (Id == "1")//学生
                {
                    SECPDataContext db = new SECPDataContext();
                    var res = from c in db.Student
                              where name == c.student_UserName
                              select c;
                    return View(res);
                }
                else if (Id == "2")//教师
                {
                    return Redirect("PIteacher");
                }
                else if (Id == "3")//企业
                {
                    return Redirect("PIenterprise");
                }
                else if (Id == "4")//用户
                {
                    return Redirect("PIuser");
                }
                else
                {
                    return Redirect("~/Backstage/BSHome");
                }
            }
            catch
            {
                return Redirect("~/Login/Login");
            }
        }
        [HttpGet]
        public ActionResult PIteacher()
        {
            Identity();
            string name = Request.Cookies["UserName"].Value;
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.Teacher
                      where name == c.teacher_UserName
                      select c;
            return View(res);
        }
        [HttpGet]
        public ActionResult PIenterprise()
        {
            Identity();
            string name = Request.Cookies["UserName"].Value;
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.Enterprise
                      where name == c.Enterprise_UserName
                      select c;
            return View(res);
        }
        [HttpGet]
        public ActionResult PIuser()
        {
            Identity();
            string name = Request.Cookies["UserName"].Value;
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.User
                      where name == c.User_UserName
                      select c;
            return View(res);
        }
        [HttpGet]
        public ActionResult ChangePIstudent()
        {
            Identity();
            try
            {
                Identity();
                string name = Request.Cookies["UserName"].Value;
                string Id = Request.Cookies["Type"].Value;
                if (Id == "1")//学生
                {
                    SECPDataContext db = new SECPDataContext();
                    var res = from c in db.Student
                              where name == c.student_UserName
                              select c;
                    return View(res);
                }
                else if (Id == "2")//教师
                {
                    return Redirect("ChangePIteacher");
                }
                else if (Id == "3")//企业
                {
                    return Redirect("ChangePIenterprise");
                }
                else if (Id == "4")//用户
                {
                    return Redirect("ChangePIuser");
                }
                else
                {
                    return Redirect("~/Backstage/BSHome");
                }
            }
            catch
            {
                return Redirect("~/Login/Login");
            }
        }
        [HttpPost]
        public ActionResult ChangePIstudent(string a)
        {
            Identity();
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            string name = Request.Cookies["UserName"].Value;
            //各类型注册
            //try
            //{
                var res = from c in db.Student
                          where name == c.student_UserName
                          select c;
                string File = null;

                foreach (var st in res)
                {
                    File = st.student_Photo;
                }

                HttpPostedFileBase file = Request.Files["file1"];
                //存入文件    
                if (file.ContentLength > 0)
                {
                    file.SaveAs(Server.MapPath("~/images/student/") + System.IO.Path.GetFileName(file.FileName));
                    File = "../images/student/" + file.FileName;
                }

                //学生表数据自动递增标识
                foreach (var stu in res)
                {
                    stu.student_Email = Request.Form["student_Email"];
                    stu.student_RealName = Request.Form["student_RealName"];
                    stu.student_BornDate = Convert.ToDateTime(Request.Form["student_BornDate"]);
                    stu.student_Sex = Request.Form["student_Sex"];
                    //stu.student_Major = Request.Form["student_Major"];
                    stu.student_GradSchool = Request.Form["student_GradSchool"];
                    stu.student_Edu = Request.Form["student_Edu"];
                    stu.student_Tel = Request.Form["student_Tel"];
                    //stu.student_Address = Request.Form["student_Address"];
                    stu.student_Glory = Request.Form["student_Glory"];
                    stu.student_Practic = Request.Form["student_Practic"];
                    //stu.student_WorkPlace = Request.Form["student_WorkPlace"];
                    stu.student_Occupation = Request.Form["student_Occupation"];
                    stu.student_Wage = Request.Form["student_Wage"];
                    stu.student_SKill = Request.Form["student_SKill"];
                    stu.student_Hobby = Request.Form["student_Hobby"];
                    stu.student_QQ = Request.Form["student_QQ"];
                    stu.stduent_Introduce = Request.Form["stduent_Introduce"];
                    stu.student_Train = Request.Form["student_Train"];
                    stu.student_Photo = File;
                    db.SubmitChanges();
                }
                Response.Write("<script type='text/javascript'>alert('修改成功！');</script >");
                return View(res);
            //}
            //catch
            //{
            //    Response.Write("<script type='text/javascript'>alert('修改失败！请核实资料是否有错');</script >");
            //    var res = from c in db.Student
            //              where name == c.student_UserName
            //              select c;
            //    return View(res);
            //}
        }
        [HttpGet]
        public ActionResult ChangePIteacher()
        {
            Identity();
            string name = Request.Cookies["UserName"].Value;
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.Teacher
                      where name == c.teacher_UserName
                      select c;
            return View(res);
        }
        [HttpPost]
        public ActionResult ChangePIteacher(string a)
        {
            Identity();
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            string name = Request.Cookies["UserName"].Value;
            //各类型注册
            try
            {
                var res = from c in db.Teacher
                          where name == c.teacher_UserName
                          select c;

                foreach (var tea in res)
                {
                    tea.teacher_Email = Request.Form["teacher_Email"];
                    tea.teacher_RealName = Request.Form["teacher_RealName"];
                    tea.teacher_BornDate = Convert.ToDateTime(Request.Form["teacher_BornDate"]);
                    tea.teacher_Sex = Request.Form["teacher_Sex"];
                    tea.teacher_TeachClass = Request.Form["teacher_TeachClass"];
                    tea.teacher_GradSchool = Request.Form["teacher_GradSchool"];
                    tea.teacher_Edu = Request.Form["teacher_Edu"];
                    tea.teacher_Tel = Request.Form["teacher_Tel"];
                    tea.teacher_AtSchool = Request.Form["teacher_AtSchool"];
                    tea.teacher_Address = Request.Form["teacher_Address"];
                    tea.teacher_Glory = Request.Form["teacher_Glory"];
                    tea.teacher_Position = Request.Form["teacher_Position"];
                    tea.teacher_QQ = Request.Form["teacher_QQ"];
                    tea.teacher_RepThesis = Request.Form["teacher_RepThesis"];
                    tea.teacher_RepProject = Request.Form["teacher_RepProject"];
                    tea.teacher_RepPro = Request.Form["teacher_RepPro"];
                    tea.teacher_Introduce = Request.Form["teacher_Introduce"];
                    db.SubmitChanges();
                }
                Response.Write("<script type='text/javascript'>alert('修改成功！');</script >");
                return View(res);
            }
            catch
            {
                var res = from c in db.Teacher
                          where name == c.teacher_UserName
                          select c;
                Response.Write("<script type='text/javascript'>alert('修改失败！请核实资料是否有错');</script >");
                return View(res);
            }
        }
        [HttpGet]
        public ActionResult ChangePIenterprise()
        {
            Identity();
            string name = Request.Cookies["UserName"].Value;
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.Enterprise
                      where name == c.Enterprise_UserName
                      select c;
            return View(res);
        }
        [HttpPost]
        public ActionResult ChangePIenterprise(string a)
        {
            Identity();
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            string name = Request.Cookies["UserName"].Value;
            //各类型注册
            try
            {
                var res = from c in db.Enterprise
                          where name == c.Enterprise_UserName
                          select c;
                foreach (var En in res)
                {
                    En.Enterprise_Email = Request.Form["Enterprise_Email"];
                    En.Enterprise_Name = Request.Form["Enterprise_Name"];
                    En.Enterprise_Type = Request.Form["Enterprise_Type"];
                    En.Enterprise_Scale = Request.Form["Enterprise_Scale"];
                    En.Enterprise_Place = Request.Form["Enterprise_Place"];
                    En.Enterprise_Industry = Request.Form["Enterprise_Industry"];
                    En.Enterprise_Postcode = Request.Form["Enterprise_Postcode"];
                    En.Enterprise_Tel = Request.Form["Enterprise_Tel"];
                    En.Enterprise_Contact = Request.Form["Enterprise_Contact"];

                    En.Enterprise_Business = Request.Form["Enterprise_Business"];
                    En.Enterprise_Brief = Request.Form["Enterprise_Brief"];
                    En.Enterprise_Culture = Request.Form["Enterprise_Culture"];
                    En.Enterprise_QQ = Request.Form["Enterprise_QQ"];
                    db.SubmitChanges();
                }
                Response.Write("<script type='text/javascript'>alert('修改成功！');</script >");
                return View(res);

            }
            catch
            {
                var res = from c in db.Teacher
                          where name == c.teacher_UserName
                          select c;
                Response.Write("<script type='text/javascript'>alert('修改失败！请核实资料是否有错');</script >");
                return View(res);
            }
        }
        [HttpGet]
        public ActionResult ChangePIuser()
        {
            Identity();
            string name = Request.Cookies["UserName"].Value;
            SECPDataContext db = new SECPDataContext();
            var res = from c in db.User
                      where name == c.User_UserName
                      select c;
            return View(res);
        }
        [HttpPost]
        public ActionResult ChangePIuser(string a)
        {
            Identity();
            //数据上下文
            SECPDataContext db = new SECPDataContext();
            string name = Request.Cookies["UserName"].Value;
            //各类型注册
            try
            {
                var res = from c in db.User
                          where name == c.User_UserName
                          select c;
                //教师表数据自动递增标识
                foreach (var tea in res)
                {
                    tea.User_QQ = Request.Form["User_QQ"];
                    db.SubmitChanges();
                }
                Response.Write("<script type='text/javascript'>alert('修改成功！');</script >");
                return View(res);
            }
            catch
            {
                var res = from c in db.User
                          where name == c.User_UserName
                          select c;
                Response.Write("<script type='text/javascript'>alert('修改失败！请核实资料是否有错');</script >");
                return View(res);
            }
        }
        public ActionResult ChangePassword()
        {
            try
            {
                Identity();
                string Id = Request.Cookies["Type"].Value;
                return View();
            }
            catch
            {
                return Redirect("~/Login/Login");
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(string code, string pwd, string pwd1, string pwd2)
        {
            Identity();
            SECPDataContext db = new SECPDataContext();
            string name = Request.Cookies["UserName"].Value;
            string Id = Request.Cookies["Type"].Value;
            if (Id == "1")
            {
                var res = from c in db.Student
                          where c.student_Password == pwd
                          select c;
                if (res.Count() != 0)
                {
                    if (pwd1 == pwd2)
                    {
                        if (Session["ValidateCode"].ToString() == code)
                        {
                            var k = from c in db.Student
                                    where c.student_UserName == name
                                    select c;
                            foreach (var s in k)
                            {
                                s.student_Password = pwd1;
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
            else if (Id == "2")
            {
                var res = from c in db.Teacher
                          where c.teacher_Password == pwd
                          select c;
                if (res.Count() != 0)
                {
                    if (pwd1 == pwd2)
                    {
                        if (Session["ValidateCode"].ToString() == code)
                        {
                            var k = from c in db.Teacher
                                    where c.teacher_UserName == name
                                    select c;
                            foreach (var s in k)
                            {
                                s.teacher_Password = pwd1;
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
            else if (Id == "3")
            {
                var res = from c in db.Enterprise
                          where c.Enterprise_Password == pwd
                          select c;
                if (res.Count() != 0)
                {
                    if (pwd1 == pwd2)
                    {
                        if (Session["ValidateCode"].ToString() == code)
                        {
                            var k = from c in db.Enterprise
                                    where c.Enterprise_UserName == name
                                    select c;
                            foreach (var s in k)
                            {
                                s.Enterprise_Password = pwd1;
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
            else if (Id == "4")
            {
                var res = from c in db.User
                          where c.User_Password == pwd
                          select c;
                if (res.Count() != 0)
                {
                    if (pwd1 == pwd2)
                    {
                        if (Session["ValidateCode"].ToString() == code)
                        {
                            var k = from c in db.User
                                    where c.User_UserName == name
                                    select c;
                            foreach (var s in k)
                            {
                                s.User_Password = pwd1;
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
            else
            {
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
        }
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
        public ActionResult CheckCode()
        {
            //生成验证码
            ValidateCode validateCode = new ValidateCode();
            string code = validateCode.CreateValidateCode(4);
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}
