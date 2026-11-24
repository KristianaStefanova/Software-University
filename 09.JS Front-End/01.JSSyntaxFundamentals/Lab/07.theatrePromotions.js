function calculateTicketPrice(day, age) {
    
    switch (true) {
        case age >= 0 && age <= 18:
            if (day === "Weekday") {
                console.log("12$");
            } else if (day === "Weekend") {
                console.log("15$");
            } else if (day === "Holiday") {
                console.log("5$");
            }
            break;
        case age > 18 && age <= 64:
            if (day === "Weekday") {
                console.log("18$");
            } else if (day === "Weekend") {
                console.log("20$");
            } else if (day === "Holiday") {
                console.log("12$");
            }
            break;
            case age > 64 && age <= 122:
                if (day === "Weekday") {
                    console.log("12$");
                } else if (day === "Weekend") {
                console.log("15$");
            } else if (day === "Holiday") {
                console.log("10$");
            }
            break;
        default:
            console.log("Error!");
            break;
    }
}

let day = "Weekday";
let age = 42;

calculateTicketPrice(day, age);

