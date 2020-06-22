
$(function () {
    getComboEmpresa();
    getComboCidade();
});

$(document).on("click", "#btnSalvar", function () {
    var clienteForm = $(document).find('#clienteForm');

    if (clienteForm.valid() && validInputsTabs()) {
        salvar(clienteForm, urlCreateCliente).complete(function () {
            list(urlTableCliente);
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
    deletar(urlDeleteCliente).complete(function () {
        list(urlTableCliente);
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
    var idCliente = $(document).find("#Id");
    var idEmpresa = $(document).find("#idEmpresa");
    var nome = $(document).find("#nome");
    var cpf = $(document).find("#cpf");
    var identidade = $(document).find("#identidade");
    var email = $(document).find("#email");
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

    desbloqFields();

    return $.get(urlGet, { id: id }, function (data) {
        idCliente.val(data.Id);
        idEmpresa.val(data.IdEmpresa).trigger("change");

        cpf.val(data.Cpf);
        cpf.attr('readonly', true);

        nome.val(data.Nome);
        identidade.val(data.Identidade);

        email.val(data.Email);
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

function getComboCidade() {
    var idCidade = $("#idCidade");

    return $.get(urlGetComboCidade, function (data) {
        preencheCombo(data,"Selecione a Cidade", idCidade);
    }).fail(function (e) {
        messageAlert(e.Mensagem, error);
    });
}

function visualiza(id, urlGet) {
    editar(id, urlGet).complete(function () {
        $("#idCidade").select2({ disabled: true });
        $("#idEmpresa").select2({ disabled: true });

        $(".widget-content input:not(#search-table)").attr("disabled", "disabled");

        $("#btnSalvar").hide();
        $("#btnNovo").show();
    });
}

function desbloqFields() {
    $(".widget-content input").removeAttr("disabled");
    $("#idCidade").select2({ disabled: false });
    $("#idEmpresa").select2({ disabled: false });

    $("#btnNovo").show();
    $("#btnSalvar").show();
}

function clearFields() {
    var inputs = $("#clienteForm").find("input");
    var select = $("#clienteForm").find("select");

    $.each(inputs, function (i, item) {
        $(item).val("").trigger("blur");
    });

    $.each(select, function (i, item) {
        $(item).val("").trigger("change");
    });

    $("#btnNovo").hide();

    $("#Id").val("");
}
