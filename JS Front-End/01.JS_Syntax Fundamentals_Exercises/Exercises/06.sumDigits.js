function sumDigits(num) {
    let numString = num.toString();
    let sum = 0;
    for (let i = 0; i < numString.length; i++) {
        let currentNum = numString[i];
        sum += parseInt(currentNum);
    }
    
    console.log(sum);
}

sumDigits(245678);   