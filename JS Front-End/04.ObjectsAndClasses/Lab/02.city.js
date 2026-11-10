function city(obj) {

    let entries = Object.entries(obj);

    for(let [key, val] of entries) {
        console.log(`${key} -> ${val}`)
    }
}

city({
    name: "Plovdiv",
    area: 389,
    population: 1162358,
    country: "Bulgaria",
    postCode: "4000"
});