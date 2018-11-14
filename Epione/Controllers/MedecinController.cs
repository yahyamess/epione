using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epione.Controllers
{
    [Authorize(Roles = "Medecin")]
    public class MedecinController : Controller
    {

        MedecinService MS;
        public MedecinController()
        {
            MS = new MedecinService(); 
        }
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult CreatePlus(PlusMed PlusModel ,  FormCollection collection)
        {





            Domain.PlusMed f = new Domain.PlusMed();

            f.specialieProfondu = PlusModel.specialieProfondu;
            f.MedID = PlusModel.MedID;
            f.Hopital = PlusModel.Hopital; 

            MS.Add(f);
            MS.Commit();
            return RedirectToAction("index");













            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
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

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
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
