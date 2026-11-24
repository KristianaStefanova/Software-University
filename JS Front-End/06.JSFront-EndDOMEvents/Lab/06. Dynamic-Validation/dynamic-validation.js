document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const inputElRef = document.getElementById("email");

    inputElRef.addEventListener('change', handleEmailChange);

    function handleEmailChange() {
        const email = inputElRef.value.trim();

        const pattern = /[a-z]+@[a-z]+\.[a-z]+/;
        if (!pattern.test(email)) {
            inputElRef.classList.add("error");
        } else {
            inputElRef.classList.remove("error");
        }
    }
}
