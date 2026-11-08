function findPalindrome(arrayOfNumbers) {

    for (let i = 0; i < arrayOfNumbers.length; i++) {
        console.log(isPalidrome(arrayOfNumbers[i]));
    }

    function isPalidrome(number) {
        let reversedNumber = reverseNumber(number);
        
        return number === reverseNumber(number) ? true : false;
    }

    function reverseNumber(number) {
        let numAsString = String(number).split("").reverse().join(``);
        return Number(numAsString);
    }
}

findPalindrome([123, 323, 421, 121])