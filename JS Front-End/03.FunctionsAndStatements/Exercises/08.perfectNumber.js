function perfectNumber(n) {
    let isNumValid = validateNum(n);
    let isPerfectNumber = checkNum(n);

    printOutput(isPerfectNumber);

    function printOutput(isPerfectNumber) {
        console.log(isPerfectNumber ? `We have a perfect number!` : `It's not so perfect.`)
    }

    function checkNum(n) {
        let sum = 0;
        for (let i = 1; i < n; i++) {
            if (n % i === 0) {
                sum += i;
            }
        }

        return sum === n ? true : false
    }

    function validateNum(n) {
        return n > 0 ? true : false
    }
}

perfectNumber(6);