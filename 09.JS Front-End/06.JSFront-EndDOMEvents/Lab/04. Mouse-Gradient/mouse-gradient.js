function attachGradientEvents() {
    const gradientDivElRef = document.getElementById("gradient");
    const resultDivRef = document.getElementById("result");

    gradientDivElRef.addEventListener('mousemove', handleMouseMove);


    function handleMouseMove(e) {
        const cursorDistanceFromLeft = e.offsetX;
        const divElWidth = e.target.clientWidth;
        const percent = Math.floor(cursorDistanceFromLeft / divElWidth * 100);
        resultDivRef.textContent = `${percent}%`;
    }
}
