using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressAppMVC.Models
{
    public class AddressVM
    {
        public int id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string county { get; set; }
    }
}