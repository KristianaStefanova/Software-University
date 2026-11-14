function employees(data) {
    let store = {};

    for (let name of data) {
        store[name] = name.length;
    }

    // for(let key in store) {
    //     console.log(`Name: ${key} -- Personal Number: ${store[key]}`)
    // }

    for (let [key, value] of Object.entries(store)) {
        console.log(`Name: ${key} -- Personal Number: ${value}`)
    }
}

employees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]);

