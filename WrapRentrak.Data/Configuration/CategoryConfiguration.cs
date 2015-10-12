using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Model;

namespace WrapRentrak.Data.Configuration
{
    public class CategoryConfiguration:EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            ToTable("Category");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
