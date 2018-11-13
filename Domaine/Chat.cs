using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Chat
    {
        [Key]
        public int id { get; set; }
        public int idPat { get; set; }
        public int idMed { get; set; }
        public string contenu { get; set; }
        public DateTime date { get; set; }
        public Boolean etat { get; set; }
    }
}