function sumFirstAndLastArrayElements(arr) {
    if (arr.length === 0) {
        return 0; 
    }
    return arr[0] + arr[arr.length - 1]; 
}

sumFirstAndLastArrayElements([1, 2, 3, 4]); 