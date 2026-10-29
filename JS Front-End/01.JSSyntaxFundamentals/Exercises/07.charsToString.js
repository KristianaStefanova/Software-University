function charsToString(a, b, c) {
    let text = a + b + c;

    let buff = "";
    for(let i = text.length - 1; i >= 0; i--) {
        buff += text[i] + " ";
    }

    console.log(buff);
}

charsToString('A', 'B', 'C');