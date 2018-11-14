using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public  class PlusMed
    {
        [Key]
        public  int  MedID { get; set; }
        public String specialieProfondu { get; set; }
        public String Hopital { get; set; }



    }
}
