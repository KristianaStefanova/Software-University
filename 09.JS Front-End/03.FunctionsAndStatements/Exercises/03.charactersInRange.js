function findCharactersInRange (char1, char2) {

    let startChar = findSmallerChar(char1, char2).charCodeAt();
    let endChar = findBiggerChar(char1, char2).charCodeAt();

    let result = [];
    for(let i = startChar + 1; i < endChar; i++) {
        let currentChar = String.fromCharCode(i);
        result.push(currentChar);
    }

    console.log(result.join(" "));


    function findSmallerChar(char1, char2) {
         return char1.charCodeAt() < char2.charCodeAt() ? char1 : char2
    }

    function findBiggerChar(char1, char2) {
         return char1.charCodeAt() > char2.charCodeAt() ? char1 : char2
    }
}

findCharactersInRange('#', ':')