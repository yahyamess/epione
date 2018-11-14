using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Domain
{
    public class Rating
    {
        [Key]
        public int idPat { get; set; }
        public int idMed { get; set; }
        public int nbrEtoile { get; set; }
    }
}