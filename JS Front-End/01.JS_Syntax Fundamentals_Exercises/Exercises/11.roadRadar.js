function roadRadar(speed, area) {
    let limits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    }

    let limit = limits[area];

    if (speed > limit) {

        let difference = speed - limit;
        let status = "";

        if (difference <= 20) {
            status = "speeding";
        } else if (difference <= 40) {
            status = "excessive speeding";
        } else {
            status = "reckless driving";
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`);
    } else {
        
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
}