function calcOrderPrice(product, quantity) {

    let price = 0;
    switch (product) {
        case 'coffee':
            price = (quantity * 1.50).toFixed(2);
            break;
        case 'water':
            price = (quantity * 1.00).toFixed(2);
            break;
        case 'coke':
            price = (quantity * 1.40).toFixed(2);
            break;
        case 'snacks':
            price = (quantity * 2.00).toFixed(2);
            break;
    }
    console.log(price);
}

calcOrderPrice('water', 5);