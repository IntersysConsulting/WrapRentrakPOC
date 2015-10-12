using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WrapRentrak.Model;
using WrapRentrakWeb1.ViewModel;

namespace WrapRentrakWeb1.Mappings
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Report, ReportViewModel>();
        }
    }
}