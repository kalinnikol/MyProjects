/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="PrimeNumberCalculator.js" />
/// <reference path="PrimesExtensions.js" />
isPrime= function (number) {
    for (var i = 2; i < number ; i++) {
        if (number % i == 0) {
            return false;
        }
    }
    return true;
};
calculatePrimes= function (fromNumber, toNumber) {
    var primesList = [];

    for (var num = fromNumber; num <= toNumber; num++) {
        if (isPrime(num)) {
            primesList.push(num);
        }
    }

    return primesList;
},
onmessage= function (event) {
    var upperLimit = event.data.upperLimit;
    var primes =calculatePrimes(2,parseInt( upperLimit));

    postMessage(primes);
}

