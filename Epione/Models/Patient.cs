﻿using Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Patient : User
    {
       
         // public int id { get; set; }
        public int idSocial { get; set; }

    }
}