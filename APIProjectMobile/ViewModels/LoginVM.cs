﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.ViewModels
{
    public class LoginVM
    {
        public int AccId { get; set; }
        public string AccName { get; set; }
        public string AccImage { get; set; }
        public string AccEmail { get; set; }
        public int AccRole { get; set; }
    }
}
