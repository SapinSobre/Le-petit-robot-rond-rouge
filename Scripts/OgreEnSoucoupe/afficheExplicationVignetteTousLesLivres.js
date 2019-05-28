var vignettesLivre = document.querySelectorAll('div[class="imageLivre"] img');
for (var i = 0; i < vignettesLivre.length; i++) {
    vignettesLivre[i].addEventListener("mouseover", function (e) {          
        e.target.parentNode.parentNode.nextElementSibling.style.display = "inline-block";
        e.target.parentNode.parentNode.nextElementSibling.style.opacity = 0.8;
    });
   
}

var closeWindow = document.querySelectorAll('div[class="closeWindow"]');
for (var i = 0; i < closeWindow.length; i++) {
    closeWindow[i].addEventListener("click", function (e) {
        e.target.parentNode.parentNode.style.display = "none";
    });
}