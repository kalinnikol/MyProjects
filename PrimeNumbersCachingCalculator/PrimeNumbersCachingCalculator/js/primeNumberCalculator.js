/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="NPrimesWorker.js" />

WinJS.Namespace.define("Mathematics", {
    PrimeNumberCalculator: WinJS.Class.define(function (maxWorkers) {
        this.upperLimitPrimesWorker = new Worker("/js/upperLimitPrimesWorker.js");
        this.intervalPrimesWorker = new Worker("/js/intervalPrimesWorker.js");
        this.nPrimesWorker = new Worker("/js/nPrimesWorker.js");
        this._workers = 0;
        this._maxWorkers = maxWorkers;


    }, {
        maxWorkers: {
            get: function () {
                return this._maxWorkers;
            }
        },
        calculatePrimesToUpperLimit: function (upperLimit) {
            var self = this;
            var localFolder = Windows.Storage.ApplicationData.current.localFolder;
            return new WinJS.Promise(function (complete, error) {
                var fileName = "limit-" + upperLimit + ".txt";
                localFolder.createFileAsync(fileName, Windows.Storage.CreationCollisionOption.failIfExists).then(function (file) {
                    if (self._workers < self.maxWorkers) {
                        self._workers++;
                        self.upperLimitPrimesWorker.onmessage = function (event) {
                            self._workers--;
                            var primesList = event.data;
                            file.openTransactedWriteAsync().then(function (transaction) {
                                var writer = Windows.Storage.Streams.DataWriter(transaction.stream);
                                writer.writeString(primesList);
                                writer.storeAsync().done(function () {
                                    transaction.commitAsync().done(function () {
                                        transaction.close();
                                        complete(primesList);
                                    });
                                });
                            },
                            function (message) {
                                WinJS.Application.local.remove(fileName);
                            });
                            complete(primesList);
                        };
                        self.upperLimitPrimesWorker.postMessage({ upperLimit: upperLimit });
                    }
                    else {
                        error("A limitation of" + self.maxWorkers + "simultanious operations exists!");
                    }
                }, function () {
                    WinJS.Application.local.readText(fileName, "failed to open file").then(function (content) {
                        console.log(content);
                        var primesList = content.split(',');
                        complete(primesList);
                    });
                });
            });
        },
        calculatePrimesInRange: function (firstValue, lastValue) {
            var self = this;
            var localFolder = Windows.Storage.ApplicationData.current.localFolder;
            return new WinJS.Promise(function (complete, error) {
                var fileNameRange = "from-" + firstValue + "-to-" + lastValue + ".txt";
                localFolder.createFileAsync(fileNameRange, Windows.Storage.CreationCollisionOption.failIfExists).then(function (file) {
                    if (self._workers < self.maxWorkers) {
                        self._workers++;
                        self.intervalPrimesWorker.onmessage = function (event) {
                            self._workers--;
                            var primesList = event.data;
                            file.openTransactedWriteAsync().then(function (transaction) {
                                var writer = Windows.Storage.Streams.DataWriter(transaction.stream);
                                writer.writeString(primesList);
                                writer.storeAsync().done(function () {
                                    transaction.commitAsync().done(function () {
                                        transaction.close();
                                        complete(primesList);
                                    });
                                });
                            },
                            function (message) {
                                WinJS.Application.local.remove(fileName);
                            });
                            complete(primesList);
                        };
                        self.intervalPrimesWorker.postMessage({ firstNumber: firstValue, lastNumber: lastValue });
                    }
                    else {
                        error("A limitation of" + self.maxWorkers + "simultanious operations exists!");
                    }
                }, function () {
                    WinJS.Application.local.readText(fileNameRange, "failed to open file").then(function (content) {
                        var primesList = content.split(',');
                        complete(primesList);
                    });
                });
            });
        },
        calculatePrimesOfCountN: function (count) {
            var self = this;
            var localFolder = Windows.Storage.ApplicationData.current.localFolder;
            return new WinJS.Promise(function (complete, error) {
                var fileNameCount = "count-" + count + ".txt";
                localFolder.createFileAsync(fileNameCount, Windows.Storage.CreationCollisionOption.failIfExists).then(function (file) {
                    if (self._workers < self.maxWorkers) {
                        self._workers++;
                        self.nPrimesWorker.onmessage = function (event) {
                            self._workers--;
                            var primesList = event.data;
                            file.openTransactedWriteAsync().then(function (transaction) {
                                var writer = Windows.Storage.Streams.DataWriter(transaction.stream);
                                writer.writeString(primesList);
                                writer.storeAsync().done(function () {
                                    transaction.commitAsync().done(function () {
                                        transaction.close();
                                        complete(primesList);
                                    });
                                });
                            },
                            function (message) {
                                WinJS.Application.local.remove(fileName);
                            });
                            complete(primesList);
                        };
                        self.nPrimesWorker.postMessage({ count: count });
                    }
                    else {
                        error("A limitation of" + self.maxWorkers + "simultanious operations exists!");
                    }
                }, function () {
                    WinJS.Application.local.readText(fileNameCount, "failed to open file").then(function (content) {
                        var primesList = content.split(',');
                        complete(primesList);
                    });
                });
            });
        }
    })
});