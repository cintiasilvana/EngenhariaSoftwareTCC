
$(function () {
    getComboEmpresa();
    getCombo();
});

$(document).on("click", "#btnSalvar", function () {
    var colaboradorForm = $(document).find('#colaboradorForm');

    if (colaboradorForm.valid() && validInputsTabs()) {
        salvar(colaboradorForm, urlCreateColaborador).complete(function () {
            list(urlTableColaborador);
            $("#btnNovo").show();
        });
    } else {
        messageAlert(validation, error);
    }
});


$(document).on("click", "#confirma", function () {
    deletar(urlDeleteColaborador).complete(function () {
        list(urlTableColaborador);
    });
});

$(document).on("click", "#btnNovo", function () {
    desbloqFields();
    clearFields();
});


function editar(id, urlGet) {
    var idColaborador = $(document).find("#Id");
    var idEmpresa = $(document).find("#idEmpresa");
    var idAtividade = $(document).find("#idAtividade");
    var idPerfil = $(document).find("#idPerfil");
    var nome = $(document).find("#nome");
    var cpf = $(document).find("#cpf");    
    var email = $(document).find("#email");   

    desbloqFields();

    return $.get(urlGet, { id: id }, function (data) {
        idColaborador.val(data.Id);
        idEmpresa.val(data.IdEmpresa).trigger("change");
        idAtividade.val(data.IdAtividade).trigger("change");
        idPerfil.val(data.IdPerfil).trigger("change");

        cpf.val(data.Cpf);
        cpf.attr('readonly', true);

        nome.val(data.Nome);     
        email.val(data.Email);      
    }).fail(function (e) {
        if (e.status === 403) {
            messageAlert(visualizarPermicaoAcesso, error);
        }
    });

}



function getCombo() {
    var idAtividade = $("#idAtividade");
    var idPerfil = $("#idPerfil");

    return $.get(urlGetCombosColaborador, function (data) {
        preencheCombo(data.atividade, "Selecione a Atividade", idAtividade);
        preencheCombo(data.perfil, "Selecione o Perfil",  idPerfil);
    }).fail(function (e) {
        messageAlert(e.Mensagem, error);
    });
}

function visualiza(id, urlGet) {
    editar(id, urlGet).complete(function () {
        $("#idAtividade").select2({ disabled: true });
        $("#idEmpresa").select2({ disabled: true });
        $("#idPerfil").select2({ disabled: true });

        $(".widget-content input:not(#search-table)").attr("disabled", "disabled");

        $("#btnSalvar").hide();
        $("#btnNovo").show();
    });
}

function desbloqFields() {
    $(".widget-content input").removeAttr("disabled");
    $("#idEmpresa").select2({ disabled: false });
    $("#idPerfil").select2({ disabled: false });

    $("#btnNovo").show();
    $("#btnSalvar").show();
}

function clearFields() {
    var inputs = $("#colaboradorForm").find("input");
    var select = $("#colaboradorForm").find("select");

    $.each(inputs, function (i, item) {
        $(item).val("").trigger("blur");
    });

    $.each(select, function (i, item) {
        $(item).val("").trigger("change");
    });

    $("#btnNovo").hide();

    $("#Id").val("");
}
