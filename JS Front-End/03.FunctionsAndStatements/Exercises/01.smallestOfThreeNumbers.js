function findSmallestNumber(a, b, c) {
    
    console.log(findSmallestOfTwoNumbers(findSmallestOfTwoNumbers(a, b), c));

    function findSmallestOfTwoNumbers(a, b) {
       return a < b ? a : b
    }
}

findSmallestNumber(-1, 342, 123);