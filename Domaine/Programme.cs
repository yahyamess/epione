using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Programme
    {
        [Key]
        public int id { get; set; }
        public int idMed { get; set; }
        public int idRdv { get; set; }

        public string ville { get; set; }
        public string maladi { get; set; }
       
        public string DateDebutR { get; set; }
        public string DateFinR { get; set; }
    }
}