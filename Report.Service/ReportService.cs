using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WrapRentrak.Model;
using WrapRentrak.Data;
using WrapRentrak.Data.Repositories;
using WrapRentrak.Data.Infrastructure;

namespace WrapRentrak.Reports.Service
{
    public interface IReportService
    {
        IEnumerable<WrapRentrak.Model.Report> GetReports();
        IEnumerable<WrapRentrak.Model.Report> GetCategoryGadgets(string categoryName, string gadgetName = null);
        WrapRentrak.Model.Report GetReport(int id);
        void CreateReport(WrapRentrak.Model.Report gadget);
        void SaveReport();
    }

    public class ReportService : IReportService
    {
        private readonly IReportRepository reportsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReportService(IReportRepository reportsRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.reportsRepository = reportsRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IReportService Members

        public IEnumerable<WrapRentrak.Model.Report> GetReports()
        {
            var gadgets = reportsRepository.GetAll();
            return gadgets;
        }

        public IEnumerable<WrapRentrak.Model.Report> GetCategoryGadgets(string categoryName, string gadgetName = null)
        {
            var category = categoryRepository.GetCategoryByName(categoryName);
            return category.Reports.Where(g => g.ReportName.ToLower().Contains(gadgetName.ToLower().Trim()));
        }

        public WrapRentrak.Model.Report GetReport(int id)
        {
            var gadget = reportsRepository.GetById(id);
            return gadget;
        }

        public void CreateReport(WrapRentrak.Model.Report gadget)
        {
            reportsRepository.Add(gadget);
        }

        public void SaveReport()
        {
            unitOfWork.Commit();
        }

        #endregion

    }
}
