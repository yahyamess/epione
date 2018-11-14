using DATA;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Domain;

namespace Epione.Controllers
{
   // [Authorize(Roles ="Medecin")]
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





            global::Models.PlusMed f = new global::Models.PlusMed();

            f.specialieProfondu = PlusModel.specialieProfondu;
            
            f.IDMed = PlusModel.IDMed;
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
        public ActionResult Edit(PlusMed PlusModel, int id , FormCollection collection)
        {




            global::Models.PlusMed f = new global::Models.PlusMed();

            f.specialieProfondu = PlusModel.specialieProfondu;
            f.ID = id; 
            f.IDMed = PlusModel.IDMed;
            f.Hopital = PlusModel.Hopital;

            MS.add(f);
            MS.Commit();
            return RedirectToAction("index");











            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Default/Delete/5
        public ActionResult Delete( int id)
        {

          
            return RedirectToAction("index");
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(PlusMed PlusModel, int id, FormCollection collection)
        {

            global::Models.PlusMed f = new global::Models.PlusMed();

            f.specialieProfondu = PlusModel.specialieProfondu;
            f.ID = id;
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
           }
         public ActionResult Index1(string firstname, string lastname, string specialite, string localisation)
        {
            int page = 1;
            string sortdir = "asc";
            string sort = "FirstName";
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            // Parameter
            //ViewBag.last, ViewBag.first, ViewBag.spec, ViewBag.localisation, sort, sortdir, skip, pageSize
            var data = GetMedecin(firstname, lastname , specialite, localisation);
            ViewBag.TotalRows = totalRecord;
            //ViewBag.search = search;
            return View(data);
        }

        public ActionResult GetMedecins()
        {
            List<Medecin> list = new List<Medecin>();
           // list = this.GetMedecin();
            return View(list);

        }

        //string firstname, string lastname, string localisation, string specialite, string sort, string sortdir, int skip, int pageSize
        public List<Medecin> GetMedecin(string firstname, string lastname, string specialite, string localisation)
        {

            //using (MyContext dc = new MyContext())
            //{
            //    var v = (from a in dc.Medecin
            //             where
            //                     a.FirstName.Contains(firstname) ||
            //                     a.LastName.Contains(lastname) ||
            //                     a.localisation.Contains(localisation) ||
            //                     a.specialite.Contains(specialite)
            //             //  a.specialite.Contains(search)
            //             select a
            //                    );
            // totalRecord = v.Count();
            // v = v.OrderBy(sort + " " + sortdir);
            //    if (pageSize > 0)
            //    {
            //        v = v.Skip(skip).Take(pageSize);
            //    }

            //    var x = v.ToList();
            //   return v.ToList();

            MyContext dc = new MyContext();
            List<Medecin> myList = new List<Medecin>();
            myList = firstname == "" && lastname != "" && localisation != "" && specialite != "" ? dc.Medecin
                .Where(item => item.LastName == lastname && item.specialite == specialite && item.localisation == localisation).ToList() :

                lastname == "" && firstname != "" && localisation != "" && specialite != "" ? dc.Medecin
                .Where(item => item.FirstName == firstname && item.specialite == specialite && item.localisation == localisation).ToList() :

                specialite == "" && firstname != "" && localisation != "" && lastname != "" ? dc.Medecin
                .Where(item => item.LastName == lastname && item.FirstName == firstname && item.localisation == localisation).ToList() :

                localisation == "" && firstname != "" && lastname != "" && specialite != "" ? dc.Medecin
                .Where(item => item.LastName == lastname && item.specialite == specialite && item.FirstName == firstname).ToList() :

                 firstname == "" && lastname == ""  && localisation != "" && specialite != "" ?
            dc.Medecin
                .Where(item => item.specialite == specialite && item.localisation == localisation).ToList() :
            localisation == "" && specialite == "" && firstname != "" && lastname != "" ? dc.Medecin
                .Where(item => item.FirstName == firstname && item.LastName == lastname).ToList() :
                localisation == "" && lastname == "" && specialite != "" && firstname != "" ?
            dc.Medecin
                .Where(item => item.specialite == specialite && item.FirstName == firstname).ToList() :
                firstname == "" && localisation == "" && lastname != "" && specialite != "" ?
            dc.Medecin
                .Where(item => item.specialite == specialite && item.LastName == lastname).ToList() :
                firstname == "" && specialite == "" && localisation != "" && lastname != "" ?
            dc.Medecin
                .Where(item => item.localisation == localisation && item.LastName == lastname).ToList() :
                specialite == "" && lastname == "" && localisation != "" && firstname != "" ?
            dc.Medecin
                .Where(item => item.FirstName == firstname && item.localisation == localisation).ToList() :

                dc.Medecin
                .Where(item => item.FirstName == firstname && item.localisation == localisation && item.LastName == lastname && item.specialite == specialite).ToList();

            //myList = dc.Medecin.Where(item => item.FirstName ==firstname)
            //    .ToList();

            return myList;
            }
        }

    }


