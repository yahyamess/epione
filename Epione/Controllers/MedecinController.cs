using DATA;
using Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
            var PL = MS.GetById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())); 

            //List<PlusMedModel> plus = new List<PlusMedModel>();
            //foreach (var item in PL)
            //{
            //    if (item.IDMed == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()))
            //    {

            //        plus.Add(
            //            new PlusMedModel
            //            {
            //                specialieProfondu = item.specialieProfondu,

            //                IDMed = item.IDMed,
            //                Hopital = item.Hopital,
            //                image = item.image

            //            });

            //    }
            //}

            ViewBag.plus =PL ; //objemp is employee class object  
                                 //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
            ViewData["plus"] = PL; //objemp is employee class object  
            return View("index");
          

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
        public ActionResult CreatePlus(PlusMedModel M ,  FormCollection collection)
        {



        

            PlusMed f = new Domain.PlusMed();

            //f.specialieProfondu = M.specialieProfondu;
            //f.IDMed = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            //f.Hopital = M.Hopital;
            //f.image = M.image;

            f.specialieProfondu = "hahahah";
            f.IDMed = 55; 
            f.Hopital = M.Hopital;
            f.image = M.image;
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
        public ActionResult Edit( FormCollection form)
        {

            try { 

            string hopital = form["hopital"];
            string profondu = form["profondu"];
            string image1 = form["image"];
            MyContext ctx = new MyContext();
                var id = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var plus = ctx.PlusMed.First(a => a.IDMed==id );
            
            plus.Hopital = hopital;
            plus.specialieProfondu = profondu;
            plus.image = image1;
            
           ctx.Entry(plus).State = EntityState.Modified;
            ctx.SaveChanges();

                 ViewBag.plus = plus; //objemp is employee class object  
                //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
                ViewData["plus"] = plus; //objemp is employee class object  

               

                return View("Index"); 
            }

            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("index");
            }




















        }

        // GET: Default/Delete/5
        public ActionResult Delete( int id)
        {

          
            return RedirectToAction("index");
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete( int id, PlusMed f)
        {
           
             f = MS.GetById(id);
        
            MS.Delete(f);
            MS.Commit();
         
                return RedirectToAction("index");


            //try
            //{
            //TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }



    }
}
