function censoredWords(str, censoredWord) {
    
    let starTemplate = '*'.repeat(censoredWord.length);
    str = str.replaceAll(censoredWord, starTemplate);
    
    console.log(str);
}

censoredWords('A small sentence with some words', 'small');