let delIcons = document.querySelectorAll(".del-icon a");

for (let delIcon of delIcons) {

    delIcon.addEventListener("click", function (e) {
        e.preventDefault();

        let productId = delIcon.getAttribute("data-productId");
        const xhttp = new XMLHttpRequest();
        xhttp.onload = function () {
            let res = JSON.parse(this.responseText);
            if (res.status == 400) {
                alert("Xeta");
                return;
            }


            let deleteElement = document.querySelector(`li[data-id="${productId}"]`);

            deleteElement.parentElement.removeChild(deleteElement);

            let oldCartCount = document.querySelector(".cart-count").innerText;
            document.querySelector(".cart-count").innerText = Number(oldCartCount) - res.data.count;

            document.querySelector(".total-price span:last-child").innerText = "$" + res.data.totalPrice;

        }

        xhttp.open("GET", "/cart/delete?productId=" + productId, true);

        xhttp.send();
    })
}
