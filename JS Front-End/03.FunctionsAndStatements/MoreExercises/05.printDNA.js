function printDNA(length) {

    const sequence = 'ATCGTTAGGG';

    for (let i = 0; i < length; i++) {

        const index = (i * 2) % sequence.length;
        const pattern = i % 4;

        if (pattern === 0) {
            printFirstLine(sequence, index);
        } else if (pattern === 1) {
            printSecondLine(sequence, index);
        } else if (pattern === 2) {
            printThirdLine(sequence, index);
        } else {
            printFourthLine(sequence, index);
        }
    }

    function printFirstLine(sequence, index) {
        console.log(`**${sequence[index]}${sequence[index + 1]}**`);
    }

    function printSecondLine(sequence, index) {
        console.log(`*${sequence[index + 2]}--${sequence[index + 3]}*`);
    }

    function printThirdLine(sequence, index) {
        console.log(`${sequence[index + 4]}----${sequence[index + 5]}`);
    }

    function printFourthLine(sequence, index) {
        console.log(`*${sequence[index + 6]}--${sequence[index + 7]}*`);
    }

}

printDNA(10);