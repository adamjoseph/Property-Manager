﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyManager_VS.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool PropertyManager { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}