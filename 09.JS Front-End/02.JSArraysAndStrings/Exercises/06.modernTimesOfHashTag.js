function modernTimesOfHashTag(input) {
    let pattern = /#([A-Za-z]+)/g;
    let matches = input.match(pattern);
    
    matches.forEach(match => {
        let word = match.substring(1);
        console.log(word);
    })
}

modernTimesOfHashTag('Nowadays everyone uses # to tag a #special word in #socialMedia');