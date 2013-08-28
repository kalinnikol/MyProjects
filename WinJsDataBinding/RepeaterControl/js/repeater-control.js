(function () {
    var RepeaterControl = WinJS.Class.define(function (templatePath, data, element) {
        this.computerTemplate = new WinJS.Binding.Template(null, {
            href: templatePath
        });

        this.data = data;

        this.element = element ? element : document.createElement("div");
    }, {
        render: function () {
            if (this.data) {
                for (var i = 0; i < this.data.length; i++) {
                    this.computerTemplate.render(this.data[i], this.element).done();
                }
            }
        }
    });

    WinJS.Namespace.define("Controls", {
        createRepeaterControl: function (templatePath, data, element) {
            return new RepeaterControl(templatePath, data, element);
        }
    });
}());