function convertToObj(jsonString) {

    let personObj = JSON.parse(jsonString);
    let entries = Object.entries(personObj);

    for(let [key, val] of entries) {
        console.log(`${key}: ${val}`);
    }
}

convertToObj('{"name": "George", "age": 40, "town": "Sofia"}')