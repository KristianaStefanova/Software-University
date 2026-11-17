function sumTable() {
    const priceTdEls = Array.from(document.querySelectorAll('tbody tr td:nth-child(2)'));
    const sumTdEl = priceTdEls.pop();

    let sum = 0;
    for(let tdEl of priceTdEls) {
        const price = Number(tdEl.textContent);
        sum += price;
    }

    sumTdEl.textContent = sum;
}