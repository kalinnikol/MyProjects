/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />
/// <reference path="PrimeNumberCalculator.js" />
/// <reference path="PrimesExtensions.js" />
/// <reference group="Dedicated Worker" />. 

//this.importScripts("js/primesExtensions.js"); Does not work!!!

isPrime = function (number) {
    for (var i = 2; i < number ; i++) {
        if (number % i == 0) {
            return false;
        }
    }
    return true;
};
calculatePrimes = function (fromNumber, toNumber) {
    var primesList = [];
    for (var num = fromNumber; num <= toNumber; num++) {
        if (isPrime(num)) {
            primesList.push(num);
        }
    }

    return primesList;
},

onmessage = function (event) {
    var firstNumber = event.data.firstNumber;
    var lastNumber = event.data.lastNumber;

    var primes = calculatePrimes(parseInt(firstNumber),parseFloat( lastNumber ));

    postMessage(primes);
}

