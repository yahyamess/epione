using Domain;
using Domaine;
using Epione.Models;
using Microsoft.AspNet.Identity;
using ServiceEpione;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Epione.Controllers
{
    [Authorize(Roles = "Patient")]
    public class ParcoursPatientController : Controller
    {
        // GET: ParcoursPatient
        public ActionResult Index()
        {
            ParcoursService ps = new ParcoursService();
            var parcours = ps.GetAll();
            List<ParcoursModel> y = new List<ParcoursModel>();
            foreach (var item in parcours)
            {

                y.Add(
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

            List<ParcoursModel> fVm2 = y.Where(par => par.idPatient == Int32.Parse(System.Web.HttpContext.Current.User.Identity.GetUserId())).ToList();
            return View(fVm2);
        }

        // GET: ParcoursPatient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParcoursPatient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParcoursPatient/Create
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

        // GET: ParcoursPatient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParcoursPatient/Edit/5
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

        // GET: ParcoursPatient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParcoursPatient/Delete/5
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
