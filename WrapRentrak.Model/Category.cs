using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapRentrak.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
        public virtual List<Report> Reports { get; set; }
        public Category()
        {
            DateCreated = DateTime.Now.ToString();
        }
    }
}
