using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PropertyManager_VS.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public string PropertyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required, StringLength(5)]
        public string Zip { get; set; }
        [Required, StringLength(10)]
        public string ContactPhone { get; set; }
        public int Rent { get; set; }
        public int SqFt { get; set; }
        public int Bedrooms { get; set; }
        public float Bathrooms { get; set; }
        public bool PetFriendly { get; set; }
        public int LeaseTerms { get; set; }
        
       public string PropertyImage { get; set; } 
       public virtual User User { get; set; }

 

        



        
    }
}