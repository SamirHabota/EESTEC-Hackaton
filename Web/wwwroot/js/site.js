$(document).ready(function () {
    $('#contact-tab').trigger('click');
    $('#home-tab').trigger('click');
});

$(document).ajaxComplete(function () {});

function flip() {
    var card = document.getElementById("cardId");
    var isFLipped = card.getAttribute("isFlipped");
    if (isFLipped == 'true') {
        card.classList.add("flipped");
        setTimeout(function () {
            document.getElementById("hintId").setAttribute("style", "display:none");
            document.getElementById("showAnswerId").setAttribute("style", "display:none");
        }, 300);
        card.setAttribute("isFlipped", "false");
    }
    else {
        card.classList.remove("flipped");
        setTimeout(function () {
            document.getElementById("hintId").removeAttribute("style", "display:none");
            document.getElementById("showAnswerId").removeAttribute("style", "display:none");
        }, 300);
        card.setAttribute("isFlipped", "true");
    }
}

document.body.onkeyup = function (e) {
    if (e.keyCode == 32) {
        flip();
    }
}   