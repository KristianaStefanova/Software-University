function picccolo(arr) {
    let carNumbers = [];

    for (let el of arr) {
        let [direcction, carNumber] = el.split(", ");
        if (direcction === "IN" && !carNumbers.includes(carNumber)) {
            carNumbers.push(carNumber);
        } else if (direcction === "OUT") {
            const index = carNumbers.indexOf(carNumber);
            if (index !== -1) {
                carNumbers.splice(index, 1)
            }
        }
    }

    if (carNumbers.length === 0) {
        console.log(`Parking Lot is Empty`)
    } else {
        carNumbers.sort((a, b) => a.localeCompare(b)).forEach(number => console.log(number));
    }
}

picccolo(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'])