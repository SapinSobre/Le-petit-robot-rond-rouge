
var boutonAjouterFrais = document.getElementById('boutonAjouterFrais');
var tBody = document.getElementById('tBody');
var nouveauTr;
boutonAjouterFrais.addEventListener("click", function (e) {
    nouveauTr = document.createElement('tr');   
    nouveauTr.innerHTML = '<td><a href="/Gestion/AjouterFrais"><img src="../Content/images/update.png" alt="icône ajouter"/></td><td><input class="intituleInput" type="text"/></a></td>' +
        '<td class="frais"><input class="fraisInput" type="text" style="text-align:right;"/></td>';
    tBody.insertBefore(nouveauTr, e.target.parentNode.nextElementSibling.nextElementSibling.lastElementChild.lastElementChild);
});

var inputs = document.getElementsByClassName('fraisInput');
var result = document.getElementById('result');

for (var i = 0; i < inputs.length; i++) {
    inputs[i].addEventListener("change", function (e) {
        result.innerText = 100;
    });
}