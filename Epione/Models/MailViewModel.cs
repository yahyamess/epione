﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epione.Models
{
    public class MailViewModel
    {
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}