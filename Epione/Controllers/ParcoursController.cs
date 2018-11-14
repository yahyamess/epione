using Domain;
using Domaine;
using Epione.Models;
using ServiceEpione;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Net;
using DATA;

namespace Epione.Controllers
{
    [Authorize(Roles = "Medecin")]
    public class ParcoursController : Controller
    {
        //////////////////////////////////////////////////////////////////////
        UserService us = new UserService();
        public string FindMailOfUserById(int id)
        {

            string y = us.GetById(id).Email;
            return y;
        }
        public string FindPasswordOfUserById(int id)
        {

            string y = us.GetById(id).Password;
            return y;
        }
        public string FindFirstNameOfUserById(int id)
        {

            string y = us.GetById(id).FirstName;
            return y;
        }
        public string FindLastNameOfUserById(int id)
        {

            string y = us.GetById(id).LastName;
            return y;
        }
       


        //////////////////////////////////////////////////////////////////////
        ParcoursService ps = new ParcoursService();
        public Parcours FindParcoursById(int id)
        {
            Parcours y = ps.GetById(id);
            return y;
        }

        public  ActionResult ChangeEtat(int idParcours,ParcoursModel pm,int idPatientt)
        {
            var parcourrs = new Parcours { id = idParcours,Etatrdv="Consultation terminée" };
            using (var db = new MyContext())
            {
                db.parcours.Attach(parcourrs);
                db.Entry(parcourrs).Property(x => x.Etatrdv).IsModified = true;
                db.SaveChanges();
            }
            Parcours p = new Parcours();
            p.idPatient = pm.idPatient = idPatientt;

            return RedirectToAction("Index", new
            {
                idPatientt = pm.idPatient
            });

        }

    // GET: Parcours
    public ActionResult Index(int idPatientt)
        {
            var parcours = ps.GetAll();

            List<ParcoursModel> fVM = new List<ParcoursModel>();
           
            foreach (var item in parcours)
            {

                fVM.Add(
                    new ParcoursModel
                    {
                        NomMedecin = item.NomMedecin,
                        Specialite = item.Specialite,
                        id = item.id,
                        Maladie = item.Maladie,
                        date = item.date,
                        Etat = item.Etat,
                        Justification = item.Justification,
                        Adresse = item.Adresse,
                        idPatient = item.idPatient,
                        idMedecin = item.idMedecin,
                        idRDV = item.idRDV,
                        Etatrdv = item.Etatrdv,
                    });
            }
            List<ParcoursModel> fVm2 =fVM.Where(par => par.idPatient == idPatientt).ToList();
            return View(fVm2);
        }



        public JsonResult IndexJson(int idPatientt)
        {
            var parcours = ps.GetAll();

            List<ParcoursModel> fVM = new List<ParcoursModel>();

            foreach (var item in parcours)
            {

                fVM.Add(
                    new ParcoursModel
                    {
                        NomMedecin = item.NomMedecin,
                        Specialite = item.Specialite,
                        id = item.id,
                        Maladie = item.Maladie,
                        date = item.date,
                        Etat = item.Etat,
                        Justification = item.Justification,
                        Adresse = item.Adresse,
                        idPatient = item.idPatient,
                        idMedecin = item.idMedecin,
                        idRDV = item.idRDV,
                        Etatrdv = item.Etatrdv,
                    });
            }
            List<ParcoursModel> fVm2 = fVM.Where(par => par.idPatient == idPatientt).ToList();
            return Json(fVM, JsonRequestBehavior.AllowGet);
        }














        // GET: Parcours/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parcours/Create
        public ActionResult Create(int idPatientt, ParcoursModel pm)
        {
            Parcours p = new Parcours();
            p.idPatient = pm.idPatient=idPatientt;
            return View(new ParcoursModel() { date = DateTime.Now ,idPatient=idPatientt,idMedecin = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()),idRDV=0,Etatrdv="Pas encore"});
        }

        // POST: Parcours/Create
        [HttpPost]
        public ActionResult Create(ParcoursModel pm)
        {
            Parcours p = new Parcours();
            if (ModelState.IsValid)
            {
                p.NomMedecin = pm.NomMedecin;
                p.Specialite = pm.Specialite;
                p.id = pm.id;
                p.Maladie = pm.Maladie;
                p.date = pm.date;
                p.Etat = pm.Etat;
                p.Justification = pm.Justification;
                p.Adresse = pm.Adresse;
                p.idPatient = pm.idPatient;
                p.idMedecin = pm.idMedecin;
                p.idRDV = pm.idRDV;
                p.Etatrdv = pm.Etatrdv;
                ps.Add(p);
                ps.Commit();

                
                /////////////////////

                var senderemail = new MailAddress(FindMailOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())), "Recommandation Spécialiste");
                var receiveremail = new MailAddress(FindMailOfUserById(p.idPatient), "Receiver");
                var password = FindPasswordOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()));
                var sub = "Un rendez-vous";
               
                var body = string.Concat("Bonjour je suis votre Docteur Mr/Mme "+ FindFirstNameOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()))+" "+ FindLastNameOfUserById(Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()))+" , je voulais vous informer que je vous ai planifié un nouveau rendez-vous avec "+ Request["NomMedecin"].ToString() +" Spécialisé en "+ Request["Specialite"].ToString() + " veuillez consulter votre parcours et merci d'attendre la confirmation du docteur que je vous ai recommandé");
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderemail.Address, password)

                };
                using (var mess = new MailMessage(senderemail, receiveremail)
                {
                    Subject = "Proposition Rendez-vous",
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                /////////////////////

                return RedirectToAction("Index", new
                {
                    idPatientt = pm.idPatient
                });

            }
            return View(p);

        }

        // GET: Parcours/Edit/5
        public ActionResult Edit(int idPatientt,int id, ParcoursModel pm)
        {
            Parcours p = new Parcours();
            p.idPatient = pm.idPatient = idPatientt;
            return View(new ParcoursModel() { date = DateTime.Now, idPatient = idPatientt, idMedecin = Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId()),idRDV=0,Etatrdv="Pas encore" });
        }

        // POST: Parcours/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ParcoursModel pm)
        {
            try
            {
                Parcours parcourss = ps.GetById(id);
                parcourss.NomMedecin = pm.NomMedecin;
                parcourss.Specialite = pm.Specialite;
                parcourss.id = pm.id;
                parcourss.Maladie = pm.Maladie;
                parcourss.date = pm.date;
                parcourss.Etat = pm.Etat;
                parcourss.Justification = pm.Justification;
                parcourss.Adresse = pm.Adresse;
                parcourss.idPatient = pm.idPatient;
                parcourss.idMedecin = pm.idMedecin;
                parcourss.idRDV = pm.idRDV;
                parcourss.Etatrdv = pm.Etatrdv;
                ps.Update(parcourss);
                ps.Commit();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Edit", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index", new
            {
                idPatientt = pm.idPatient
            });
        }

        // GET: Parcours/Delete/5
        public ActionResult Delete(int idPatientt, int id,ParcoursModel pm)
        {
            Parcours p = new Parcours();
            p.idPatient = pm.idPatient = idPatientt;
            return View(new ParcoursModel() { idPatient = idPatientt });
        }

        // POST: Parcours/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,FormCollection collection, ParcoursModel pm)
        {
            {
                try
                {
                    Parcours parcourss = ps.GetById(id);
                    parcourss.NomMedecin = pm.NomMedecin;
                    parcourss.Specialite = pm.Specialite;
                    parcourss.id = pm.id;
                    parcourss.Maladie = pm.Maladie;
                    parcourss.date = pm.date;
                    parcourss.Etat = pm.Etat;
                    parcourss.Justification = pm.Justification;
                    parcourss.Adresse = pm.Adresse;
                    parcourss.idPatient = pm.idPatient;
                    parcourss.idMedecin = pm.idMedecin;
                    parcourss.idRDV = pm.idRDV;
                    parcourss.Etatrdv = pm.Etatrdv;
                    ps.Delete(parcourss);
                    ps.Commit();
                }
                catch (DataException/* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    return RedirectToAction("Delete", new { id = id, saveChangesError = true });
                }
                //return RedirectToAction("Index");
                return RedirectToAction("Index", new
                {
                    idPatientt = pm.idPatient
                });


            }

        }
    }
}
