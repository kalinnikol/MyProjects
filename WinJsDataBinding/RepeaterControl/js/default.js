/// <reference path="data-model.js" />
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll().then(function () {

                var createComputerBtn = document.getElementById("create-computer");
                createComputerBtn.addEventListener("click", function () {
                    var compName = document.getElementById("name").value;
                    var compPrice = document.getElementById("price").value;
                    var procModel = document.getElementById("model").value;
                    var procFreq = document.getElementById("freq").value;
                    var image = document.getElementById("image").value;

                    var newComp = Data.getComputer(compName, compPrice, image, procModel, procFreq);
                    Data.addComputer(newComp);
                })

                var container = document.getElementById("container");
                var repeaterControl = Controls.createRepeaterControl("ms-appx:///templates/computer-template.html", Data.computers, container);
                repeaterControl.render();
            }));
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();
