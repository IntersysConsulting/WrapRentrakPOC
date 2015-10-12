var grid;
var columns = [
					{ id: "MarketName", name: "MarketName", field: "MarketName", width: 120 },
					{ id: "qhDateTime", name: "qhDateTime", field: "qhDateTime", width: 120 },
                    { id: "putHutDuring15Minutes", name: "putHutDuring15Minutes", field: "putHutDuring15Minutes", width: 120 },
                    { id: "rentrakStationNumber", name: "rentrakStationNumber", field: "rentrakStationNumber", width: 120 },
                    { id: "rentrakProgramNumber", name: "rentrakProgramNumber", field: "rentrakProgramNumber", width: 120 },
                    { id: "ratingDuring15Minutes", name: "ratingDuring15Minutes", field: "ratingDuring15Minutes", width: 120 },
                    { id: "shareDuring15Minutes", name: "shareDuring15Minutes", field: "shareDuring15Minutes", width: 120 },
];

var options = {
    enableCellNavigation: true,
    enableColumnReorder: false,
    
};

$(function () {
    var myData = [];
    $.getJSON('/Home/SingleDayGridSlick', function (data) {
        myData = data;
        grid = new Slick.Grid("#reportGrid", myData, columns, options);
    });
});