function extract(content) {
    const titleRef = document.getElementById(content);
    const text = titleRef.textContent;
    const pattern = /\(.*?\)/g;

    const matches = text.match(pattern);

    return matches.map(match => match.slice(1, -1)).join("; ");
}