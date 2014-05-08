using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WikiApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WikiApp.DAL
{
    public class SubtitleContext : DbContext
    {
        public SubtitleContext() : base("SubtitleContext")
        {

        }

        public DbSet<SubtitleFile> SubtitleFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove <PluralizingTableNameConvention>();
        }
    }
}