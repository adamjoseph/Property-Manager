using PropertyManager_VS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PropertyManager_VS.Infrastructure
{
    public class PropertyDataContext : DbContext
    {
        public PropertyDataContext() : base("PropertyManager")
        {

        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Property> Properties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //configure one: many: relationship user to property

            modelBuilder.Entity<User>()
                .HasMany(u => u.Properties)
                .WithRequired(p => p.User)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}