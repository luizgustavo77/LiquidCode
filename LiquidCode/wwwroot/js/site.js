$(document).ready(function () {
    $('.date').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.date_time').mask('00/00/0000 00:00:00');
    $('.cep').mask('00000-000');
    $('.phone').mask('0000-0000');
    $('.phone_with_ddd').mask('(00) 0000-0000');
    $('.phone_us').mask('(000) 000-0000');
    $('.mixed').mask('AAA 000-S0S');
    $('.cpf').mask('000.000.000-00', { reverse: true });
    $('.cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('.money').mask('000.000.000.000.000,00', { reverse: true });
    $('.money2').mask("#.##0,00", { reverse: true });
    $('.ip_address').mask('0ZZ.0ZZ.0ZZ.0ZZ', {
        translation: {
            'Z': {
                pattern: /[0-9]/, optional: true
            }
        }
    });
    $('.ip_address').mask('099.099.099.099');
    $('.percent').mask('##0,00%', { reverse: true });
    $('.clear-if-not-match').mask("00/00/0000", { clearIfNotMatch: true });
    $('.placeholder').mask("00/00/0000", { placeholder: "__/__/____" });
    $('.fallback').mask("00r00r0000", {
        translation: {
            'r': {
                pattern: /[\/]/,
                fallback: '/'
            },
            placeholder: "__/__/____"
        }
    });
    $('.selectonfocus').mask("00/00/0000", { selectOnFocus: true });
});

var mostrarLoading = function () {
    $("#modal").css('display', 'block');
}

var removerLoading = function () {
    $("#modal").css('display', 'none');
}

var ExtrairObjeto = function (linhaDatatable, idDatatable) {
    if (linhaDatatable != null) {
        return JSON.parse(JSON.stringify($(idDatatable).DataTable().row($(linhaDatatable).parents('tr')).data()));
    }
}

var bindEventos = function (idDivPopup, idDivForm) {
    $(idDivForm).dialog({
        autoOpen: false,
        width: 960,
        modal: true,

        open: function () {
            $(".ui-widget-overlay").appendTo(idDivPopup);
            $(this).dialog("widget").appendTo(idDivPopup);
        },
        close: function () {
            $(".ui-widget-overlay").remove();
            $(idDivForm).dialog("close");
        }
    });
}

var adicionarHtmlPopupTitleBar = function (idDivPopup, idDivForm, titulo) {
    var popup = '#' + idDivPopup;
    var form = '#' + idDivForm;

    var html = "<div id=" + "'" + idDivPopup + "'" + " style='z-index:110;' " + ">" +
        "<div id=" + "'" + idDivForm + "'" + " title=" + "'" + titulo + "'" + " style='display:none;background-color: #666666;color:white;margin-top:0px; z-index:110;'></div>" +
        "</div>";

    $(popup).remove();

    $("#renderbody").append(html);

    bindEventos(popup, form);

    return $(popup);
}

var montarModalComEfeito = function (IdDivComHashtag, calbackFunction, widthModal) {

    if (widthModal)
        return $(IdDivComHashtag).dialog({
            autoOpen: true, show: "clip", hide: "clip",
            width: widthModal,
            open: function (event, ui) {
                $('.focusIN').focus();
                //hide close button.
                $(this).parent().children().children('.ui-dialog-titlebar-close').attr('id', 'btn_close_modal').blur();
                if (calbackFunction)
                    calbackFunction();
            },
        });
    else
        return $(IdDivComHashtag).dialog({
            autoOpen: true, show: "clip", hide: "clip",
            open: function (event, ui) {
                $('.focusIN').focus();
                //hide close button.
                $(this).parent().children().children('.ui-dialog-titlebar-close').attr('id', 'btn_close_modal').blur();
                if (calbackFunction)
                    calbackFunction();
            },
        });
}