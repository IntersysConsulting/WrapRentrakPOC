using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Data.Configuration;
using WrapRentrak.Model;

namespace WrapRentrak.Data
{
     [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ReportEntities:DbContext
    {

        public ReportEntities() : base("ReportEntitiesMySQL") { }

            public DbSet<Report> Reports { get; set; }
            public DbSet<Category> Categories { get; set; }
            //public DbSet<SingleMktGridReport> SingleMktGridReports { get; set; }

            public virtual void Commit()
            {
                try
                {
                    base.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new ReportConfiguration());
                modelBuilder.Configurations.Add(new CategoryConfiguration());
                //modelBuilder.Entity<SingleMktGridReport>().MapToStoredProcedures();
            }
                 
        
    }
}
