function phonebook(arr) {
    let contacts = {};

    for(let arg  of arr) {
        let [name, phone] = arg.split(" ");
        contacts[name] = phone;
    }

    let entries = Object.entries(contacts);

    for(let [name, address] of entries) {
        console.log(`${name} -> ${address}`)
    }
}

phonebook(['Tim 0834212554', 'Peter 0877547887', 'Bill 0896543112', 'Tim 0876566344'])