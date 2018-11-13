using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public class Motif
    {
        [Key]
        public int motifID { get; set; }
        public int idPatient { get; set; }
        public String description { get; set; }
        

    }
}
