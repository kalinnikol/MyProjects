// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
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
                var statusInputElementValue = WinJS.Application.sessionState["statusInputElementValue"];
                if (statusInputElementValue) {
                    var statusInputElement = document.getElementById("poem-line");
                    statusInputElement.value = statusInputElementValue;
                }

                var currentVerseValue = WinJS.Application.sessionState["currentVerse"];
                if (currentVerseValue) {
                    var verseDiv = document.getElementById("verse-div");
                    verseDiv.innerHTML = currentVerseValue;
                }
            }
            args.setPromise(WinJS.UI.processAll());
            var appBar = document.getElementById("createAppBar").winControl;
            appBar.show();

            var setVerseButton = document.getElementById("set-verse-btn");
            setVerseButton.addEventListener("click", onSetVerseBtnClicked);

            var addLineBtn = document.getElementById("add-line");
            addLineBtn.addEventListener("click", onAddLineBtnClicked);

            var saveToFileBtn = document.getElementById("save-to-file");
            saveToFileBtn.addEventListener("click", saveToFile);

            var openFileBtn = document.getElementById("open-from-file");
            openFileBtn.addEventListener("click", openFromFile);
            
            var startNewPoemBtn = document.getElementById("start-new");
            startNewPoemBtn.addEventListener("click", startNew);

            initialize();
        }
    };

    app.oncheckpoint = function (args) {
        var statusInputElement = document.getElementById("poem-line").value;
        if (statusInputElement) {
            WinJS.Application.sessionState["statusInputElementValue"] = statusInputElement.toString();
        }
        var verseInput = document.getElementById("verse-div").innerHTML;
        if (verseInput) {
            WinJS.Application.sessionState["currentVerse"] = verseInput.toString();
        }
    };

    app.start();

    var initialize = function () {
        var poemContainer = document.getElementById("poem-container");
        var localFolder = Windows.Storage.ApplicationData.current.localFolder;
        localFolder.createFileAsync("poem.txt", Windows.Storage.CreationCollisionOption.openIfExists).then(function (file) {
            Windows.Storage.FileIO.readTextAsync(file).then(function (content) {
                poemContainer.innerHTML = content;
            });
        });
    }

    var saveToFile = function () {
        var poemContainer = document.getElementById("poem-container");
        var poem = poemContainer.innerHTML;

        var filePicker = Windows.Storage.Pickers.FileOpenPicker();
        filePicker.fileTypeFilter.append("*");
        filePicker.commitButtonText = "Pick file to take poem ";
        filePicker.pickSingleFileAsync().done(function (file) {
            if (file) {

                var messageDialog = new Windows.UI.Popups.MessageDialog(
           "Poem was successfully written to file");

                var writeSuccessMessage = function () {
                    messageDialog.showAsync();
                }

                var writeErrorMessage = function (error) {
                    messageDialog.content = "Poem could not be written to file";
                    messageDialog.showAsync();
                }

                Windows.Storage.FileIO.writeTextAsync(file, poem).done(writeSuccessMessage, writeErrorMessage);
            }
        });

       
    }

    var openFromFile = function () {
        var filePicker = Windows.Storage.Pickers.FileOpenPicker();
        filePicker.fileTypeFilter.append("*");
        filePicker.commitButtonText = "Pick file to take poem ";
        filePicker.pickSingleFileAsync().done(function (file) {
            if (file) {
                Windows.Storage.FileIO.readTextAsync(file).then(function (content) {
                    var poemContainer = document.getElementById("poem-container");
                    poemContainer.innerHTML = content;
                })
            }
        });
    }

    var startNew = function () {
        var messageDialog = new Windows.UI.Popups.MessageDialog(
          "The current changes to your poem will be discarded!");
        var yesCommand = new Windows.UI.Popups.UICommand("Ok", function () {
            var poemContainer = document.getElementById("poem-container");
            poemContainer.innerHTML="";
        });
        var cancelCommand = new Windows.UI.Popups.UICommand("Cancel", function () {
        });
        messageDialog.commands.append(yesCommand);
        messageDialog.commands.append(cancelCommand);
        messageDialog.showAsync();
    }

    var onSetVerseBtnClicked = function () {
        var selectValue = document.getElementById("verse-select").value;
        var verseOlContainer = document.getElementById("verse-container");
        verseOlContainer.setAttribute("data-verse-count", selectValue);
    }

    var onAddLineBtnClicked = function () {
        var poemLine = document.getElementById("poem-line").value;
        var verseOlContainer = document.getElementById("verse-container");
        var verseCount = verseOlContainer.getAttribute("data-verse-count") * 1;
        if (verseOlContainer.childNodes.length < verseCount) {
            var newLi = "<li>" + poemLine+"</li>";
            verseOlContainer.innerHTML+=newLi;
        }
        else {
            var verse = [];
            for (var i = 0; i < verseOlContainer.childNodes.length; i++) {
                var currentLine = verseOlContainer.childNodes[i].innerText;
                verse.push(currentLine);
            }
            var isRhymeCorrect = checkIfRhymeCorrect(verse);

            if (isRhymeCorrect) {
                addVerseToPoem(verse);
            }
            else {
                var messageDialog = new Windows.UI.Popups.MessageDialog(
                    "The current verse does not rhyme. Would you like to append it to the poem anyway?");
                var yesCommand = new Windows.UI.Popups.UICommand("Yes", function () {
                    addVerseToPoem(verse);
                });
                var noCommand = new Windows.UI.Popups.UICommand("No", function () {
                    verseOlContainer.innerHTML = "";
                })
                messageDialog.commands.append(yesCommand);
                messageDialog.commands.append(noCommand);
                messageDialog.showAsync();
            }

            verseOlContainer.innerHTML = "<li>" + poemLine + "</li>";
        }
    }

    var checkIfRhymeCorrect = function (verse) {
        var twoNeghbouringLinesRhymed = checkIfNeghbouringLinesRhyme(verse);
        if (twoNeghbouringLinesRhymed) {
            return true;
        }
        else {
            if (verse.length<=2) {
                return false;
            }
            var notNeighbouringLinesRhymed = checkIfNotNeghbouringLinesRhyme(verse);
            if (notNeighbouringLinesRhymed) {
                return true;
            }
        }

        return false;
    }

    var checkIfNeghbouringLinesRhyme = function (verse) {
        if (isEven(verse.length)) {
            for (var i = 0; i < verse.length; i++) {
                var first = verse[i].substr(verse[i].length - 3);
                var second = verse[i+1].substr(verse[i+1].length - 3);
                if (first!=second) {
                    return false
                }

                i++;
            }
        }
        else {
            for (var i = 0; i < verse.length-1; i++) {
                var first = verse[i].substr(verse[i].length - 3);
                var second = verse[i + 1].substr(verse[i + 1].length - 3);
                if (first != second) {
                    return false
                }

                i++;
            }
        }

        return true;
    }

    var checkIfNotNeghbouringLinesRhyme = function (verse) {
        if (isEven(verse.length)) {
            for (var i = 0; i < verse.length-2; i++) {
                var first = verse[i].substr(verse[i].length - 3);
                var second = verse[i + 2].substr(verse[i + 2].length - 3);
                if (first != second) {
                    return false
                }
            }
        }
        else {
            for (var i = 0; i < verse.length - 3; i++) {
                var first = verse[i].substr(verse[i].length - 3);
                var second = verse[i + 2].substr(verse[i + 2].length - 3);
                if (first != second) {
                    return false
                }
            }
        }

        return true;
    }

    var addVerseToPoem = function (verse) {
        var poemContainer = document.getElementById("poem-container")
        for (var i = 0; i < verse.length; i++) {
            var paragraph = "<p>" + verse[i] + "</p>";
            poemContainer.innerHTML += paragraph;
        }
        var twoSeparateLines = "<br/><br/>";
        poemContainer.innerHTML += twoSeparateLines;
        
        var localFolder = Windows.Storage.ApplicationData.current.localFolder;
        localFolder.getFileAsync("poem.txt").then(function (file) {
            file.openTransactedWriteAsync().then(function (transaction) {
                var writer = Windows.Storage.Streams.DataWriter(transaction.stream);
                writer.writeString(poemContainer.innerHTML);
                writer.storeAsync().done(function () {
                    transaction.commitAsync().done(function () {
                        transaction.close();
                    });
                });
            },
            function (message) {
                WinJS.Application.local.remove("poem.txt");
            });
        });
    }

    function isEven(n) {
        return isNumber(n) && (n % 2 == 0);
    }

    function isOdd(n) {
        return isNumber(n) && (n % 2 == 1);
    }

    function isNumber(n) {
        return n == parseFloat(n);
    }

})();
