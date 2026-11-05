function convertToUppercase(input) {
    let words = input.split(/[\s\p{P}\p{S}]+/u);

    words = words.filter(Boolean);

    let result = "";

    for (let i = 0; i < words.length; i++) {
        if (i === words.length - 1) {
            result += words[i].toUpperCase();
        } else {
            result += words[i].toUpperCase() + ", ";
        }
    }

    return result;
}

console.log(convertToUppercase("hello"));
console.log(convertToUppercase("Hi, how are you?"));
