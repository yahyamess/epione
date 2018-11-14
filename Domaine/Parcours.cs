using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public   class Parcours
    {

        [Key]
        public String ParcoursID { get; set;  }
        public String IDPatient  { get; set; }
        public String IdMedecin { get; set; }

        public String NomMedecin { get; set; }

        public String  Specialite { get; set; }


        public String Maladie { get; set; }

        public DateTime date  { get; set; }
        public String Etat { get; set; }

        public String Justification { get; set; }

        public String  Adresse  { get; set; }
        
    }
}
