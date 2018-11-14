
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Medecin : User


    {

       
       // public int idMedecin { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string specialite { get; set; }
        public string source { get; set; }
        public string localisation { get; set; }
    }
}