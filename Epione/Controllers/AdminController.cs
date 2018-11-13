
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
using Services;

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

 
          
            var UserManager = new UserManager<Domain.Medecin, int>(new UserStore<Domain.Medecin, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(context));

            string UserName = form["txtEmail"];
            string email = form["txtEmail"];
            string pwd = form["txtPassword"];
            
            var user = new Domain.Medecin();
            user.UserName = UserName;
            user.Email = email;
            user.Password = pwd;
           

            var chkUser = UserManager.Create(user , pwd);
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "medecin")
                ;
            }

            MyContext ctx = new MyContext();
            ctx.PlusMed.Add(new PlusMed { IDMed = user.Id , specialieProfondu= "ajouter specialité" , Hopital = "ajouter specialité" , image="ajouter image"}) ;
            
            ctx.SaveChanges();



            return View();


            ///////////////////////////////////////////////////



        








        }
        public ActionResult AssignRole()
        {

            return View();
        }





    }


}