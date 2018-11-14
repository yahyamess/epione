using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Epione.Models
{
 

        public class UserModel { 
            public String LastName { get; set; }
            public String FirstName { get; set; }
            public  String Email { get; set; }

            public string specialite { get; set; }
            public string source { get; set; }
            public string localisation { get; set; }

        }
    }
    