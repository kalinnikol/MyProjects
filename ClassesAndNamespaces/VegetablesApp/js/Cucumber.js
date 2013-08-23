/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="Vegetable.js" />

WinJS.Namespace.defineWithParent(Vegetables, "IndirectlyEatable", {
    Cucumber: WinJS.Class.derive(Vegetables.Vegetable, function (dimension) {
        Vegetables.Vegetable.call(this, "green", false, dimension);
    }, {
        length: {
            get: function () { return this._dimension; }
        }
    })
});