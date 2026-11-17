function extractText() {
    let liEls = document.querySelectorAll('li');
    let textareEl = document.querySelector('#result');

    for(let listEl of liEls) {
        let text = listEl.textContent;
        textareEl.textContent += text + '\n';
    }
}