function addItem() {
    const ulElRef = document.getElementById("items");
    const inputElValue = document.getElementById("newItemText").value;

    const liEl = document.createElement("li");
    liEl.textContent = inputElValue;
    ulElRef.appendChild(liEl);
    
    const aEl = document.createElement("a");
    aEl.textContent = "[Delete]";
    aEl.href = "#";
    liEl.appendChild(aEl);

    aEl.addEventListener('click', deleteItem)

    function deleteItem(e) {
        e.target.parentElement.remove();
    }
}
