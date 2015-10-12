using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WrapRentrak.Model;

namespace WrapRentrakWeb1.ViewModel
{
    public class CategoryViewModel
    {
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public virtual List<ReportViewModel> Reports { get; set; }
        
    }
}