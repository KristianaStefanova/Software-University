function solve() {
   const searchInputRef = document.getElementById("searchField");
   const textValue = searchInputRef.value;
   const tableRowsRef = document.querySelectorAll("tbody tr");

   searchInputRef.value = "";
   for (let i = 0; i < tableRowsRef.length; i++) {
      const row = tableRowsRef[i];
      const tds = row.children;

      for (let y = 0; y < tds.length; y++) {
         const tdText = tds[y].textContent;

         if (tdText.includes(textValue)) {
            row.classList.add("select")
            break;
         } else {
            row.classList.remove("select");
         }
      }
   }
}