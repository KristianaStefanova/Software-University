function sameNumbers(number) {
    let numberAsString = number.toString();
    let sum = 0;
    let isSame = true;
    let firstDigit = numberAsString[0];

    for (let i = 0; i < numberAsString.length; i++) {
        
        let currentDigit = numberAsString[i];
        sum += Number(currentDigit);

        if (currentDigit !== firstDigit) {
            isSame = false;
        } 
    }

    console.log(isSame);
    console.log(sum);
}

sameNumbers(1234);