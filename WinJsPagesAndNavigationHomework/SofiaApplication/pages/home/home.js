/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="data.js" />
(function () {
    "use strict";

    WinJS.UI.Pages.define("/pages/home/home.html", {
        // This function is called whenever a user navigates to this page. It
        // populates the page elements with the app's data.
       
        ready: function (element, options) {

            var listView = document.getElementById("basicListView").winControl;
         
            listView.oniteminvoked = function (event) {
               
                var title = Data.itemList.getAt(event.detail.itemIndex).title;

                if (title=="History") {
                    goToHistory();
                }
                else if (title == "Culture") {
                    goToCulture();
                }
                else if (title=="Architecture") {
                    goToArchitecture();
                }
            };
        }
    });
})();

var goToHistory = function () {
    WinJS.Navigation.navigate("ms-appx:///pages/history/history.html");

};

var goToCulture = function () {
    WinJS.Navigation.navigate("ms-appx:///pages/culture/culture.html");

};

var goToArchitecture = function () {
    WinJS.Navigation.navigate("ms-appx:///pages/architecture/architecture.html");
};

