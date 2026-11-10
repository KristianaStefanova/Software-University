function meetings(arr) {

    let meetings = {};

    for(let arg of arr) {
        let [day, name] = arg.split(" ");

        if(day in meetings) {
            console.log(`Conflict on ${day}!`)
        } else {
            meetings[day] = name;
            console.log(`Scheduled for ${day}`)
        }
    }

    let entries = Object.entries(meetings);
    for(let [day, name] of entries) {
        console.log(`${day} -> ${name}`)
    }
}

meetings([
    'Friday Bob',
    'Saturday Ted',
    'Monday Bill',
    'Monday John',
    'Wednesday George']);