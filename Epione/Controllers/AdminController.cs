
using DATA;
using Models;
using Epione.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace Epione.Controllers
{

    [Authorize(Roles ="SuperAdmin")]
    public class AdminController : Controller
    {

        MyContext context = new MyContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {

 
          
            var UserManager = new UserManager<Medecin, int>(new UserStore<Medecin, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));

            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];
            var user = new Medecin();
            user.UserName = UserName;

            user.Email = email;
            user.Password = pwd;

            string pass = pwd; 
            var chkUser = UserManager.Create(user , pass);
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "medecin")
                ;
            }
            return View();


            ///////////////////////////////////////////////////










        }
        public ActionResult AssignRole()
        {

            return View();
        }





    }


}