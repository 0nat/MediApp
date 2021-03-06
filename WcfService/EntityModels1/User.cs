﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    [Serializable]
    public class User
    {
        public int   Id { get; set; }
        public string FstName { get; set; }
        public string Surname { get; set; }
        public int?  Pesel { get; set; }
        public string Email { get; set; }
        public byte[] Pass { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
