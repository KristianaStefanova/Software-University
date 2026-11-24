function factorialDivision(a, b) {

    let firstFactorial = findFactorial(a);
    let secondFactorial = findFactorial(b);
    let result = divideFactorial(firstFactorial, secondFactorial);

    printResult(result);

    function printResult(result) {
        if (b === 0) {
            console.log("Cannot divide by zero");
            return;
        }

        console.log(`${result.toFixed(2)}`)
    }

    function divideFactorial(factorial, divisor) {
        return factorial / divisor;
    }

    function findFactorial(number) {
        let factorial = 1;
        for (let i = 1; i <= number; i++) {
            factorial *= i;
        }

        return factorial;
    }
}

factorialDivision(6, 2);