
$(function () {
    getCombos();
});

$(document).on("click", "#btnSalvar", function () {
    var empresaForm = $(document).find('#empresaForm');

    if (empresaForm.valid() && validInputsTabs()) {
        salvar(empresaForm, urlCreateEmpresa).complete(function () {
            list(urlTableEmpresa);
            $("#btnNovo").show();
        });
    } else {
        messageAlert(validation, error);
    }
});

$(document).on("blur", "#cnpj", function () {
    validateCnpj();
});

$(document).on("click", "#confirma", function () {
    deletar(urlDeleteEmpresa).complete(function () {
        list(urlTableEmpresa);
    });
});

$(document).on("click", "#btnNovo", function () {
    desbloqFields();
    clearFields();
});


function validateCnpj() {
    var cnpj = $("#cnpj").val();

    if (cnpj === "")
        return;

    if ($('#cnpj').attr('readonly') === "readonly")
        return;

    if (!validarCNPJ(cnpj)) {
        messageAlert("CNPJ: " + cnpj + " Inválido", error);
        $("#cnpj").val("");
        return;
    }
}

function editar(id, urlGet) {
    var idEmpresa = $(document).find("#Id");
    var razaoSocial = $(document).find("#razaoSocial");
    var cnpj = $(document).find("#cnpj");
    var inscricaoEstadual = $(document).find("#inscricaoEstadual");
    var nomeFantasia = $(document).find("#nomeFantasia");
    var responsavel = $(document).find("#responsavel");
    var email = $(document).find("#email");
    var paginaWeb = $(document).find("#paginaWeb");
    var telefoneContato = $(document).find("#telefoneContato");
    var ramal = $(document).find("#ramal");
    var telefoneCelular = $(document).find("#telefoneCelular");
    var cep = $(document).find("#cep");
    var logradouro = $(document).find("#logradouro");
    var numero = $(document).find("#numero");
    var complemento = $(document).find("#complemento");
    var bairro = $(document).find("#bairro");
    var cidade = $(document).find("#idCidade");
    var pais = $(document).find("#pais");
    var estado = $(document).find("#estado");

    $("#Id").val(id);

    desbloqFields();

    return $.get(urlGet, { id: id }, function (data) {
        idEmpresa.val(data.Id);
        razaoSocial.val(data.RazaoSocial);
        cnpj.val(data.CNPJ);
        cnpj.attr('readonly', true);

        inscricaoEstadual.val(data.InscricaoEstadual);
        nomeFantasia.val(data.NomeFantasia);
        responsavel.val(data.Responsavel);

        email.val(data.Email);
        paginaWeb.val(data.PaginaWEB);
        telefoneContato.val(data.TelefoneContato).trigger("blur");
        ramal.val(data.Ramal);

        telefoneCelular.val(data.TelefoneCelular).trigger("blur");
        cep.val(data.CEP);
        logradouro.val(data.Logradouro);
        numero.val(data.Numero);
        complemento.val(data.Complemento);
        bairro.val(data.Bairro);

        pais.val(data.Pais);
        estado.val(data.Estado);
        cidade.val(data.IdCidade).trigger("change");
    }).fail(function (e) {
        if (e.status === 403) {
            messageAlert(visualizarPermicaoAcesso, error);
        }
    });

}

function getCombos() {
    var idCidade = $("#idCidade");

    return $.get(urlGetComboCidade, function (data) {
        preencheCombo(data, "Selecione a Cidade", idCidade);
    }).fail(function (e) {
        messageAlert(e.Mensagem, error);
    });
}

function visualiza(id, urlGet) {
    editar(id, urlGet).complete(function () {
        $("#idCidade").select2({ disabled: true });

        $(".widget-content input:not(#search-table)").attr("disabled", "disabled");

        $("#btnSalvar").hide();
        $("#btnNovo").show();
    });
}

function desbloqFields() {
    $(".widget-content input").removeAttr("disabled");
    $("#idCidade").select2({ disabled: false });

    $("#btnNovo").show();
    $("#btnSalvar").show();
}

function clearFields() {
    var inputs = $("#empresaForm").find("input");
    var select = $("#empresaForm").find("select");

    $.each(inputs, function (i, item) {
        $(item).val("").trigger("blur");
    });

    $.each(select, function (i, item) {
        $(item).val("").trigger("change");
    });

    $("#btnNovo").hide();

    $("#Id").val("");
}
