using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epione.Models
{
    public class ParcoursModel
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Nom et Prénom du medecin")]
        public String NomMedecin { get; set; }
        [Display(Name = "Specialité")]
        public String Specialite { get; set; }
        [Display(Name = "Maladie du patient")]
        public String Maladie { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Détails du cas du patient")]
        [DataType(DataType.MultilineText)]
        public String Etat { get; set; }
        public String Justification { get; set; }
        public String Adresse { get; set; }
        public int idPatient { get; set; }
        public int idMedecin { get; set; }
        public int idRDV { get; set; }
        [Display(Name = "Etat du Rendez-vous")]
        public string Etatrdv { get; set; }

    }
}