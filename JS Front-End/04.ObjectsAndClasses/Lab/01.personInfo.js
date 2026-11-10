function personInfo(firstName, lastName, age) {

    let personObj = {
        firstName: firstName,
        lastName: lastName,
        age: age
    }

    return personObj;
}

console.log(personInfo("Peter", "Pan", "20"));