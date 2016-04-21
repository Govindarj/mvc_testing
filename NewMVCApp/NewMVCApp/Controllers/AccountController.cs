using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewMVCApp.ViewModels;
using NewMVCApp.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
namespace NewMVCApp.Controllers
{
    public class AccountController : Controller
    {
       
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            var flag = false;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=devops;Integrated Security=SSPI;User Id= PACRIM1\H156370;Password=Desktop123;MultipleActiveResultSets=True;Application Name=EntityFramework");
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select uname,password from [user]";
                //cmd.ExecuteNonQuery();
                //SqlDataReader reader = cmd.ExecuteReader();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    if(dr["uname"].ToString().Equals(avm.Username) && dr["Password"].ToString().Equals(avm.Password))
                    {
                        Console.WriteLine("inside If");
                        flag = true;
                        break;
                    }
                }
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {

                //        if (reader.GetString(0) == avm.Username && reader.GetString(1) == avm.Password)
                //        {
                //           return View("Welcome");
                //        }
                //    }
                //}             
                //reader.Close();
                //con.Close();
            }
            catch(Exception e)
            {
                
                ViewBag.Error = e.Message;
                Console.WriteLine(e.Message);
                return View(e.Message);
            }

            /*    if (avm.Username.Equals("abc") && avm.Password.Equals("1234"))
                {
                    //Session["username"] = avm.Username;
                    return View("Welcome");
                }
                else {
                    ViewBag.Error = "Account Invalid";
                    return View("Index");
                }*/
            if(flag)
            {
                return View("Welcome");
            }
            ViewBag.Error = "Account Invalid";
            return View("Index");
           }
        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            try
            {
                
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=devops;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert into [user] (uname,password,home) values('"+rvm.Email+"','"+rvm.Password+"','"+rvm.Hometown+"')";
                cmd.ExecuteNonQuery();
                ViewBag.successMessage = "Successfully Inserted!!!";
                con.Close();
            }
            catch (Exception e)
            {
                ViewBag.Error = "connection not established";
                return View("Register");
            }

            /*    if (avm.Username.Equals("abc") && avm.Password.Equals("1234"))
                {
                    //Session["username"] = avm.Username;
                    return View("Welcome");
                }
                else {
                    ViewBag.Error = "Account Invalid";
                    return View("Index");
                }*/
            
            return View("Welcome");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Account");
        }
    }
}