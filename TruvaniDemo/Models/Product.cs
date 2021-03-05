using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruvaniDemo.Models
{
    public class Product
    {
        public int id { get; set; }

        public string name { get; set; }

        public double price { get; set; }

        public List<string> categories { get; set; }
    }
}