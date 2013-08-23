/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="Vegetable.js" />


WinJS.Namespace.defineWithParent(Vegetables, "DirectlyEatable", {
    Tomato: WinJS.Class.derive(Vegetables.Vegetable, function  (dimension) {
        Vegetables.Vegetable.call(this, "red", true, dimension);
    }, {
        radius: {
            get: function () { return this._dimension; }
        }
    })
});