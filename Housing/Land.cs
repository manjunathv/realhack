//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Housing
{
    using System;
    using System.Collections.Generic;
    
    public partial class Land
    {
        public int Id { get; set; }
        public int LocailtyId { get; set; }
        public decimal Price { get; set; }
        public int Area { get; set; }
        public string Amenities { get; set; }
        public int Clicks { get; set; }
        public bool IsSold { get; set; }
        public int Year { get; set; }
    
        public virtual Locality Locality { get; set; }
    }
}
