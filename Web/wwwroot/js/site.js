// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ajaxComplete(function () {

});

function flip() {
    var card = document.getElementById("cardId");
    var isFLipped = card.getAttribute("isFlipped");
    var options = document.getElementById("optionsHolderId");
    if (isFLipped == 'true') {


        setTimeout(function () {
            document.getElementById("hintId").setAttribute("style", "display:none");
            document.getElementById("showAnswerId").setAttribute("style", "display:none");
            options.classList.remove("d-none");
        }, 300);      

        card.classList.add("flipped");
   
        card.setAttribute("isFlipped", "false");
    }
    else {
        card.classList.remove("flipped");
        setTimeout(function () {
            document.getElementById("hintId").removeAttribute("style", "display:none");
            document.getElementById("showAnswerId").removeAttribute("style", "display:none");
            options.classList.add("d-none");
        }, 500);
        card.setAttribute("isFlipped", "true");
    }
}

window.onkeydown = function (e) {
    if (e.keyCode == 32 && e.target == document.body) {
        e.preventDefault();
        flip();
    }
}   