using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class PlusMedModel
    {

        [Key]
   
        public  int  IDMed { get; set; }
        public String specialieProfondu { get; set; }
        public String Hopital { get; set; }
        public string image { get; set;  }



    }
}
