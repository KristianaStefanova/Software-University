function solve() {

    const headers = document.querySelectorAll("th");
    const rows = document.querySelectorAll("tbody tr");
    const result = [];

    rows.forEach(row => {

        const obj = {};

        headers.forEach((header, index) => {

            const checkbox = header.querySelector("input");

            if (checkbox.checked) {

                obj[checkbox.name] = row.cells[index].textContent.trim();

            }

        });

        result.push(obj);
    });

    document.getElementById("output").value =
        JSON.stringify(result, null, 2);
}