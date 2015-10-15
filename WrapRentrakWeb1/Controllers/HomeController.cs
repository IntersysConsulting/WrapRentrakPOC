using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WrapRentrak.Model;
using WrapRentrak.Report.Service;
using WrapRentrak.Reports.Service;
using WrapRentrakWeb1.ViewModel;
using DevExpress.Web.Mvc;
using System.Web.Script.Serialization;
using Trirand.Web.Mvc;
using System.Text.RegularExpressions;

namespace WrapRentrakWeb1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IReportService reportService;
        private readonly ISingleMktGridReportService singleMktGridReportService;

        public HomeController(ICategoryService categoryService, IReportService reportService, ISingleMktGridReportService singleMktGridReportService)
        {
            this.categoryService = categoryService;
            this.reportService = reportService;
            this.singleMktGridReportService = singleMktGridReportService;
        }

        // GET: Home
        public ActionResult Index(string category = null)
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            IEnumerable<Category> categories=new List<Category>();

            //categories = categoryService.GetCategories(category).ToList();

            viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            return View(viewModelGadgets);
        }

        public ActionResult SlickReport()
        {
           return View();
        }
        public ActionResult SlickGridRemoteData()
        {
            return View();
        }

        public ActionResult Filter(string category, string reportName)
        {
            IEnumerable<ReportViewModel> viewModelReports;
            IEnumerable<Report> reports=new List<Report>();

            //reports = reportService.GetCategoryGadgets(category, reportName);

            viewModelReports = Mapper.Map<IEnumerable<Report>, IEnumerable<ReportViewModel>>(reports);

            return View(viewModelReports);
        }

        [HttpPost]
        public ActionResult Create(ReportFormViewModel newReport)
        {
            if (newReport != null)
            {
                var report = Mapper.Map<ReportFormViewModel, Report>(newReport);
                reportService.CreateReport(report);

                reportService.SaveReport();
            }

            var category = categoryService.GetCategory(newReport.ReportCategory);
            return RedirectToAction("Index", new { category = category.Name });
        }

        [ValidateInput(false)]
        public ActionResult SingleDayGridPartial()
        {
            IEnumerable<CategoryViewModel> viewModelGadgets;
            IEnumerable<Category> categories=new List<Category>();
            IEnumerable<SingleMktGridReport> singleMktGridReports;
            singleMktGridReports = singleMktGridReportService.GetSingleMktGridReports("753", "9959", "01/01/2015", "09/30/2015", "379");

            //categories = categoryService.GetCategories().ToList();
            
            viewModelGadgets = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(categories);
            //return View(viewModelGadgets);
            //var model = viewModelGadgets.FirstOrDefault().Reports;
            var model = singleMktGridReports;
            return PartialView("_SingleDayGridPartial", model);
        }

        public string SingleDayGridSlick()
        {
            IEnumerable<SingleMktGridReport> singleMktGridReports;
            singleMktGridReports = singleMktGridReportService.GetSingleMktGridReports("753", "9959", "01/01/2015", "09/30/2015", "379");
            var model = singleMktGridReports;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            string serializedData=serializer.Serialize(model);
            return serializedData;
        }

        public string SingleDayGridSlickPaging(int start,int limit)
        {
            if (start == 0) start = 0;
            if (limit == 0) limit = 100;
            IEnumerable<SingleMktGridReport> singleMktGridReports;
            singleMktGridReports = singleMktGridReportService.GetSingleMktGridReportsPaging("753", "9959", "01/01/2015", "09/30/2015", "379",start,limit);
            var model = singleMktGridReports;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            string serializedData = serializer.Serialize(model);
            return serializedData;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult SingleDayGridPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] WrapRentrakWeb1.ViewModel.ReportViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_SingleDayGridPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SingleDayGridPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] WrapRentrakWeb1.ViewModel.ReportViewModel item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_SingleDayGridPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult SingleDayGridPartialDelete(System.String ReportName)
        {
            var model = new object[0];
            if (ReportName != null)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_SingleDayGridPartial", model);
        }

        public ActionResult JQGrid()
        {
            // Get the model (setup) of the grid defined in the /Models folder.
            var gridModel = new RentrakJqGridModel();
            var ordersGrid = gridModel.RentrakGrid;

            // customize the default Orders grid model with custom settings
            // NOTE: you need to call this method in the action that fetches the data as well,
            // so that the models match
            SetUpGrid(ordersGrid);

            // Pass the custmomized grid model to the View
            return View(gridModel);
        }

        private void SetUpGrid(JQGrid rentrakGrid)
        {
            // Customize/change some of the default settings for this model
            // ID is a mandatory field. Must by unique if you have several grids on one page.
            rentrakGrid.ID = "id";
            // Setting the DataUrl to an action (method) in the controller is required.
            // This action will return the data needed by the grid
            rentrakGrid.DataUrl = Url.Action("SearchGridDataRequested");
            
            // show the search toolbar
            //rentrakGrid.ToolBarSettings.ShowSearchToolBar = true;
            //rentrakGrid.Columns.Find(c => c.DataField == "OrderID").Searchable = false;
            //rentrakGrid.Columns.Find(c => c.DataField == "OrderDate").Searchable = false;

            //SetUpCustomerIDSearchDropDown(ordersGrid);
            //SetUpFreightSearchDropDown(ordersGrid);
            //SetShipNameSearchDropDown(ordersGrid);

            //ordersGrid.ToolBarSettings.ShowEditButton = true;
            //ordersGrid.ToolBarSettings.ShowAddButton = true;
            //ordersGrid.ToolBarSettings.ShowDeleteButton = true;
            //ordersGrid.EditDialogSettings.CloseAfterEditing = true;
            //ordersGrid.AddDialogSettings.CloseAfterAdding = true;

            // setup the dropdown values for the CustomerID editing dropdown
            //SetUpCustomerIDEditDropDown(ordersGrid);
        }

        public JsonResult SearchGridDataRequested()
        {
            // Get both the grid Model and the data Model
            // The data model in our case is an autogenerated linq2sql database based on Northwind.
            var gridModel = new RentrakJqGridModel();
            IEnumerable<SingleMktGridReport> singleMktGridReports;
            singleMktGridReports = singleMktGridReportService.GetSingleMktGridReports("753", "9959", "01/01/2015", "09/30/2015", "379");


            // customize the default Orders grid model with our custom settings
            SetUpGrid(gridModel.RentrakGrid);

            // return the result of the DataBind method, passing the datasource as a parameter
            // jqGrid for ASP.NET MVC automatically takes care of paging, sorting, filtering/searching, etc
            return gridModel.RentrakGrid.DataBind(singleMktGridReports);
        }

        public ActionResult FlexiciousGrid()
        {
            //IEnumerable<SingleMktGridReport> singleMktGridReports;
            //singleMktGridReports = singleMktGridReportService.GetSingleMktGridReports("753", "9959", "01/01/2015", "09/30/2015", "379");
            //var model = singleMktGridReports;
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //serializer.MaxJsonLength = Int32.MaxValue;
            //string serializedData = serializer.Serialize(model);
            return View();
        }

        public JsonResult FlexiciousSMGridjson()
        {
            //string serializedData = "";
            List<SMGrid> singleMktGridReports=new List<SMGrid>();
            IEnumerable<SingleMktGridReport> report;
            report = singleMktGridReportService.GETSMData("753", "9959", "01/01/2015", "09/30/2015", "379");
            //var model = singleMktGridReports;
            //use sample data

            Regex reg = new Regex(".*?T(?<time>\\d+)00");
            foreach (SingleMktGridReport r in report)
            {
                Match m = reg.Match(r.qhDateTime);
                string time = "";
                if (m.Success)
                {
                    time = m.Groups["time"].Value;
                }
                singleMktGridReports.Add(new SMGrid(time,"Telemundo cable","Saturday night live",r.ratingDuring15Minutes,r.shareDuring15Minutes));
            }
           
            var model = singleMktGridReports;
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            //serializer.MaxJsonLength = Int32.MaxValue;
            //serializedData = serializer.Serialize(model);
            string config = getConfig();
            var result = new {data1 = model, data2 = config};
            return Json(result,JsonRequestBehavior.AllowGet);

        }

        private string getConfig()
        {
            string config = "";
            string path = HttpContext.Server.MapPath("~/App_Data/SMGridConfig.xml");
            config=System.IO.File.ReadAllText(path);
            return config;
        }

        public ActionResult FlexiciousSMGrid()
        {
            return View();

        }

        public ActionResult FlexiciousVirtualScroll()
        {
           return View();
        }
    }
}