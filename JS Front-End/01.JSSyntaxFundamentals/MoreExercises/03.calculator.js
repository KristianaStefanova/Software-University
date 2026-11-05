function calculate(number, operator, anotherNumber) {
    let result = 0;
    switch (operator) {
        case '+':
            result = number + anotherNumber;
            break;
        case '-':
            result = number - anotherNumber;
            break;      
        case '*':
            result = number * anotherNumber;
            break;
        case '/':
            if (anotherNumber === 0) {
                throw new Error("Cannot divide by zero");
            }
            result = number / anotherNumber;
            break;
        default:
            throw new Error("Invalid operation");
    }

    console.log(result.toFixed(2));
}

calculate(10, '+', 5); // returns 15
calculate(10, '-', 5); // returns 5
calculate(10, '*', 5); // returns 50
calculate(10, '/', 5); // returns 2