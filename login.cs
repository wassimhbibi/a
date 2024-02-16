using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IjaEkri.Models
{
    public class login
    {
        public int id { get; }

        public string email { get; set; }
        public string password { get; set; }
        public int phone { get; set; }
        public string role { get; set; }

    }
}