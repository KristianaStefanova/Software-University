function towns(arr) {
    let result = [];

    for (let el of arr) {
        let [town, latitude, longitude] = el.split(" | ");

        let obj = {
            town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        };

        result.push(obj);
    }

    result.forEach(obj => console.log(obj));
}

towns(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625'])