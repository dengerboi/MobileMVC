using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileMVC.Models
{
    public class CustomProductOrder
    {
        public int ProductID { get; set; }
        public string Pname { get; set; }
        public string Pcat { get; set; }
        public int OrderID{ get; set; }
        public int qty { get; set; }
        public string PDesc { get; set; }
    }
}