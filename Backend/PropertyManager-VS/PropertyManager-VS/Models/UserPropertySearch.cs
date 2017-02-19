using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager_VS.Models
{
    public class UserPropertySearch
    {
        
        public string UserName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public int MinRent { get; set; }
        public int MaxRent { get; set; }
        public int Bedrooms { get; set; }
        public float Bathrooms { get; set; }
    }
}