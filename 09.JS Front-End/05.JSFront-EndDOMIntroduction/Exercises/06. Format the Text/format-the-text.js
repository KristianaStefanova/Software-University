function solve() {
    const textareaRef = document.getElementById("input");
    const textareValue = textareaRef.value;

    const outputRef = document.getElementById("output");

    outputRef.innerHTML = "";

    const sentences = textareValue
        .split(".")
        .map(sentence => sentence.trim())
        .filter(sentence => sentence.length > 0);

    for (let i = 0; i < sentences.length; i += 3) {
        const paragraph = sentences.slice(i, i + 3);

        const paragraphHTML = `<p>${paragraph.join(". ")}.</p>`;

        outputRef.innerHTML += paragraphHTML;
    }
}
