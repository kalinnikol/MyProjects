(function () {
    "use strict";

    var dataArray = [
    { title: "History", text: "Click to read more", picture: "images/architecture.jpg" },
    { title: "Culture", text: "Click to read more", picture: "images/architecture.jpg" },
    { title: "Architecture", text: "Click to read more", picture: "images/architecture.jpg" }
    ];

    var dataList = new WinJS.Binding.List(dataArray);
    var onPageClicked = function () {
        console.log(event);
    }

    // Create a namespace to make the data publicly
    // accessible. 
    var publicMembers =
        {
            itemList: dataList,
            onPageClicked:onPageClicked
        };
    WinJS.Namespace.define("Data", publicMembers);

})();
