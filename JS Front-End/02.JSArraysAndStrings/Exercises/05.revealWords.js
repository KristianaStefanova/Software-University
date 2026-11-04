function revealWords(wordsAsString, sentence) {
    let wordsArr = wordsAsString.split(', ');

    for (let word of wordsArr) {

        let index = sentence.indexOf('*');

        sentence = sentence.replace('*'.repeat(word.length), word);   
    }

    console.log(sentence);
}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');