// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    var calculator = {};

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll());

            var messanderDiv = document.getElementById("messanger");
            messanderDiv.style.width = "200px;"
            messanderDiv.style.height = "60px;"

            var workerCount = 0;
            var localSettings = Windows.Storage.ApplicationData.current.localSettings;
            if (localSettings.values['workerCount']) {
                workerCount = localSettings.values['workerCount'];
                calculator = new Mathematics.PrimeNumberCalculator(workerCount);
            }
            else {

                messanderDiv.innerText = "You must enter value for your workers count!"
            }

            var btnSubmit = document.getElementById("submit-workers-count-btn");
            btnSubmit.addEventListener("click", function () {
                workerCount = document.getElementById("workers-count").value * 1;
                localSettings.values['workerCount'] = workerCount;
                calculator = new Mathematics.PrimeNumberCalculator(workerCount);
                messanderDiv.innerText = "";
            });

            var calcUptoNButton = document.getElementById("btn-calc-upto-n");
            calcUptoNButton.addEventListener("click", function () {
                var inputUptoN = document.getElementById("input-upto-n");
                var limit = inputUptoN.value;
                calculator.calculatePrimesToUpperLimit(limit * 1).then(function (primes) {
                    var primesPar = document.getElementById("result-one");
                    primesPar.innerText = primes.join(", ")
                }, function (error) {
                    var primesPar = document.getElementById("result-one");
                    primesPar.innerText = error;
                });
            });

            var calcFirstNButton = document.getElementById("btn-calc-first-n");
            calcFirstNButton.addEventListener("click", function () {
                var inputN = document.getElementById("input-n");
                var count = inputN.value;
                calculator.calculatePrimesOfCountN(count * 1).then(function (primes) {
                    var primesPar = document.getElementById("result-two");
                    primesPar.innerText = primes.join(", ")
                }, function (error) {
                    var primesPar = document.getElementById("result-two");
                    primesPar.innerText = error;
                });
            });

            var calcIntervalButton = document.getElementById("btn-calc-range");
            calcIntervalButton.addEventListener("click", function () {
                var inputStart = document.getElementById("input-a").value;
                var inputEnd = document.getElementById("input-b").value;
                calculator.calculatePrimesInRange(inputStart * 1, inputEnd * 1).then(function (primes) {
                    var primesPar = document.getElementById("result-three");
                    primesPar.innerText = primes.join(", ")
                }, function (error) {
                    var primesPar = document.getElementById("result-three");
                    primesPar.innerText = error;
                });
            })
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
