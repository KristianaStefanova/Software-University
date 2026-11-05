function signCheck(numOne, numTwo, numThree) {
    let count = 0;

    if (numOne < 0) {
        count++;
    }
    if (numTwo < 0) {
        count++;
    }
    if (numThree < 0) {
        count++;
    }

    console.log(count % 2 === 0 ? 'Positive' : 'Negative');
}

signCheck(5, 12, -15);