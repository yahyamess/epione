﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Programme
    {
        [Key]
        public int id { get; set; }
        public int idMed { get; set; }
        public int idRdv { get; set; }
        public string DateDebutR { get; set; }
        public string DateFinR { get; set; }
    }
}