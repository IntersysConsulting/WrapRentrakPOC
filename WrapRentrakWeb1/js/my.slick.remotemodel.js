(function ($) {
    /***
    * Ajax loading example which is an extension
    * of the http://mleibman.github.com/SlickGrid/examples/example6-ajax-loading.html
    * example.
    */
    function RemoteModel() {
        // private

        var fromPage = 0; 
        var rows = 0; 

        var PAGESIZE = 100; 
        var data = { length: 0 };
        var h_request = null;
        var req = null; // ajax request

        // events
        var onDataLoading = new Slick.Event();
        var onDataLoaded = new Slick.Event();


        function init() {
        }


        function isDataLoaded(from, to) {
            for (var i = from; i <= to; i++) {
                if (data[i] == undefined || data[i] == null)
                    return false;
            }

            return true;
        }


        function clear() {
            for (var key in data) {
                delete data[key];
            }
            data.length = 0;
        }


        function ensureData(from, to) {

            if (req) {
                req.abort();

                for (var i = req.fromPage; i <= req.toPage; i++)
                    data[i * PAGESIZE] = undefined;
            }

            if (from < 0)
                from = 0;

            fromPage = Math.floor(from / PAGESIZE);
            var toPage = Math.floor(to / PAGESIZE);

            while (data[fromPage * PAGESIZE] !== undefined && fromPage < toPage)
                fromPage++;

            while (data[toPage * PAGESIZE] !== undefined && fromPage < toPage)
                toPage--;

            rows = (((toPage - fromPage) * PAGESIZE) + PAGESIZE);

            if (fromPage > toPage || ((fromPage == toPage) && data[fromPage * PAGESIZE] !== undefined)) {

                // TODO:  look-ahead
                return;
            }
            //alert(from + " " + to);
            var url = "/Home/SingleDayGridSlickPaging?start=" + (fromPage * PAGESIZE) + "&limit=" + (((toPage - fromPage) * PAGESIZE) + PAGESIZE);

            if (h_request != null) {
                clearTimeout(h_request);
            }

            h_request = setTimeout(function () {

                for (var i = fromPage; i <= toPage; i++)
                    data[i * PAGESIZE] = null; // null indicates a 'requested but not available yet'

                onDataLoading.notify({ from: from, to: to });

                req = $.ajax({
                    url: url,
                    dataType: 'json',
                    success: function (response) {
                        onSuccess(response);
                    },
                    error: function () {
                        onError(fromPage, toPage);
                    }
                });


                req.fromPage = fromPage;
                req.toPage = toPage;

            }, 100);
        }


        function onError(fromPage, toPage) {
            alert("error loading pages " + fromPage + " to " + toPage);
        }

        function onSuccess(response) {

            //Solution to keep the data array bounded to pagesize: Call the clear method to have only PAGESIZE elements in the data array at any given point
            //clear(); 

            //The visisble # of rows in the viewport could be only ~20 but
            // i'm populating PageSIZE which acts like the client-side cache, in my case 250,
            // so that I avoid too many server hops
            var from = fromPage * PAGESIZE, to = from + PAGESIZE;

            data.length = 20000;
            //alert(response.length);
            for (var i = 0; i < response.length; i++) {
                data[from + i] = response[i];
                data[from + i].index = from + i;
            }

            req = null;

            onDataLoaded.notify({ from: from, to: to });
        }


        function reloadData(from, to) {
            for (var i = from; i <= to; i++)
                delete data[i];

            ensureData(from, to);
        }


        init();

        return {
            // properties
            "data": data,

            // methods
            "clear": clear,
            "isDataLoaded": isDataLoaded,
            "ensureData": ensureData,
            "reloadData": reloadData,

            // events
            "onDataLoading": onDataLoading,
            "onDataLoaded": onDataLoaded
        };
    }

    // Slick.Data.RemoteModel
    $.extend(true, window, { Slick: { Data: { RemoteModel: RemoteModel}} });
})(jQuery);
