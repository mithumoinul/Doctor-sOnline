﻿using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace DoctorsOnline.Models
{
    public class DoctorsOnlineContext  : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; } 
        //public DbSet<LocationModel> LocationModels { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<DoctorsInfo> DoctorsInfos { get; set; }
        public DbSet<Organization> Organizations { get; set; } 
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Chamber> Chambers { get; set; } 
        public DbSet<Thana> Thanas { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; } 
        public DbSet<UserPassword> UserPassword { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    //base.OnModelCreating(modelBuilder);
        //}
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }

    
}