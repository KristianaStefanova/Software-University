function solve() {
    const inputRef = document.getElementById("input");
    const selectMenuRef = document.getElementById("selectMenuTo");
    const resultRef = document.getElementById("result");

    

    const inputValue = Number(inputRef.value);
    const selectItem = selectMenuRef.value;

    let result = "";
    if(selectItem === "binary") {
        result = inputValue.toString(2);
    } else {
        result = inputValue.toString(16).toUpperCase();
    }

    resultRef.value = result;
}