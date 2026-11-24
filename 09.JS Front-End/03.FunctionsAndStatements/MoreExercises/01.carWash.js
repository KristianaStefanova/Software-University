function carWash(arr) {

    let percentage = calculatePercentage(arr);
    printResult(percentage);

    function calculatePercentage(arr) {
        let percentage = 0;
        for (let command of arr) {
            switch (command) {
                case "soap": percentage += 10;
                    break
                case "water": percentage += percentage * 0.2;
                    break;
                case "vacuum cleaner": percentage += percentage * 0.25;
                    break;
                case "mud": percentage -= percentage * 0.1;
                    break;
            }
        }

        return percentage;
    }

    function printResult(percentage) {
        console.log(`The car is ${percentage.toFixed(2)}% clean.`)
    }
}

carWash(['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water'])