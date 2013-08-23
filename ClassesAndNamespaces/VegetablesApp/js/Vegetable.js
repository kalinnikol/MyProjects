/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />


WinJS.Namespace.define("Vegetables", {

    Vegetable: WinJS.Class.define(function (color, canEatDirectly, dimension) {
        this.color = color;
        this.canEatDirectly = canEatDirectly;
        this._dimension = dimension;
    },{
        descriptionString: {
            get: function () {
                return "color: " + this.color + ", can be eaten directly: " + this.canEatDirectly ? "yes" : "no"
            }
        },
    })
});