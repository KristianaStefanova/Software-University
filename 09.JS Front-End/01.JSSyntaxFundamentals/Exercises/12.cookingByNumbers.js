function cookingByNumbers(arg1, ...operations) {
    
    let operationsMap = {
        chop: (num) => num / 2,
        dice: (num) => Math.sqrt(num),
        spice: (num) => num + 1,
        bake: (num) => num * 3,
        fillet: (num) => num * 0.8
    }

    let number = Number(arg1);

    operations.forEach(operation => {
        number = operationsMap[operation](number);
        console.log(number);
    });
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');