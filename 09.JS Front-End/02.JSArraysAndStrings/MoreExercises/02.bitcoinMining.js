function calculateBitcoin(amountOfGoldPerDay) {

    let totalCountOFDays = amountOfGoldPerDay.length;
    let priceOfBitcoin = 11949.16;
    let day = 0;
    let totalAmount = 0;
    let priceOfGoldPerGram = 67.51;
    let isFirstBitcoinBought = true;
    let amountOfBitcoinsBought = 0;
    let dayOfFirstBitcoin = 0;
    let currentAmount = 0;


    for (let i = 1; i <= totalCountOFDays; i++) {

        if (i % 3 === 0 && i !== 0) {
            currentAmount = amountOfGoldPerDay[i - 1] * 0.7 * priceOfGoldPerGram;
        } else {
            currentAmount = amountOfGoldPerDay[i - 1] * priceOfGoldPerGram;
        }

        totalAmount += currentAmount;
        day++;

        if (totalAmount >= priceOfBitcoin) {
            if (isFirstBitcoinBought) {
                dayOfFirstBitcoin = day;
                isFirstBitcoinBought = false;
            }

            amountOfBitcoinsBought++;
            totalAmount -= priceOfBitcoin;
        }
    }

    while (totalAmount >= priceOfBitcoin) {
        if (isFirstBitcoinBought) {
            dayOfFirstBitcoin = day;
            isFirstBitcoinBought = false;
        }
        amountOfBitcoinsBought++;
        totalAmount -= priceOfBitcoin;
    }

    console.log(`Bought bitcoins: ${amountOfBitcoinsBought}`);
    if (amountOfBitcoinsBought > 0) {
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstBitcoin}`);
    }
    console.log(`Left money: ${totalAmount.toFixed(2)} lv.`);
}

calculateBitcoin([3124.15, 504.212, 2511.124]);