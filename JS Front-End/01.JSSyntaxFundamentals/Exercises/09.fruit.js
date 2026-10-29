function fruitsBill(typeOfFruit, weightInGrams, pricePerKg){
    let weightInKg = weightInGrams / 1000;
    let bill = weightInKg * pricePerKg;

    console.log(`I need $${bill.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${typeOfFruit}.`);
}

fruitsBill('orange', 2500, 1.80);
