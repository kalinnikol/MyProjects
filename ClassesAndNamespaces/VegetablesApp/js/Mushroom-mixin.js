/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

WinJS.Namespace.define("MyMixins", {
    Mashroom: {
        _dimension:"",
        growByWater: function (waterAmountLitters) {
            if (this._dimension) {
                this._dimension = this._dimension * waterAmountLitters;
            }
        }
    }
});