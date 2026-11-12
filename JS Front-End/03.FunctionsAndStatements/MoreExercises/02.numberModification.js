function numberModification(n) {

    let nAsArr = convertToString(n);
    let initialLength = nAsArr.length;
    let initialSum = calculateInitialSum(initialLength);
    let averageSum = initialSum / initialLength;

    while (averageSum <= 5) {
        initialLength++;
        initialSum += 9;
        nAsArr.push("9");

        averageSum = initialSum / initialLength;
    }
    
    printNumber(nAsArr);

    function calculateInitialSum(length) {
        let sum = 0;
        for (let i = 0; i < length; i++) {
            sum += Number(nAsArr[i]);
        }

        return sum;
    }

    function printNumber(nAsArr) {
        console.log(nAsArr.join(""));
    }

    function convertToString(n) {
        return n.toString().split("");

    }
}

numberModification(101);