function deleteByEmail() {
    const tdElRef = document.querySelectorAll("tbody tr td:nth-child(2)");
    const inputElValue = document.getElementsByName("email")[0].value.trim();
    const resultRef = document.getElementById("result");
    
    let isFound = false;
    for(let td of tdElRef) {
        if(inputElValue === td.textContent) {
            td.parentElement.remove();
            isFound = true;
            resultRef.textContent = "Deleted";
        }
    }

    if(!isFound) {
        resultRef.textContent = "Not found."
    }
}
