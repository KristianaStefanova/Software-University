function countStringOccurrences(str, searchWord) {
    let count = 0;
    let words = str.split(' ');

    for (let word of words) {
        if (word === searchWord) {
            count++;
        }
    }

    console.log(count);
}

countStringOccurrences('This is a word and it also is a sentence', 'is');