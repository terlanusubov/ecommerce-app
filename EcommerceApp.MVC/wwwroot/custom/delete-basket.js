function DeleteProductFromCart(callback,productId) {
    const xhttp = new XMLHttpRequest();
    xhttp.onload = function () {
        let res = JSON.parse(this.responseText);
        if (res.status == 400) {
            alert("Xeta");
            return;
        }

        callback();
    }

    xhttp.open("GET", "/cart/delete?productId=" + productId, true);

    xhttp.send();
}