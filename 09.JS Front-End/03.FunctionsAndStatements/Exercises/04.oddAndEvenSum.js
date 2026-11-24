function oddAndEvenSum(n) {

    let numAsArray = n.toString().split("");
    let sumEvenNums = findAndSumEvenNums(numAsArray);
    let sumOddNums = findAndSumOddNums(numAsArray);
    
    let result = [];
    let oddResult = `Odd sum = ${sumOddNums}`;
    let evenResult = `Even sum = ${sumEvenNums}`
    result.push(oddResult);
    result.push(evenResult);

    print(result);

    function print(output) {
        console.log(result.join(`, `));
    }

    function findAndSumEvenNums(numAsArray) {
        let result = 0;
        for(let i = 0; i < numAsArray.length; i++) {
            let currentNumber = Number(numAsArray[i]);
            if(currentNumber % 2 === 0) {
                result += currentNumber
            }
        }

        return result
    }

    function findAndSumOddNums(numAsArray) {
        let result = 0;
        for(let i = 0; i < numAsArray.length; i++) {
            let currentNumber = Number(numAsArray[i]);
            if(currentNumber % 2 !== 0) {
                result += currentNumber
            }
        }

        return result
    }
}

oddAndEvenSum(122);