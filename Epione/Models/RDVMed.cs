using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class RDVMed
    {

        [Key]
        public int id { get; set; }
        public int idPatient { get; set; }
        public int idMedecien { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime date { get; set; }
        public string ville { get; set; }
        public string maladi { get; set; }
    }
}