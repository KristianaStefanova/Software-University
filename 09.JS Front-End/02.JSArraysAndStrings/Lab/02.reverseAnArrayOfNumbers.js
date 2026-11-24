function reverseAnArrayOfNumbers(n, arr) {

    let finalArray = arr.slice(0, n).reverse();
    
    console.log(finalArray.join(' '));
}

reverseAnArrayOfNumbers(3, [10, 20, 30, 40, 50]);