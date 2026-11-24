function radioCrystals(input) {

    const target = input[0];

    for (let i = 1; i < input.length; i++) {
        processChunk(input[i], target);
    }

    function cutCrystal(chunk, target) {
        let count = 0;

        while (Math.floor(chunk / 4) >= target - 1) {
            chunk /= 4;
            count++;
        }

        if (count > 0) {
            console.log(`Cut x${count}`);
            chunk = Math.floor(chunk);
            console.log('Transporting and washing');
        }

        return chunk;
    }

    function lapCrystal(chunk, target) {
        let count = 0;

        while (Math.floor(chunk * 0.8) >= target - 1) {
            chunk *= 0.8;
            count++;
        }

        if (count > 0) {
            console.log(`Lap x${count}`);
            chunk = Math.floor(chunk);
            console.log('Transporting and washing');
        }

        return chunk;
    }

    function grindCrystal(chunk, target) {
        let count = 0;

        while (chunk - 20 >= target - 1) {
            chunk -= 20;
            count++;
        }

        if (count > 0) {
            console.log(`Grind x${count}`);
            chunk = Math.floor(chunk);
            console.log('Transporting and washing');
        }

        return chunk;
    }

    function etchCrystal(chunk, target) {
        let count = 0;

        while (chunk - 2 >= target - 1) {
            chunk -= 2;
            count++;
        }

        if (count > 0) {
            console.log(`Etch x${count}`);
            chunk = Math.floor(chunk);
            console.log('Transporting and washing');
        }

        return chunk;
    }

    function processChunk(chunk, target) {
        console.log(`Processing chunk ${chunk} microns`);

        chunk = cutCrystal(chunk, target);
        chunk = lapCrystal(chunk, target);
        chunk = grindCrystal(chunk, target);
        chunk = etchCrystal(chunk, target);

        if (chunk === target - 1) {
            chunk++;
            console.log('X-ray x1');
        }

        console.log(`Finished crystal ${chunk} microns`);
    }
}

radioCrystals([1375, 50000]);
