/// <reference path="Gmo.js" />
/// <reference path="Vegetable.js" />
// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        var myGmoTomato = new Vegetables.GMO.TomatoGmo(2);
        console.log(myGmoTomato.radius);
        myGmoTomato.growByWater(2);
        console.log(myGmoTomato.color);
        console.log(myGmoTomato.canEatDirectly);
        console.log(myGmoTomato.radius);

        var myGmoCucumber = new Vegetables.GMO.CucumberGmo(1);
        console.log(myGmoCucumber.length);
        myGmoCucumber.growByWater(2);
        console.log(myGmoCucumber.color);
        console.log(myGmoCucumber.canEatDirectly);
        console.log(myGmoCucumber.length);
    };

    
    app.start();
})();
