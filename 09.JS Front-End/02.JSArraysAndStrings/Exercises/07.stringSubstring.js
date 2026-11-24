function stringSubstring(word, text) {
    word = word.toLowerCase();
    text = text.toLowerCase();

    let textArr = text.split(' ');

    if (textArr.includes(word)) {
        console.log(word);
    } else {
        console.log(`${word} not found!`);
    }
}

stringSubstring('python', 'JavaScript is the best programming language');
