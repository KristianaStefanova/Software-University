function solve() {
  const textRef = document.getElementById("text");
  const textValue = textRef.value;

  const namigConventionRef = document.getElementById("naming-convention");
  const namigConventionValue = namigConventionRef.value;

  const resultRef = document.getElementById("result");

  let result = "";
  const textArr = textValue.split(", ");

  for (let el of textArr) {
    const arrWords = el.split(" ");
    const firstWord = arrWords[0];

    if (namigConventionValue === "Camel Case") {
      result = arrWords[0].toLowerCase() +
        arrWords.slice(1)
          .map(word => word[0].toUpperCase() + word.slice(1).toLowerCase())
          .join("");
    } else if (namigConventionValue === "Pascal Case") {
      result = arrWords.map(word => word[0].toUpperCase() + word.slice(1).toLowerCase())
          .join("");
    } else {
      result = "Error!"
    }
  }

  resultRef.textContent = result;
}