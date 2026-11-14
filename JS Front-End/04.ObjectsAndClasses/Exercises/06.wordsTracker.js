function wordsTracker(arr) {
    const wordsDictionary = {};
    const searchedWords = arr[0].split(" ");

    initializeSearchedWords(searchedWords, wordsDictionary);
    countOccurrences(arr, wordsDictionary);

    const sortedTracker = sortTracker(wordsDictionary);
    printTracker(sortedTracker);

    function initializeSearchedWords(words, dictionary) {
        for (const word of words) {
            dictionary[word] = 0;
        }
    }

    function countOccurrences(arr, dictionary) {
        for (let i = 1; i < arr.length; i++) {
            const currentWord = arr[i];

            if (Object.hasOwn(dictionary, currentWord)) {
                dictionary[currentWord]++;
            }
        }
    }

    function sortTracker(dictionary) {
        return Object.entries(dictionary)
            .sort((a, b) => b[1] - a[1]);
    }

    function printTracker(sortedTracker) {
        for (const [word, occurrences] of sortedTracker) {
            console.log(`${word} - ${occurrences}`);
        }
    }
}

wordsTracker([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have',
    'to', 'count', 'the', 'occurrences', 'of',
    'the', 'words', 'this', 'and', 'sentence',
    'because', 'this', 'is', 'your', 'task'
]);