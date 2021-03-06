﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSecProject
{
    public class Subject
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public SecurityLevel RSL { get; set; }
        public SecurityLevel WSL { get; set; }
        public SecurityLevel RIL { get; set; }
        public SecurityLevel WIL { get; set; }
    }
}
