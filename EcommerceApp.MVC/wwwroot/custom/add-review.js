let rating = null;

let ratingListLinks = document.querySelectorAll(".rating-list a");

for (let link of ratingListLinks) {
    link.addEventListener("click", function (e) {
        e.preventDefault();

        rating = link.getAttribute("data-id");

    })
}


let addReviewButton = document.querySelector("#add-review-button");

addReviewButton.addEventListener("click", function () {
    let productId = document.querySelector("#add-review-productId").value;
    let description = document.querySelector("#message").value;

    let data = {
        ProductId: productId,
        Description: description,
        Rating: rating
    };


    const xhttp = new XMLHttpRequest();
    xhttp.onload = function () {

        document.querySelector("#message").value = "";
        rating = null;


        let result = JSON.parse(this.responseText);
        if (result.status == 400) {
            alert("Xeta bas verdi!");
            return;
        }


        let commentWrapper = document.createElement("div");

        commentWrapper.className = "product-commnets-list mb-25 pb-15";

        let ratingDiv = `   <div class="pro-rating">`;

        for (let i = 0; i < result.rate; i++) {
            ratingDiv += '<i class="far fa-star"></i>';
        }

        ratingDiv += ' </div>';

        let comment = `
                    <div class="pro-comments-img">
                        <img style="width:50px;" src="${result.image}" alt="">
                    </div>
                    <div class="pro-commnets-text">
                        <h4>
                            ${result.name} ${result.surname} -
                            <span>${result.date}</span>
                        </h4>
                       ${ratingDiv}
                        <p>
                                    ${description}
                        </p>
                    </div>
              `;

        commentWrapper.innerHTML = comment;

        let descText = document.querySelector(".desc-text .product-commnets");

        descText.insertBefore(commentWrapper, descText.firstChild)

    }

    xhttp.open("POST", "/product/addReview", true);
    xhttp.setRequestHeader('Content-Type', 'application/json')

    xhttp.send(JSON.stringify(data));
})
