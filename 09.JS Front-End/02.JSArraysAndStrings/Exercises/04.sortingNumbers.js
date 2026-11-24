function sortingNumbers(arr) {

    let sortedArr = arr.sort((a, b) => a - b);

    let result = [];
    for (let i = 0; i < sortedArr.length / 2; i++) {
        if (arr.length % 2 !== 0 && i === Math.floor(sortedArr.length / 2)) {
            result.push(sortedArr[i]);
            break;
        }

        result.push(sortedArr[i]);
        result.push(sortedArr[sortedArr.length - 1 - i]);

    }

    return result;
}

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56 , 100000000]));