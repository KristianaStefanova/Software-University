function pascalCaseSplitter(input) {
    let pattern = /[A-Z][a-z]*/g;
    let matches = input.match(pattern) || [];

    console.log(matches.join(', '));
}

console.log(pascalCaseSplitter('SplitMeIfYouCanHaHaYouCantOrYouCan'));