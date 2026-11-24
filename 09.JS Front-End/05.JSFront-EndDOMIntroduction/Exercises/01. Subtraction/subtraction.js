function subtract() {
    const firstNumRef = document.getElementById("firstNumber");
    const firstNumValue = Number(firstNumRef.value);

    const secondNumRef = document.getElementById("secondNumber");
    const secondNumValue = Number(secondNumRef.value);
    const result = firstNumValue - secondNumValue; 

    const resultContainerRef = document.getElementById("result");
    resultContainerRef.textContent = result;
}