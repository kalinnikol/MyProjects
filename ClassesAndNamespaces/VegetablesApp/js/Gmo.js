/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="Vegetable.js" />
/// <reference path="Cucumber.js" />
/// <reference path="Tomato.js" />
/// <reference path="Mushroom-mixin.js" />


WinJS.Namespace.defineWithParent(Vegetables, "GMO", {
    TomatoGmo: WinJS.Class.mix(Vegetables.DirectlyEatable.Tomato, MyMixins.Mashroom),
    CucumberGmo:WinJS.Class.mix(Vegetables.IndirectlyEatable.Cucumber,MyMixins.Mashroom)
});