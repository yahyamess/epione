using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Notification
    {
        [Key]
        public int id { get; set; }
        public int idMedecin { get; set; }
        public int idPatient { get; set; }
        public string contenu { get; set; }
        public DateTime date { get; set; }
    }
}