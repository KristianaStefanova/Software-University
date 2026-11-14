function movies(data) {
    const store = [];

    for (let record of data) {
        if (record.includes("addMovie")) {
            record = record.replace("addMovie ", "").trim();
            let obj = {
                name: record
            };
            store.push(obj);
        } else if (record.includes("directedBy")) {
            const [name, director] = prepareMovieData("directedBy", record);
            updateMovie(name, "director", director)
            
        } else if (record.includes("onDate")) {
            const [name, date] = prepareMovieData("onDate", record);
            updateMovie(name, "date", date)
        }
    }

    store.forEach(x => {
        if (!x.name || !x.director || !x.date) {
            return;
        }
        console.log(JSON.stringify(x))
    });

    function prepareMovieData(key, string) {
        const movieData = string.split(` ${key} `);
        return movieData;

    }

    function updateMovie(name, key, data) {
        const currentMovie = store.find(x => x.name === name);
        if (!currentMovie) {
            return;
        }
        currentMovie[key] = data;
    }
}

movies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
])