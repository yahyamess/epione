using Domain;
using Epione.Models;
using Microsoft.AspNet.Identity;
using Models;
using ServiceEpione;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Epione.Controllers
{
    public class RDVController : Controller
    {



        RDVService Rod = new RDVService();
        // GET: RDV


        public ActionResult Index()
        {

            var ress = Rod.GetAll();

            List<RDVModels> mvp = new List<RDVModels>();
            foreach (var item in ress)
            {
                if (item.idPatient == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()))
                {
                    mvp.Add(
                        new RDVModels
                        {
                            id = item.id,
                            nom = item.nom,
                            prenom = item.prenom,
                            date = item.date,
                            ville = item.ville,
                            maladi = item.maladi,


                        });
                }
            }
            return View(mvp);
        }



        // GET: RDV/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RDV/Create
        public ActionResult Create()
        {
            RDVModels rd = new RDVModels();
            return View(rd);
        }

        // POST: RDV/Create
        [HttpPost]
        public ActionResult Create(RDVModels Rd , int id1)
        {
            try
            {
                RDV r = new RDV
                {
                    date = Rd.date,
                    maladi = Rd.maladi,
                    nom = Rd.nom,
                    prenom = Rd.prenom,
                    ville = Rd.ville,
                    id = Rd.id ,
                    idMedecin = id1 ,
                    idPatient = 41 , 
                };

                Rod.Add(r);
                Rod.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RDV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RDV/Edit/5







        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RDV R)
        {
            try
            {
                Domain.RDV ress = Rod.GetById(id);
                ress.nom = R.nom;
                ress.prenom = R.prenom;
                ress.date = R.date;
                ress.ville = R.ville;
                ress.maladi = R.maladi;

                Rod.add(ress);
                Rod.Commit();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();

            }
        }


        // GET: RDV/Delete/5
        public ActionResult Delete(int id)
        {
            var d = Rod.GetById(id);
            Rod.Delete(d);
            Rod.Commit();
            return Redirect(Request.UrlReferrer.ToString());
        }

        // POST: RDV/Delete/5
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


       

        
        public ActionResult Mail()
        {
           
            return View();
        }
        [HttpPost]

        public ActionResult Mail(MailViewModel mvm)
        {


            MailMessage mail = new MailMessage("EpionePidev@esprit.tn", mvm.Reciever, mvm.Subject, mvm.Message);
            mail.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;

            smtpClient.Credentials = new System.Net.NetworkCredential("EpionePidev@gmail.com", "epionepidev123");
            smtpClient.Send(mail);
            //!MAIL

            //!MAIL
            return View();
        }
        //MAIL





    }

}

