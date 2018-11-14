using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Soin
    {
        [Key]
        public int id { get; set; }
        public int idMed { get; set; }
        public string soin { get; set; }
    }
}