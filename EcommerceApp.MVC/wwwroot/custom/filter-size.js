
let size = document.querySelectorAll(".shop-size li a");
for (let s of size) {
    s.addEventListener("click", function (e) {
        e.preventDefault();

        let color = document.querySelector(".shop-color li.active a span");

        let newLink = s.getAttribute("href");
        newLink = newLink + "&color=" + color.getAttribute("class");

        let linkElement = document.createElement("a");
        linkElement.style.display = "none";
        linkElement.setAttribute("href", newLink);

        document.body.appendChild(linkElement);

        linkElement.click();


    });
}