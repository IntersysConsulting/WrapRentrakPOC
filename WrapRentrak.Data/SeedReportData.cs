using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Model;
using MySql.Data.MySqlClient;

namespace WrapRentrak.Data
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<ReportEntities>
    {
        protected override void Seed(ReportEntities context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetReports().ForEach(g => context.Reports.Add(g));

            context.Commit();
        }

        private static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category {
                    Name = "Single Day"
                },
                new Category {
                    Name = "Multi Day"
                },
                new Category {
                    Name = "Station Grid"
                }
            };
        }

        private static List<Report> GetReports()
        {
            return new List<Report>
            {
                 new Report {
                    Market="NY",
                    Station="ABC",
                    Date="08/03/2015",
                    Demo="Homes",
                    BroadcastTimeZone="All Time Zone",
                    StreamType="Latest",
                    CategoryId=1
                    
                },
                new Report {
                    Market="LA",
                    Station="CBS",
                    Date="08/03/2015",
                    Demo="Homes",
                    BroadcastTimeZone="All Time Zone",
                    StreamType="Latest",
                    CategoryId=1
                },
                new Report {
                    Market="Dallas",
                    Station="FOX",
                    Date="08/03/2015",
                    Demo="Homes",
                    BroadcastTimeZone="All Time Zone",
                    StreamType="Latest",
                    CategoryId=1
                },
                new Report {
                    Market="Chicago",
                    Station="WPIX",
                    Date="08/03/2015",
                    Demo="Homes",
                    BroadcastTimeZone="All Time Zone",
                    StreamType="Latest",
                    CategoryId=1
                }
            };
        }
    }
}
