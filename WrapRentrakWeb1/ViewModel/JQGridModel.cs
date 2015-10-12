using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Trirand.Web.Mvc;

namespace WrapRentrakWeb1.ViewModel
{
    public class RentrakJqGridModel
    {
        public RentrakJqGridModel()
        {
            RentrakGrid = new JQGrid
            {
                Columns = new List<JQGridColumn>()
                                 {
                                     new JQGridColumn { DataField = "ID", 
                                                        // always set PrimaryKey for Add,Edit,Delete operations
                                                        // if not set, the first column will be assumed as primary key
                                                        PrimaryKey = true,
                                                        Editable = false,
                                                        Width = 50 },
                                     new JQGridColumn { DataField = "Market", 
                                                        Editable = true,
                                                        Width = 200},
                                     new JQGridColumn { DataField = "Episode", 
                                                        Editable = true,
                                                        Width = 200 },
                                     new JQGridColumn { DataField = "Series", 
                                                        Editable = true,
                                                        Width = 200 },
                                     new JQGridColumn { DataField = "Station",
                                                        Editable =  true,
                                                        Width = 200
                                                      }                                     
                                 },
                Width = Unit.Pixel(850)
            };

            RentrakGrid.ToolBarSettings.ShowRefreshButton = true;
        }

        public JQGrid RentrakGrid { get; set; }
    }
}