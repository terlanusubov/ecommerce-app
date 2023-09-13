let cartButton = document.querySelector("#add-cart");

cartButton.addEventListener("click", function () {
    let countValue = document.querySelector("#cart-count").value;

    let productId = this.getAttribute("data-productId");

    let cartAddModel = {
        ProductId: productId,
        Count: countValue
    };

    const xhttp = new XMLHttpRequest();
    xhttp.onload = function () {

        let res = JSON.parse(this.responseText);

        if (res.status == 400) {
            alert("xeta");
            return;
        }

        let miniCart = document.querySelector(".minicart");



        if (res.data.isExists == false) {

            let li = document.createElement("li");
            li.setAttribute("data-id", res.data.productId);
            let newCartItem = `
                                <div class="cart-img">
                                    <a href="product-details.html">
                                        <img src="${res.data.image}" alt="" />
                                    </a>
                                </div>
                                <div class="cart-content">
                                    <h3>
                                        <a href="/product/index?productId=${res.data.productId}">${res.data.name}</a>
                                    </h3>
                                    <div class="cart-price">

                                    </div>
                                </div>
                                <div class="del-icon new">
                                    <a data-productId=${res.data.productId} href="#">
                                        <i class="far fa-trash-alt"></i>
                                    </a>
                                </div>
                            `;

            li.innerHTML = newCartItem;

            miniCart.insertBefore(li, miniCart.firstChild);

            let link = li.querySelector(".del-icon a");
            link.onclick = function (e) {
                e.preventDefault();

                let productId = this.getAttribute("data-productId");
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
            }

        }

        let cartCount = document.querySelector(".cart-count");

        cartCount.innerText = Number(cartCount.innerText) + Number(countValue);

        document.querySelector(".total-price span:last-child").innerText = "$" + res.data.totalPrice;



    }

    xhttp.open("POST", "/cart/add", true);
    xhttp.setRequestHeader('Content-Type', 'application/json')

    xhttp.send(JSON.stringify(cartAddModel));


});