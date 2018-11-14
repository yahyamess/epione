using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
    public class Parcours
    {
        [Key]
        public int id { get; set; }
        public String NomMedecin { get; set; }
        public String Specialite { get; set; }
        public String Maladie { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [DataType(DataType.MultilineText)]
        public String Etat { get; set; }
        public String Justification { get; set; }
        public String Adresse { get; set; }
        public int idPatient { get; set; }
        public int idMedecin { get; set; }
        public int idRDV { get; set; }
        public string Etatrdv { get; set; }
    }
}
