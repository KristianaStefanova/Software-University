function solve() {
    const headersRef = document.querySelectorAll("th");

    headersRef.forEach(header => {
        const checkbox = header.querySelector("input");

        if (checkbox.checked) {
            console.log(checkbox.name);
        }
    })

    const rowsRef = document.querySelectorAll("tbody td");
}