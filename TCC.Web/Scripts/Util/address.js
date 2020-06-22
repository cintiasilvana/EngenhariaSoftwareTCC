function getAddress(cep) {
    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/",
        function (result) {
            $("#logradouro").val(result.logradouro);
            $("#complemento").val(result.complemento);
            $("#bairro").val(result.bairro);

            selectCidade(result.localidade);
        });
}

function selectCidade(text1) {
    $("#idCidade option").filter(function () {
        return this.text.toUpperCase() === text1.toUpperCase();
    }).attr('selected', true);

    $("#idCidade").change();
}

function fillAddress(id) {
    var pais = $(document).find("#pais");
    var estado = $(document).find("#estado");

    $.get(urlGetPaisEstado, { idCidade: id },
        function (data) {
            pais.val(data.Estado.Pais.Descricao);
            estado.val(data.Estado.Descricao);
        });

}