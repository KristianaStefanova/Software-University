function solve() {
    const result = {};
    const inputRef = document.querySelector("textarea");
    const bestRestaurantRef = document.querySelector("#bestRestaurant p");
    const bestWorkersRef = document.querySelector("#workers p");
    const data = JSON.parse(inputRef.value);

    for (let el of data) {
        const restaurantData = el.split(" - ");
        const name = restaurantData[0];

        if (!result.hasOwnProperty(name)) {
            result[name] = {
                avg: 0,
                bestSalary: 0,
                workers: []
            }
        }

        const newWorkers = createWorkerList(restaurantData[1]);
        const workers = concatWorkersList(result[name].workers, newWorkers);
        result[name].workers = workers;
        updateRestaurantData(result[name]);
    }

    const [bestName, bestData] = findBestRestaurant(result);

    bestRestaurantRef.textContent = `Name: ${bestName} Average Salary: ${bestData.avg.toFixed(2)} Best Salary: ${bestData.bestSalary.toFixed(2)}`;

    let buff = "";

    bestData.workers.sort((a, b) => b.salary - a.salary).forEach(worker => {
        buff += `Name: ${worker.name} With Salary: ${worker.salary} `
    });

    bestWorkersRef.textContent = buff.trim();

    function findBestRestaurant(data) {
        return Object.entries(data)
            .sort(([name1, restaurantData1], [name2, restaurantData2]) => {
                return restaurantData2.avg - restaurantData1.avg
            })[0];
    }

    function updateRestaurantData(restaurant) {
        const workers = restaurant.workers;
        let sum = 0;
        let bestSalary = 0;

        workers.forEach(worker => {
            sum += worker.salary;
            if (bestSalary < worker.salary) {
                bestSalary = worker.salary
            }
        });
        const avg = sum / workers.length;

        restaurant.avg = avg;
        restaurant.bestSalary = bestSalary;
    }

    function concatWorkersList(oldWorkers, newWorkers) {
        return oldWorkers.concat(newWorkers);
    }

    function createWorkerList(workersDataString) {
        const result = [];
        const workers = workersDataString.split(", ");
        workers.forEach(str => {
            const [name, salary] = str.split(" ");
            const worker = {
                name,
                salary: Number(salary)
            }
            result.push(worker);
        })

        return result;
    }
}
