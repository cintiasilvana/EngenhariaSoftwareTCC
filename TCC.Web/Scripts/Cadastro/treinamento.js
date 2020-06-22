var dataSemana;

$(function () {
    getComboEmpresa();
    getCombo();
});

$(document).on("click", "#btnSalvar", function () {
    var treinamentoForm = $(document).find('#treinamentoForm');

    if (treinamentoForm.valid() && validInputsTabs()) {
        salvar(treinamentoForm, urlCreateTreinamento).complete(function () {
            list(urlTableTreinamento);
        });
    } else {
        messageAlert(validation, error);
    }
});

$(document).on("click", "#confirma", function () {
    deletar(urlDeleteTreinamento).complete(function () {
        list(urlTableTreinamento);
    });
});

$(document).on("click", "#btnNovo", function () {
    desbloqFields();
    clearFields();
});






function editar(id, urlGet) {
    var idTreinamento = $(document).find("#Id");
    var idColaborador = $(document).find("#idColaborador");
    var idEmpresa = $(document).find("#idEmpresa");
    var descricao = $(document).find("#descricao");
    var local = $(document).find("#local");
    var periodoInicial = $(document).find("#periodoInicial");
    var periodoFinal = $(document).find("#periodoFinal");
    var diaSemana = $(document).find("#diaSemana");

    desbloqFields();

    return $.get(urlGet, { id: id }, function (data) {
        idTreinamento.val(data.treinamento.Id);
        idColaborador.val(data.treinamento.IdColaborador).trigger("change");
        idEmpresa.val(data.treinamento.IdEmpresa).trigger("change");

        $("#diaSemana").multiselect("destroy");

        preencheMultiselect(dataSemana, $("#diaSemana"));

        $("#diaSemana").multiselect("select", data.semana);

        periodoInicial.timepicker('setTime', moment(data.treinamento.PeriodoInicial).toDate());
        periodoFinal.timepicker('setTime', moment(data.treinamento.PeriodoFinal).toDate());

        descricao.val(data.treinamento.Descricao);
        local.val(data.treinamento.Local);

    }).fail(function (e) {
        if (e.status === 403) {
            messageAlert(visualizarPermicaoAcesso, error);
        }
    });

}


function getCombo() {
    return $.get(urlGetComboTreinamento, function (data) {
        preencheCombo(data.colaborador, "Selecione o Colaborador", $("#idColaborador"));
        preencheMultiselect(data.semana, $("#diaSemana"));

        dataSemana = data.semana;
    }).fail(function (e) {
        messageAlert(e.Mensagem, error);
    });
}

function visualiza(id, urlGet) {
    editar(id, urlGet).complete(function () {
        $("#idEmpresa").select2({ disabled: true });
        $("#idColaborador").select2({ disabled: true });

        $(".widget-content input:not(#search-table)").attr("disabled", "disabled");

        $("#btnSalvar").hide();
        $("#btnNovo").show();
    });
}

function desbloqFields() {
    $(".widget-content input").removeAttr("disabled");
    $("#idEmpresa").select2({ disabled: false });
    $("#idColaborador").select2({ disabled: false });

    $("#btnNovo").show();
    $("#btnSalvar").show();
}

function clearFields() {
    var inputs = $("#treinamentoForm").find("input");
    var select = $("#treinamentoForm").find("select");

    $.each(inputs, function (i, item) {
        $(item).val("").trigger("blur");
    });

    $.each(select, function (i, item) {
        $(item).val("").trigger("change");
    });

    $("#btnNovo").hide();

    $("#Id").val("");
}
