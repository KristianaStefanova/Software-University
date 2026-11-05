function calculateSpiceFlow(startingYield) {
    
    let days = 0;
    let totalSpiceExtracted = 0;
    while (startingYield >= 100) {
        let spiceExtracted = startingYield - 26;
        totalSpiceExtracted += spiceExtracted;
        startingYield -= 10;
        days++;
    }
    
    if (totalSpiceExtracted >= 26) {
        totalSpiceExtracted -= 26;
    } else {
        totalSpiceExtracted = 0;
    }
    
    console.log(days);
    console.log(totalSpiceExtracted);
}

calculateSpiceFlow(111);