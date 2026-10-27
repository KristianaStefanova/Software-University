function solve(firstNumber, secondNumber, operator) {
    
    result = 0;

    switch (operator) {
        case "+":
            result = firstNumber + secondNumber;
            break;
        case "-":
            result = firstNumber - secondNumber;
            break;
        case "*":
            result = firstNumber * secondNumber;
            break;
        case "/":
            result = firstNumber / secondNumber;
            break;
        case "%":
            result = firstNumber % secondNumber;
            break;
        case "**":
            result = firstNumber ** secondNumber;
            break;
    }
    console.log(result);    
}

solve(5, 6, "+");
solve(3, 5.5, "*");
solve(10, 2, "/");
solve(7, 3, "%");
solve(2, 3, "**");