function loadingBar(n) {
    let loadingBar = [];
    let countOfSymbols = calculateSymbolsLoadingBar(n);

    printResult(n);


    function printResult(n) {

        loadingBar = prepareLoadingBar(loadingBar, countOfSymbols);
        let result = "";
        if (n === 100) {
            result = `100% Complete!\n${loadingBar}`
        } else {
            result = `${n}% ${loadingBar}\nStill loading...`
        }

        console.log(result)
    }

    function prepareLoadingBar(arr, countOfSymbols) {
        
        for (let i = 0; i < countOfSymbols; i++) {
            arr.unshift("%")
        }
        for (let i = countOfSymbols; i < 10; i++) {
            arr.push(".")
        }

        return (`[${loadingBar.join("")}]`);
    }

    function calculateSymbolsLoadingBar(n) {
        return n / 10;
    }
}

loadingBar(30);