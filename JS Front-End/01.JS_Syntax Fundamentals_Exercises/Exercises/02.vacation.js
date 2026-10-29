function calculateTotalVacationHostBillWithDiscount (groupOfPeople, typeOfGroup, dayOfWeek) {
    
    let totalCostWithoutDiscount = determineTotalVacationHostBillWithoutDiscount(groupOfPeople, typeOfGroup, dayOfWeek);
    let totalCostWithDiscount = totalCostWithoutDiscount;

    if(typeOfGroup === "Students" && groupOfPeople >= 30) {
        totalCostWithDiscount = totalCostWithoutDiscount * 0.85;
    } else if(typeOfGroup === "Business" && groupOfPeople >= 100) {
        totalCostWithDiscount = groupOfPeople * calculateCostPerPerson(typeOfGroup, dayOfWeek) - (10 * calculateCostPerPerson(typeOfGroup, dayOfWeek));
    } else if(typeOfGroup === "Regular" && groupOfPeople >= 10 && groupOfPeople <= 20) {
        totalCostWithDiscount = totalCostWithoutDiscount * 0.95;
    }
    
    return totalCostWithDiscount;
}

function determineTotalVacationHostBillWithoutDiscount (groupOfPeople, typeOfGroup, dayOfWeek) {

   let totalCostWithoutDiscount = groupOfPeople * calculateCostPerPerson(typeOfGroup, dayOfWeek);

    return totalCostWithoutDiscount;
}

function calculateCostPerPerson (typeOfGroup, dayOfWeek) {

    if(typeOfGroup === "Students") {
       switch(dayOfWeek) {
            case "Friday":
                return  8.45;
            case "Saturday":
                return 9.80;
            case "Sunday":
                return 10.46;
        }
    } else if(typeOfGroup === "Business") {
        switch(dayOfWeek) {
            case "Friday":
                return 10.90;
            case "Saturday":
                return 15.60;
            case "Sunday":
                return 16.00;
        }
    } else if(typeOfGroup === "Regular") {
        switch(dayOfWeek) {
            case "Friday":
                return 15.00;
            case "Saturday":
                return 20.00;
            case "Sunday":
                return 22.50;
        }
    }
}

let totalCost = calculateTotalVacationHostBillWithDiscount(40, "Regular", "Saturday");
console.log(`Total price: ${totalCost.toFixed(2)}`);




