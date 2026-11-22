function solve() {
   const townsRef = document.getElementById("towns").children;
   const searchedTextValue = document.getElementById("searchText").value;
   const divResultRef = document.getElementById("result");

   let counter = 0;
   for(let town of townsRef) {
      town.style.fontWeight = "normal";
      town.style.textDecoration = "none";

      if(town.textContent.toLowerCase().includes(searchedTextValue.toLowerCase())) {
         counter++

         town.style.fontWeight = "bold";
         town.style.textDecoration = "underline";
      }
   }

   divResultRef.textContent = `${counter} matches found`
}