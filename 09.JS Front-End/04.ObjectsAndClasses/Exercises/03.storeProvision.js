function storeProvision(firstArr, secondArr) {

    let storeObj = {};
    let allProducts = firstArr.concat(secondArr);
    for (let i = 0; i < allProducts.length; i += 2) {

        let key = allProducts[i];
        let value = Number(allProducts[i + 1]);
        if (!storeObj.hasOwnProperty(key)) {
            storeObj[key] = 0;
        }
        storeObj[key] += value;
    }

    for (let el in storeObj) {
        console.log(`${el} -> ${storeObj[el]}`)
    }
}

storeProvision(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'], ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);