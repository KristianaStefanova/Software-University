document.addEventListener('DOMContentLoaded', focused);

function focused() {
    const inputs = document.getElementsByTagName("input");
    
    for(const inputEl of inputs) {
        inputEl.addEventListener('focus', addFocusedClass);
        inputEl.addEventListener('blur', removeFocusedClass)
    }

    function addFocusedClass(e) {
        e.target.parentElement.classList.add("focused");
    }

    function removeFocusedClass(e) {
        e.target.parentElement.classList.remove("focused");
    }    
}
 