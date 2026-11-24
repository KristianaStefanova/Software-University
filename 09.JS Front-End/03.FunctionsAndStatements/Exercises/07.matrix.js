function matrix(n) {
    let array = Array(n);
    array.fill(new Array(n).fill(n));

    printMatrix(array);

    function printMatrix(matrix) {
        matrix.forEach(row => console.log(row.join(" ")));
    }
}

matrix(5);