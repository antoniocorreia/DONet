$(document).ready(function () {

    var statusMessage = $("#StatusMessage").val();
    var statusMessageType = $("#StatusMessageType").val();

    if (statusMessage != null && statusMessage != '') {
        var n = noty({
            layout: 'top',
            text: statusMessage,
            theme: 'defaultTheme', // or 'relax'
            type: statusMessageType,
            template: '<div class="noty_message"><span class="noty_text"></span><div class="noty_close"></div></div>',
            animation: {
                open: { height: 'toggle' }, // jQuery animate function property object
                close: { height: 'toggle' }, // jQuery animate function property object
                easing: 'swing', // easing
                speed: 500 // opening & closing animation speed
            }
        });
        //ExibirStatusMessage(statusMessage, statusMessageType);
    }

});

function ExibirStatusMessage(statusMessage, statusMessageType) {
    var htmlalert = "<div class='alert {class} fade in'> <button type='button' class='close' data-dismiss='alert'>x</button> <strong>{titulo}</strong> {texto} </div>";
    htmlalert = htmlalert.replace("{texto}", statusMessage);

    if (statusMessageType == "error") {
        htmlalert = htmlalert.replace('{titulo}', "Erro!");
        htmlalert = htmlalert.replace('{class}', 'alert-danger');
    } else if (statusMessageType == "success") {
        htmlalert = htmlalert.replace('{titulo}', "Sucesso!");
        htmlalert = htmlalert.replace('{class}', 'alert-success');
    } else if (statusMessageType == "information") {
        htmlalert = htmlalert.replace('{titulo}', "Informação!");
        htmlalert = htmlalert.replace('{class}', 'alert-info');
    } else if (statusMessageType == "warning") {
        htmlalert = htmlalert.replace('{titulo}', "Alerta!");
        htmlalert = htmlalert.replace('{class}', 'alert-warning');
    }

    $('#divAlert').html(htmlalert)

    statusMessage = '';
    statusMessageType = '';
}

function OpenBlock() {
    $.blockUI({ message: '<h4><img style="width: 22px;margin-top: -3px;" src="' + ajaxImg + '" /> Aguarde...</h4>' });
}
function CloseBlock() {
    $.unblockUI();
}

$(function () {
    $('#sidebar-nav').on('show.bs.tooltip', 'a', function (e) {
        if ($(e.currentTarget).find('span:visible').length) {
            e.preventDefault();
            return false;
        }
    });

});

var fancyFilter = function (filterListSelector, gallerySelector) {
    //Filter Button Code
    $(filterListSelector + ' a').click(function () {
        $(filterListSelector + ' li').removeClass('active');
        var $this = $(this);
        var filterType = $this.data('filter');
        if (!filterType) return true;

        $this.closest('li').addClass('active');
        $(gallerySelector).isotope({
            filter: filterType,
        });

        return false;
    });
};

var Notificacao = {

    ExibirMensagem: function (mensagem, tipo, onclosecallback) {
        var n = noty({
            text: mensagem,
            type: tipo,
            dismissQueue: true,
            modal: true,
            layout: 'center',
            timeout: false,
            theme: 'bootstrap',
            closeWith: ['click'],
            callback: {
                afterClose: function () {
                    if (onclosecallback != null) { onclosecallback(); }
                }
            }
        });

        setTimeout(function () { n.close(); }, 2000);
    },

    Mensagem: {
        Info: function (mensagem, onclose) {
            Notificacao.ExibirMensagem(mensagem, 'warning', onclose);
        },
        Erro: function (mensagem, onclose) {
            Notificacao.ExibirMensagem(mensagem, 'error', onclose);
        },
        Sucesso: function (mensagem, onclose) {
            Notificacao.ExibirMensagem(mensagem, 'success', onclose);
        }
    }

}

