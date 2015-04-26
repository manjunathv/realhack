using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.Models
{
    public class MyFlat
    {
        public int Id { get; set; }
        public int LocalityId { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public string Amenities { get; set; }
        public int Clicks { get; set; }
        public bool IsSold { get; set; }
        public int Year { get; set; }
        
    }
}