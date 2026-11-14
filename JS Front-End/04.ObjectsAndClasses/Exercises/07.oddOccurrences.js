function oddOccurrences(str) {
    const wordsOccurrences = {};

    let arrWords = str.split(" ");
    for (let i = 0; i < arrWords.length; i++) {
        let currentWord = arrWords[i].toLowerCase();

        if (!Object.hasOwn(wordsOccurrences, currentWord)) {
            wordsOccurrences[currentWord] = 0;
        }

        wordsOccurrences[currentWord]++;
    }

    const result = Object.entries(wordsOccurrences)
        .filter(([word, occurrences]) => occurrences % 2 !== 0)
        .map(([word]) => word);

    console.log(result.join(" "));
}

oddOccurrences(`Cake IS SWEET is Soft CAKE sweet Food`)