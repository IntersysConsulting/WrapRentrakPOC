using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Model;

namespace WrapRentrak.Data.Configuration
{
    public class ReportConfiguration: EntityTypeConfiguration<Report>
    {
        public ReportConfiguration()
        {
            ToTable("Report");
            Property(r => r.CategoryId).IsRequired();
            //Property(r => r.ReportName).IsRequired().HasMaxLength(50);
            Property(r => r.Market).IsRequired().HasMaxLength(50);
            Property(r => r.Station).IsRequired().HasMaxLength(50);
            Property(r => r.Date).IsRequired().HasMaxLength(50);
            Property(r => r.Demo).IsRequired().HasMaxLength(50);
            Property(r => r.BroadcastTimeZone).IsRequired().HasMaxLength(50);
            Property(r => r.StreamType).IsRequired().HasMaxLength(50);
            //Property(r => r.ExcludedStations).IsRequired().HasMaxLength(50);
        }
    }
}
