﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FstName { get; set; }
        public string Surname { get; set; }
        public bool Sex { get; set; }
        public int Height { get; set; }
        public int Email { get; set; }
        public byte[] Pass { get; set;} 
    }
}