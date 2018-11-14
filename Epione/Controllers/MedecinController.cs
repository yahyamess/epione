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
using System.IO;
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
        public ActionResult Edit( FormCollection form , HttpPostedFileBase image)
        {

            try { 

            string hopital = form["hopital"];
            string profondu = form["profondu"];
            


              

                
                MyContext ctx = new MyContext();
                var id = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
                var plus = ctx.PlusMed.First(a => a.IDMed==id );

                var path = Path.Combine(Server.MapPath("~/Image/"), image.FileName);
                image.SaveAs(path);



                plus.Hopital = hopital;
                plus.specialieProfondu = profondu;
              
                plus.image = image.FileName ;
            
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
        public ActionResult Delete( int idm)
        {

            MyContext ctx = new MyContext();
            var pro = new RDV {id = idm };
            ctx.RendezVous.Attach(pro);
            ctx.RendezVous.Remove(pro);
            ctx.SaveChanges();

            var PL = MS.GetById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));



            ViewBag.plus = PL; //objemp is employee class object  
                               //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
            ViewData["plus"] = PL; //objemp is employee class object  


          



            var id = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());

            return View("search",db.RendezVous.Where(x => x.idMedecien == id).ToList());

        }


         public JsonResult GetDelete()
        {
            List<RDV> StuList = new List<RDV>();
            var id = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());
            StuList = db.RendezVous.Where(x => x.idMedecien == id).ToList();
                return Json(StuList, JsonRequestBehavior.AllowGet);
           
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




        public ActionResult Agenda()
        {

            var PL = MS.GetById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));



            ViewBag.plus = PL; //objemp is employee class object  
                               //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
            ViewData["plus"] = PL; //objemp is employee class object  
        

            return View();



        }







        public JsonResult GetEvents()


        {

            var id = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());

            using (MyContext dc = new MyContext())
            {
                var events = dc.Programme.Where(a => a.idMed == id).ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        // search






        MyContext db = new MyContext();
        public ActionResult Search()
        {

            var PL = MS.GetById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));

            ViewBag.plus = PL;
            ViewData["plus"] = PL; //objemp is employee class object  

            var id = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId());

            return View(db.RendezVous.Where(x => x.idMedecien == id).ToList());
        }



        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<RDV> StuList = new List<RDV>();
            if (SearchBy == "Name")
            {
                try
                {

                    StuList = db.RendezVous.Where(x => x.nom.ToString().StartsWith(SearchValue) || SearchValue == null).Where(x => x.idMedecien == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A ID ", SearchValue);
                }
                return Json(StuList, JsonRequestBehavior.AllowGet);
            }

            else if (SearchBy == "Month")
            {
                try
                {

                    StuList = db.RendezVous.Where(x => x.date.Month.ToString() == (SearchValue) || SearchValue == null).ToList().Where(x => x.idMedecien == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A ID ", SearchValue);
                }
                return Json(StuList, JsonRequestBehavior.AllowGet);
            }



            else if (SearchBy == "Year")
            {
                try
                {

                    StuList = db.RendezVous.Where(x => x.date.Year.ToString() == (SearchValue) || SearchValue == null).ToList().Where(x => x.idMedecien == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Is Not A ID ", SearchValue);
                }
                return Json(StuList, JsonRequestBehavior.AllowGet);
            }





            else
            {
                StuList = db.RendezVous.Where(x => x.date.Day.ToString() == (SearchValue) || SearchValue == null).ToList();
                return Json(StuList, JsonRequestBehavior.AllowGet);
            }
        }







     
        
        public ActionResult ajoutprogramme(int id ,string ville , int Medecien  , string maladi  )
        {

            try
            {
                var PL = MS.GetById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));



                ViewBag.plus = PL; //objemp is employee class object  
                                   //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
                ViewData["plus"] = PL; //objemp is employee class object  



                MyContext ctx = new MyContext();
                ctx.Programme.Add(new Programme { idRdv = id , ville = ville,  idMed= Medecien , maladi =maladi });

                ctx.SaveChanges();



                //objemp is employee class object  
                //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
                ViewData["id"] = id; //objemp is employee class object  



                var pro = new RDV { id = id };
                ctx.RendezVous.Attach(pro);
                ctx.RendezVous.Remove(pro);
                ctx.SaveChanges();

                return View("date");



               

            }

            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("date");
            }










         


        }





      
        public ActionResult date()
        {
            var PL = MS.GetById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));



            ViewBag.plus = PL; //objemp is employee class object  
                               //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
            ViewData["plus"] = PL; //objemp is employee class object  


            return View("agenda");


        }











        [HttpPost]
        public ActionResult date( FormCollection form)
        {


            try
            {

                string datedeb = form["DateDeb"];
                string datef = form["DateFin"];
                int id1 = Int32.Parse(form["id1"]);
                MyContext ctx = new MyContext();
                var plus = ctx.Programme.First(a => a.idRdv == id1);

                plus.DateDebutR = datedeb;
                plus.DateFinR =datef;
                

                ctx.Entry(plus).State = EntityState.Modified;
                ctx.SaveChanges();


                var PL = MS.GetById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));



                ViewBag.plus = PL; //objemp is employee class object  
                                   //OR You can use ViewBag OR ViewData.ViewData is more efficiant way as compare to ViewBag  
                ViewData["plus"] = PL; //objemp is employee class object  



                return View("agenda");
            }

            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("index");
            }








             
        }








        //////// KMAR 








        public ActionResult GetMedecins()
        {
            List<Medecin> list = new List<Medecin>();
            // list = this.GetMedecin();
            return View(list);

        }









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
            //             select a;
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

                 firstname == "" && lastname == "" && localisation != "" && specialite != "" ?
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
            var data = GetMedecin(firstname, lastname, specialite, localisation);
            ViewBag.TotalRows = totalRecord;
            //ViewBag.search = search;
            return View(data);
        }











    }
}
