function manageSongs(arr) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList,
            this.name = name,
            this.time = time
        }
    }

    let songCount = arr.shift();
    let filter = arr.pop();
    let songsList = [];

    for (let i = 0; i < songCount; i++) {
        let [typeList, name, time] = arr[i].split("_");
        let songObj = new Song(typeList, name, time);
        songsList.push(songObj);
    }

    if (filter === "all") {
        for (let song of songsList) {
            console.log(`${song.name}`)
        }
    } else {
        let filteredSongs = songsList.filter(songsObj => songsObj.typeList === filter);
        for(let song of filteredSongs) {
            console.log(`${song.name}`)
        }
    }
}

manageSongs([4,
    'favourite_DownTown_3:14',
    'listenLater_Andalouse_3:24',
    'favourite_In To The Night_3:58',
    'favourite_Live It Up_3:48',
    'listenLater']);