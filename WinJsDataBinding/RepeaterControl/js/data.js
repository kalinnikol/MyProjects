(function () {

    var firstComputerObservable = Data.getComputer("Dell Studio 1535", 2000, "/images/studio-1535.png", "Core i5", 2.0);
    var secondComputerObservable = Data.getComputer("HP 650", 1500, "/images/hp-650.jpg", "Intel 1000M", 1.8);

    var computers = [];

    WinJS.Binding.List(computers, { binding: true });

    computers.push(firstComputerObservable);
    computers.push(secondComputerObservable);

    var addComputer=function(computer){
        computers.push(computer);
        computerTemplate = new WinJS.Binding.Template(null, {href:"ms-appx:///templates/computer-template.html"});
        computerTemplate.render(computer, document.getElementById("container")).done();
    }

    WinJS.Utilities.markSupportedForProcessing(addComputer);

    WinJS.Namespace.define("Data", {
        computers: computers,
        addComputer:addComputer
    });
})();