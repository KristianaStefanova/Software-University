function reverseChars(char1, char2, char3) {

    let result = "";

    for (let i = 2; i >= 0; i--) {
        result += arguments[i] + " ";
    }

    console.log(result);
}

reverseChars('A', 'B', 'C');