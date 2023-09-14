let delIcons = document.querySelectorAll(".del-icon a");

for (let delIcon of delIcons) {

    delIcon.addEventListener("click", function (e) {
        e.preventDefault();

        let productId = delIcon.getAttribute("data-productId");
        DeleteProductFromCart(function () {

            let deleteElement = document.querySelector(`li[data-id="${productId}"]`);

            deleteElement.parentElement.removeChild(deleteElement);

            let oldCartCount = document.querySelector(".cart-count").innerText;
            document.querySelector(".cart-count").innerText = Number(oldCartCount) - res.data.count;

            document.querySelector(".total-price span:last-child").innerText = "$" + res.data.totalPrice;


        }, productId);


    })
}

