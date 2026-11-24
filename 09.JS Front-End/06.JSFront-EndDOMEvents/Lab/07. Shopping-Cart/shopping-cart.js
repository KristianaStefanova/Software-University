document.addEventListener('DOMContentLoaded', solve);

function solve() {
   let products = new Set();
   let totalPrice = 0;

   const productsTitleRef = document.getElementsByClassName("product-title");
   const productsPriceRef = document.getElementsByClassName("product-line-price");

   const addButtons = document.getElementsByClassName("add-product");
   const textareaRef = document.getElementsByTagName("textarea")[0];
   const checkoutButton = document.getElementsByClassName("checkout")[0];

   for(const button of addButtons) {

      button.addEventListener('click', handleAddButton);
   }

   checkoutButton.addEventListener('click', handleCheckoutButton);

   function handleCheckoutButton() {
      const productsArr = Array.from(products); 
      textareaRef.value += `You bought ${productsArr.join(", ")} for ${totalPrice.toFixed(2)}.`

      checkoutButton.disabled = true;
      for(const buttonEl of addButtons) {
         buttonEl.disabled = true;
      }
   }

   function handleAddButton(e) {
      const fullProductDivEl = e.target.parentElement.parentElement;
      const productTitleDivEl = fullProductDivEl.querySelector(".product-title");
      const productTitle = productTitleDivEl.textContent;
      products.add(productTitle);

      const productPriceDivEl = fullProductDivEl.querySelector(".product-line-price");
      const productPrice = Number(productPriceDivEl.textContent);
      totalPrice += productPrice;

      textareaRef.value += `Added ${productTitle} for ${productPrice.toFixed(2)} to the cart.\n`
   }
}
