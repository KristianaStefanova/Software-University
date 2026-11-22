function toggle() {
    const buttonRef = document.getElementsByClassName("button")[0];
    const extraRef = document.getElementById("extra");

    if (extraRef.style.display === "block") {
        extraRef.style.display = "none";
        buttonRef.textContent = "More"
    } else {
        extraRef.style.display = "block";
        buttonRef.textContent = "Less"
    }
}