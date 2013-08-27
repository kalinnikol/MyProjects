/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="PrimesExtensions.js" />
isPrime = function (number) {
    for (var i = 2; i < number ; i++) {
        if (number % i == 0) {
            return false;
        }
    }
    return true;
}
calculateNPrimes = function (count) {
    var primesList = [];
    var currCount = 0;
    var number = 2;
    while (currCount < count) {
        if (isPrime(number)) {
            primesList.push(number);
            currCount++;
        }
        number++;
    }

    return primesList;
}

onmessage = function (event) {
    var count = event.data.count;

    var primes = calculateNPrimes(count);

    postMessage(primes);
}