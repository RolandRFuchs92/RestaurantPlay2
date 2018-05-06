﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.ImageItem;

namespace DataAccess.Context
{
    public class AppsContext : DbContext
    {
        //public AppsContext()
        //{
        //    new AppsContext().Configuration.LazyLoadingEnabled = true;
        //}

        public IDbSet<COREContent> CoreContents { get; set; }
        public IDbSet<IMAGEItem> ImageItems { get; set; }
        public IDbSet<Entities.MenuItem> MenuItems { get; set; }
        public IDbSet<MenuItemSetting> MenuItemSettings { get; set; }
        public IDbSet<MenuItemType> MenuItemTypes { get; set; }
        public IDbSet<MenuItemCategory> MenuItemCategories { get; set; }
        public IDbSet<FoodPreference> FoodPreferences { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AppsContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
