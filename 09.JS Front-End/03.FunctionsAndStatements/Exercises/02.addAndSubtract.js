function addAndSubstract(a, b, c) {
    
    console.log(subtract(sum(a, b), c));

    function subtract(sumResult, c) {
        return sumResult - c;
    }

    function sum(a, b) {
        return a + b
    }
}

addAndSubstract(23, 6, 10);