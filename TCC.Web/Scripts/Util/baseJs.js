(function ($) {
    $.fn.serializeFormJSON = function () {

        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };
})(jQuery);

$.urlParam = function (name) {
    var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
    if (results === null) {
        return null;
    }
    else {
        return decodeURI(results[1]) || 0;
    }
};


(function ($) {

    'use strict';

    // Initialize datatable with ability to add rows dynamically
    var initTableWithDynamicRows = function () {
        var tableCompany = $('#tableCompany');

        var table = tableCompany.DataTable({
          
            scrollCollapse: true,
            responsive: true,
            language: {
                url: "//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json"
            },
            destroy: true,
            iDisplayLength: 5,
            autoWidth: true,
            lengthChange: false
        });

        // search box for table
        $('#search-table').keyup(function () {
            table.search($(this).val()).draw();
        });
    };

    initTableWithDynamicRows();

    $('body').tooltip({
        selector: '[data-toggle="tooltip"], [data-toggle="modal"], [title]:not([data-toggle="popover"])',
        trigger: 'hover',
        container: 'body'
    }).on('click mousedown mouseup', '[data-toggle="tooltip"], [title]:not([data-toggle="popover"])', function () {
        $('[data-toggle="tooltip"], [title]:not([data-toggle="popover"]').tooltip('hide');
    });

})(window.jQuery);

function getDatePicker(id) {
    $(id).datepicker({
        autoclose: true,
        format: "dd/mm/yyyy",
        language: "pt-BR",        
        todayHighlight: true
    });
}

function getTimePicker() {
    $('.timepicker').timepicker({
        showSeconds: true,
        showMeridian: false,
        defaultTime: 'current'
    }).on('show.timepicker', function (e) {
        var widget = $('.bootstrap-timepicker-widget');
        widget.find('.glyphicon-chevron-up').removeClass().addClass('pg-arrow_maximize');
        widget.find('.glyphicon-chevron-down').removeClass().addClass('pg-arrow_minimize');
    });
}

function modalDocumento(codigo) {
    if (codigo === true) {
        $('#politica').hide();
        $('#codigoEtica').show();
    }
    else {
        $('#politica').show();
        $('#codigoEtica').hide();
    }

    $('#myModalPdf').modal('show');
}

function alterKey() {
    $.get("/Home/AlterPassword", function (data) {
        $("#content").html(data);
        $("#modalAlterkey").modal('show');
    });
}

function validaDatas(inicio, fim) {
    var inicial = $(inicio).datepicker("getDate");
    var final = $(fim).datepicker("getDate");

    if (inicial !== "Invalid Date" && final !== "Invalid Date") {
        if (inicial > final) {
            var dataFormatada = $(inicio).val();
            $(fim).val(dataFormatada);
        }
    }
}

function calcDateDiff(inicio, fim, duracao) {
    var inicial = $(inicio).datepicker("getDate");
    var final = $(fim).datepicker("getDate");
    var duracaoX = $(duracao);

    if (inicial !== "Invalid Date" && final !== "Invalid Date") {
        var dataInicioItem = moment(inicial);
        var dataTerminoItem = moment(final);
        var diffDate = dataTerminoItem.diff(dataInicioItem, 'days');

        duracaoX.val(diffDate <= 0 ? "0" : diffDate);
    } else
        duracaoX.val("0");
}

function validarCNPJ(cnpj) {

    if (cnpj === '') return false;

    var b = [6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2], c = cnpj;
    if ((c = c.replace(/[^\d]/g, "").split("")).length != 14)
        return false;
    for (var i = 0, n = 0; i < 12; n += c[i] * b[++i]);
    if (c[12] != (((n %= 11) < 2) ? 0 : 11 - n))
        return false;
    for (var i = 0, n = 0; i <= 12; n += c[i] * b[i++]);
    if (c[13] != (((n %= 11) < 2) ? 0 : 11 - n))
        return false;
    return true;
};

function validarCPF(cpf) {
    cpf = cpf.replace(/[^\d]+/g, '');
    if (cpf === '') return false;
    // Elimina CPFs invalidos conhecidos	
    if (cpf.length !== 11 ||
        cpf === "00000000000" ||
        cpf === "11111111111" ||
        cpf === "22222222222" ||
        cpf === "33333333333" ||
        cpf === "44444444444" ||
        cpf === "55555555555" ||
        cpf === "66666666666" ||
        cpf === "77777777777" ||
        cpf === "88888888888" ||
        cpf === "99999999999")
        return false;
    // Valida 1o digito	
    add = 0;
    for (i = 0; i < 9; i++)
        add += parseInt(cpf.charAt(i)) * (10 - i);
    rev = 11 - (add % 11);
    if (rev === 10 || rev === 11)
        rev = 0;
    if (rev !== parseInt(cpf.charAt(9)))
        return false;
    // Valida 2o digito	
    add = 0;
    for (i = 0; i < 10; i++)
        add += parseInt(cpf.charAt(i)) * (11 - i);
    rev = 11 - (add % 11);
    if (rev === 10 || rev === 11)
        rev = 0;
    if (rev !== parseInt(cpf.charAt(10)))
        return false;
    return true;
}

function removeMaskPhone() {
    var fixo = $("#telefoneContato");
    var celular = $("#telefoneCelular");

    if (fixo.val() !== undefined && celular.val() !== undefined) {
        var limpaFixo = fixo.val().replace(/\D/g, "");
        var limpaCelular = celular.val().replace(/\D/g, "");

        fixo.val(limpaFixo);
        celular.val(limpaCelular);
    }
}

function selectByText(select, text) {
    $(select).find('option:contains("' + text + '")').prop('selected', true);
}

function removeMask(value) {
    return value.replace(/\D/g, '');
}

function disableSortDataTable(tableId, column) {
    var oSettings = $(tableId).dataTable().fnSettings();

    $.each(column, function (i, item) {
        oSettings.aoColumns[item].bSortable = false;
    });
}

function sortColumnDataTable(id, index) {
    var table = $(id).DataTable();

    $.each(index, function (i, item) {
        table.order([item, 'asc']).draw();
    });
}

function retira_acentos(str) {
    com_acento = "ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖØÙÚÛÜÝŔÞßàáâãäåæçèéêëìíîïðñòóôõöøùúûüýþÿŕ";
    sem_acento = "AAAAAAACEEEEIIIIDNOOOOOOUUUUYRsBaaaaaaaceeeeiiiionoooooouuuuybyr";
    novastr = "";
    for (i = 0; i < str.length; i++) {
        troca = false;
        for (a = 0; a < com_acento.length; a++) {
            if (str.substr(i, 1) == com_acento.substr(a, 1)) {
                novastr += sem_acento.substr(a, 1);
                troca = true;
                break;
            }
        }
        if (troca === false) {
            novastr += str.substr(i, 1);
        }
    }
    return novastr;
}

function createMsgWarning(item) {
    var notify = $("#notify");
    notify.find(".notification-item").filter(function (i, obj) {
        var descricao = $(obj).find("span.fs-12.m-l-10").text();
        if (descricao.indexOf(item.descricao) > -1) {
            $(obj).remove();
        }
    });

    var read = "read('" + item.urlRead + "'," + item.id + "," + false + "," + 'this' + ")";
    var divNotification = item.boolRead ?
        '<div class="notification-item unread clearfix">' :
        '<div class="notification-item clearfix">';
    var divOption = item.boolRead ? '<div class="option" data-toggle="tooltip" title="lido">' :
        '<div class="option" data-toggle="tooltip" title="Não lido">';
    var clickRead = item.boolRead ? "" : read;
    var msgTemplate = divNotification +
        '<div class="heading">' +
        '<a href="' + item.path + "?id=" + item.id + "&lido=false" + '" class="text-warning-dark pull-left">' +
        '<i class="fa fa-exclamation-triangle m-r-10"></i>' +
        '<span class="bold">Atenção</span>' +
        '<span class="fs-12 m-l-10">' + item.descricao + '</span>' +
        '</a>' +
        '<span class="time pull-right">' + item.time + '</span>' +
        '</div>' +
        divOption +
        '<a href="#" class="mark" id="ready" onclick="' + clickRead + '"></a>' +
        '</div>' +
        '</div>';


    notify.append(msgTemplate);
}

function createMsgPanelAlert(item) {
    var panel = $("#panel-alert");
    var today = moment(item.data).format("DD/MM/YYYY");
    var msgTemplate = '<div class="alert alert-warning" role="alert">' +
        '<button class="close" data-dismiss="alert"></button>' +
        '<h4><i class="fa fa-exclamation-circle text-yellow"></i> ' + today + ' - ' + item.descricao + '</h4>' +
        item.msg +
        '</div>';

    panel.append(msgTemplate);
}

function read(url, id, lido, item) {
    if (url !== "#") {
        return $.post(url, { id: id, lido: lido }, function (data) {
            if (data.statusCode === 400) {
                messageAlert(data.mensagem, error);
            } else {
                $(item).parent().parent().remove();
                messageAlert(data.mensagem, success);
                dataValue = data;
            }
        });
    } else {
        $(item).parent().parent().remove();
        messageAlert("Operacação de teste realizada com sucesso", success);
    }

    createBubble();
}

function createBubble() {
    var itemBubble = $("#item-bubble");
    var notificationItem = $(".notification-item:not(.unread)");

    if (notificationItem.length > 0) {
        itemBubble.addClass("bubble");
        itemBubble.text(notificationItem.length);
    } else {
        itemBubble.text("");
        itemBubble.removeClass();
    }
}

function checkBol(id) {
    var bool = $(id);
    var isBool = bool.is(':checked');
    if (isBool) {
        bool.prop("checked", true);
        bool.val("true");
    } else {
        bool.prop("checked", false);
        bool.val("false");
    }

    return isBool;
}

function validInputsTabs() {
    var isValid = true;
    var $inputs = $(".tabs").closest("div").find("input");

    $inputs.each(function () {
        if (!$(this).valid()) {
            isValid = false;
            return false;
        }
        isValid = true;
    });

    return isValid;
}

var childTable = function (objHtml, event) {
    var link = $(event),
        icon = link.find('.icon'),
        tr = link.parent().parent(),
        table = link.parent().parent().parent().parent().DataTable(),
        row = table.row(tr);

    if (row.child.isShown()) {
        icon.removeClass('fa-minus-square').addClass('fa-plus-square');
        row.child.hide();
        tr.removeClass('shown');
    } else {
        icon.removeClass('fa-plus-square').addClass('fa-minus-square');
        row.child(objHtml).show();
        tr.addClass('shown');
    }
}

var childTableWithDynamicRows = function (table) {
    var tbl = table.DataTable({
        sDom: "<'exportOptions'T><'table-responsive't><'row'<p i>>",
        scrollCollapse: true,
        responsive: true,
        language: {
            url: "//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json"
        },
        destroy: true,
        iDisplayLength: 10,
        lengthChange: false
    });

    tbl.column(0).visible(false);
};

var tableWithObjectRows = function (table, object, columns) {
    var tbl = table.DataTable({
        sDom: "<'exportOptions'T><'table-responsive't><'row'<p i>>",
        scrollCollapse: true,
        destroy: true,
        data: object,
        columns: columns,
        responsive: true,
        language: {
            url: "//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json"
        },
        iDisplayLength: 5,
        lengthChange: false
    });

    return tbl;
};

function childTableAjax(event, jsonKey, url) {
    var link = $(event),
        icon = link.find('.icon'),
        tr = link.parent().parent(),
        table = link.parents().find("table").eq(0).DataTable({
            retrieve: true,
            searching: false,
            paging: false,
            info: false,
            ordering: false
        }),
        row = table.row(tr);

    if (!row.child.isShown()) {
        if (row.child() === undefined) {
            return $.post(url, jsonKey, function (data) {
                icon.removeClass('fa-plus-square').addClass('fa-minus-square');
                row.child(data).show();
                tr.addClass('shown');
            }).always(function () {
                var child = $(tr).next().find("[id^=tableChild]");
                childTableWithDynamicRows(child);
            }).fail(function (e) {
                messageAlert(error, e.Mensagem);
            });
        } else {
            icon.removeClass('fa-plus-square').addClass('fa-minus-square');
            row.child.show();
            tr.addClass('shown');
        }
    } else {
        icon.removeClass('fa-minus-square').addClass('fa-plus-square');
        row.child.hide();
        tr.removeClass('shown');
    }
}


function jQFormSerializeArrToJson(formSerializeArr) {
    var jsonObj = {};
    jQuery.map(formSerializeArr, function (n, i) {
        jsonObj[n.name] = n.value;
    });

    return jsonObj;
}

