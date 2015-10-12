using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WrapRentrak.Model;
using WrapRentrakWeb1.ViewModel;

namespace WrapRentrakWeb1.Mappings
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ReportFormViewModel, Report>()
                .ForMember(g => g.ReportName, map => map.MapFrom(vm => vm.ReportTitle))
                .ForMember(g => g.Station, map => map.MapFrom(vm => vm.ReportStation))
                .ForMember(g => g.Market, map => map.MapFrom(vm => vm.ReportMarket))
                .ForMember(g => g.ReportName, map => map.MapFrom(vm => vm.Name));
        }
    }
}