using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain
{
    public class RDV
    {

        [Key]
        
        public int id { get; set; }
        public int idPatient { get; set; }
        public int idMedecin { get; set; }
        
        public string nom { get; set; }
        public string prenom { get; set; }
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        public string ville { get; set; }
        public string maladi { get; set; }
    }
}