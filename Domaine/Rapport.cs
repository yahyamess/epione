using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Rapport
    {
        [Key]
        public int id { get; set; }
        public int idMed { get; set; }
        public int idPet { get; set; }
        public string picture { get; set; }
        public string description { get; set; }
    }
}