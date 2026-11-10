function addressBook(arr) {

    let addressBook = {};

    for (let arg of arr) {
        let [name, address] = arg.split(":");

        addressBook[name] = address;
    }

    let entries = Object.entries(addressBook).sort((a, b) => (a[0].localeCompare(b[0])));
    for (let [name, address] of entries) {
        console.log(`${name} -> ${address}`)
    }
}

addressBook([
    'Bob:Huxley Rd',
    'John:Milwaukee Crossing',
    'Peter:Fordem Ave',
    'Bob:Redwing Ave',
    'George:Mesta Crossing',
    'Ted:Gateway Way',
    'Bill:Gateway Way',
    'John:Grover Rd',
    'Peter:Huxley Rd',
    'Jeff:Gateway Way',
    'Jeff:Huxley Rd'])