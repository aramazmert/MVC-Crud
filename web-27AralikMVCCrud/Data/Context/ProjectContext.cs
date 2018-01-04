using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using web_27AralikMVCCrud.Data.Entities;
using web_27AralikMVCCrud.Data.Mappings;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace web_27AralikMVCCrud.Data.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext():base("name=dbConn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectContext>());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            //Tablo adlarınının sonundaki s takısını kaldırmak için yazılan kod.
            modelBuilder.Conventions.Add(new PluralizingTableNameConvention());
        }

    }
}