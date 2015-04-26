using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Housing.Models
{
    public class MyTrending
    {
        public int Id { get; set; }
        public int LocalityId { get; set; }
        public int Sales { get; set; }
        public int Amenities { get; set; }
        public int Security { get; set; }
        public int Rating { get; set; }
        public int CityId { get; set; }
        public string LocalityName { get; set; }
    }
}