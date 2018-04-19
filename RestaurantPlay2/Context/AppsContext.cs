using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using RestaurantPlay2.Entities.Blog;
using RestaurantPlay2.Entities.Person;


namespace RestaurantPlay2.Context
{
    public class AppsContext:DbContext
    {
        
        public IDbSet<COREPerson> Persons { get; set; }
        public IDbSet<BLOGDetail> BlogDetails { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AppsContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}