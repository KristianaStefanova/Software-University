function addItem() {

    const ulItemsRef = document.getElementById("items");
    const inputTextRef = document.getElementById("newItemText");

    const inputTextValue = inputTextRef.value.trim();
    
    const newLi = document.createElement("li");
    newLi.textContent = inputTextValue;
    ulItemsRef.appendChild(newLi);
}
