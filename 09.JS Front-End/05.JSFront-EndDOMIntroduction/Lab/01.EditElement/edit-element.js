function editElement(htmlEl, strToFind, replacer) {
    let originalText = htmlEl.textContent;
    let updatedText = originalText.replaceAll(strToFind, replacer);
    
    htmlEl.textContent = updatedText;
}