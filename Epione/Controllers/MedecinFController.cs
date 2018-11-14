using Domain;
using ServiceEpione;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Epione.Controllers
{
    [Authorize(Roles = "Medecin")]
    public class MedecinFController : Controller
    {
        UserService us = new UserService();
        PatientService Ps = new PatientService();

        // GET: PatientF
        public ActionResult Index(string searchBy, string search)
        {
         
            var users = Ps.GetAll();
            List<Patient> y = new List<Patient>();

            foreach (var item in users)
            {

                if (item.idSocial.ToString() != null) { 
                y.Add(
                    
                    new Patient
                    {   
                        Id = item.Id,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber,
                        UserName = item.UserName,                    
                    });
            }
            }
            //List<User> a = y.Where(x => x.Roles.Where(p => Roles.GetUsersInRole("Patient"))).ToList();


            if (searchBy == "Email")
            {
                return View(y.Where(x => x.Email.StartsWith(search) || search == null).ToList());
            }
            else if (searchBy == "UserName")
            {
                return View(y.Where(x => x.UserName.StartsWith(search) || search == null).ToList());
            }else
            {
                return View(y);
            }
      
        }








        public ActionResult IndexJson(string searchBy, string search)
        {

            var users = Ps.GetAll();
            List<Patient> y = new List<Patient>();

            foreach (var item in users)
            {

                if (item.idSocial.ToString() != null)
                {
                    y.Add(

                        new Patient
                        {
                            Id = item.Id,
                            Email = item.Email,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            PhoneNumber = item.PhoneNumber,
                            UserName = item.UserName,
                        });
                }
            }
            //List<User> a = y.Where(x => x.Roles.Where(p => Roles.GetUsersInRole("Patient"))).ToList();


           
         
                return Json(y, JsonRequestBehavior.AllowGet);


            

        }












        // GET: PatientF/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientF/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientF/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientF/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientF/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientF/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
