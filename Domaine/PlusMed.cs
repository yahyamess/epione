using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public  class PlusMed
    {

        [Key]
        public int ID { get; set; }
        public  int  IDMed { get; set; }
        public String specialieProfondu { get; set; }
        public String Hopital { get; set; }



    }
}
