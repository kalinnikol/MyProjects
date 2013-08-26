// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";


    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;
    WinJS.strictProcessing();

    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {

            args.setPromise(WinJS.UI.processAll());

            var appBar = document.getElementById("appbar-id").winControl;
            appBar.show();

            var loadedVideosList = document.getElementById("loaded-videos");
            var player = document.getElementById("player");
            var appBar = document.getElementById("appbar-id").winControl;
        }

        loadedVideosList.addEventListener("click", function (event) {
            var videoEntry = event.target;
            console.log(videoEntry.innerText);

            if (videoEntry.tagName.toLowerCase() == "strong") {
                videoEntry = videoEntry.parentElement;
            }
            player.src = videoEntry.getAttribute("data-video-url");

            player.play();
            appBar.show();

        });
        
        var removeFileButton = document.getElementById("remove-file-button");
        removeFileButton.addEventListener("click", function () {
            var source = player.src;
            for (var i = 0; i < loadedVideosList.childNodes.length; i++) {
                var dataVideoAttr = loadedVideosList.childNodes[i].getAttribute("data-video-url");
                if (dataVideoAttr == source) {
                    loadedVideosList.removeChild(loadedVideosList.childNodes[i]);
                    break;
                }
            }
        });


        var savePlaylistBtn = document.getElementById("save-list-to-file");
        savePlaylistBtn.addEventListener("click", function () {
            var ul = document.getElementById("loaded-videos").innerHTML;
            console.log(ul);
            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.defaultFileExtension = ".txt"
            savePicker.fileTypeChoices.insert("Plain Text", [".txt"])
            savePicker.suggestedFileName = "New Text Document";

            savePicker.pickSaveFileAsync().then(function (file) {
                if (file) {
                    Windows.Storage.FileIO.writeTextAsync(file, ul);
                }
                appBar.show();
            });
        });

        var loadListBtn = document.getElementById("load-list-from-file");
        loadListBtn.addEventListener("click", function () {
            var openPicker = Windows.Storage.Pickers.FileOpenPicker();

            openPicker.fileTypeFilter.append("*");
            openPicker.pickSingleFileAsync().then(function (file) {
                if (file) {
                    Windows.Storage.FileIO.readTextAsync(file).done(function (text) {
                        var ul = document.getElementById("loaded-videos")
                        ul.innerHTML = text;
                        var liElements = ul.childNodes;
                        for (var i = 0; i < liElements.length; i++) {
                            var liText = liElements[i].innerText;
                            var locationIndex=liText.indexOf("Location: ");
                            var path = liText.substring(locationIndex + "Location: ".length);
                           Windows.Storage.StorageFile.getFileFromPathAsync(path).then(function (file) {
                               addSong(file);
                            });
                           
                            console.log();
                        }
                    })
                }

                var appBar = document.getElementById("appbar-id").winControl;
                appBar.show();
            });
        });

        var addVideoListEntry = function (videoName, videoDuration, videoUrl,filePath) {
            var videoEntry = document.createElement("li");
            videoEntry.setAttribute("data-video-url", videoUrl);
            videoEntry.innerHTML = "<strong>" + videoName + "</strong>" + " - " + videoDuration + " Location: " + filePath;
            loadedVideosList.appendChild(videoEntry);
        }

        var addSong = function (storageFile) {
            var fileUrl = URL.createObjectURL(storageFile);
            storageFile.properties.getVideoPropertiesAsync().then(function (properties) {
               
                addVideoListEntry(properties.title, properties.duration, fileUrl, storageFile.path);
            });
        }

        WinJS.Utilities.id("pick-file-button").listen("click", function () {
            var openPicker = Windows.Storage.Pickers.FileOpenPicker();

            openPicker.fileTypeFilter.append("*");
            openPicker.pickSingleFileAsync().then(function (file) {
                if (file) {
                    addSong(file);
                }

                var appBar = document.getElementById("appbar-id").winControl;
                appBar.show();
            });
        });

        WinJS.Utilities.id("pick-multiple-files-button").listen("click", function () {
            var openPicker = Windows.Storage.Pickers.FileOpenPicker();

            openPicker.fileTypeFilter.append("*");
            openPicker.pickMultipleFilesAsync().then(function (files) {
                if (files) {
                    files.forEach(addSong);
                }

                var appBar = document.getElementById("appbar-id").winControl;
                appBar.show();
            });
        });
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
