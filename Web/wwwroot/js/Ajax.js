/* Generic Ajax function for link tag*/

const spinner =
    "<div class='text-center w-100 min-vh-100 d-flex justify-content-center align-items-center'><div class='spinner-border' role='status'><span class='sr-only'>Loading...</span></div></div>";

function ajaxLink() {

    $('a[ajax-call="yes"]').click(function (e) {

        e.preventDefault();
        var object = $(this);
        var url = object.attr('ajax-url');
        var resultId = `#${object.attr('ajax-result')}`;
        object.attr('ajax-call', 'set');
        $(resultId).html(spinner);
        $.get(
            url,
            function (result) {
                $(resultId).html(result);
            });


    }).attr('ajax-call', 'set');

    $('.external[ajax-call="yes"]').click(function (e) {

        //e.preventDefault();
        var object = $(this);
        var url = object.attr('ajax-url');
        object.attr('ajax-call', 'set');
        $(resultId).html(spinner);

        $.get(url);
    }).attr('ajax-call', 'set');

    $('button[ajax-call="yes"]').click(function (e) {

        var object = $(this);
        var url = object.attr('ajax-url');
        var resultId = `#${object.attr('ajax-result')}`;
        object.attr('ajax-call', 'set');
        $(resultId).html();

        $.get(
            url,
            function (result) {
                $(resultId).html(result);
            });
    }).attr('ajax-call', 'set');

}

/* Generic Ajax function for forms*/
function ajaxForm() {

    $('form[ajax-call="yes"]').submit(function (e) {

        $(this).attr('ajax-call', 'added');
        e.preventDefault();
        var form = $(this);
        var url = form.attr('ajax-url');
        var resultId = form.attr('ajax-result');
        var asyncAjax = !this.hasAttribute('sync');

        var beginClass = `.${form.attr('ajax-begin')}`;

        $.ajax({
            type: 'POST',
            url: url,
            data: form.serialize(),
            async: asyncAjax,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (result) {
                if (resultId !== '') {
                    $(`#${resultId}`).html(result);
                }
            },
            beforeSend: function (xhr) {
                xhr.overrideMimeType('application/x-www-form-urlencoded; charset=UTF-8');
                $(beginClass).val('');
            }

        });
    }).attr('ajax-call', 'set');
}

/* Generic Ajax function for initial loading*/
function ajaxInit() {
    var object = $('.ajaxInit[ajax-call="yes"]');
    var url = object.attr('ajax-url');
    var resultId = `#${object.attr('ajax-result')}`;
    $(resultId).html(spinner);
    $.get(
        url,
        function (result) {
            $(resultId).html('');
            $(resultId).html(result);
        }
    );
}

function ajaxInitSecond() {
    var object = $('.ajaxInitSecond[ajax-call="yes"]');
    var url = object.attr('ajax-url');
    var resultId = `#${object.attr('ajax-result')}`;
    $(resultId).html(spinner);
    $.get(
        url,
        function (result) {
            $(resultId).html('');
            $(resultId).html(result);
        }
    );

}

$(document).ready(function () {

    /* Calling initial Ajax */
    ajaxInit();
    ajaxInitSecond();

    /* Calling Ajax form */
    ajaxForm();

    //Calling Ajax link
    ajaxLink();

});

$(document).ajaxComplete(function () {

    /* Calling Ajax link */
    ajaxLink();

    /* Calling Ajax form */
    ajaxForm();

});