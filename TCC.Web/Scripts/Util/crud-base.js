var jqxhr;
var ID = "";
var IdUsuario;
var dataValue = [];
var dataComboEmpresa = [];


function getComboColaborador(idEmpresa) {
    var jsonKey = { idEmpresa: idEmpresa };

    if (idEmpresa !== "") {
        return $.get(urlGetComboColaboradorEmpresa,
            jsonKey,
            function (data) {
                preencheComboNome(data.colaboradores, $("#idColaborador"));
            }).fail(function (data) {
                if (data.status === 403) {
                    messageAlert(visualizarPermicaoAcesso, error);
                }
            });
    } else {
        messageAlert("Selecione a Empresa para carregar os Colaboradores", info);
    }

    return $.get();
}

function getComboEmpresa() {
    var idEmpresa = $("#idEmpresa");

    return $.get(urlGetComboEmpresa, function (data) {
        preencheCombo(data,"Selecione a Empresa", idEmpresa);
    }).fail(function (e) {
        messageAlert(e.Mensagem, error);
    });
}

//Manipulação basica de crud
function salvar(form, urlCreate) {
    var objeto = $(form).serialize();
    return $.post(urlCreate, objeto, function (data) {
        if (data.statusCode === 400) {
            messageAlert(data.mensagem, error);
        } else {
            messageAlert(data.mensagem, success);
            dataValue = data;
        }
    }).fail(function (data) {
        if (data.status === 403) {
            messageAlert(salvarPermicaoAcesso, error);
        }
    });

}

function salvarObj(urlCreate, obj) {
    removeMaskPhone();

    var objeto = obj;

    return $.post(urlCreate, objeto, function (data) {

        if (data.statusCode === 400) {
            messageAlert(data.mensagem, error);
        } else {
            dataValue = data;
            messageAlert(data.mensagem, success);
        }
    }).fail(function (e) {
        if (e.status === 403) {
            messageAlert(salvarPermicaoAcesso, error);
        }
    });
}

function save(url, jsonKey) {
    return $.post(url, jsonKey, function (data) {
        if (data.statusCode === 400) {
            messageAlert(data.mensagem, error);
        } else {
            if (data.mensagem !== null)
                messageAlert(data.mensagem, success);
            dataValue = data;
        }
    });
}

function deletar(urlDelete) {
    var objeto = { id: ID };
    return $.post(urlDelete, objeto, function (data) {
        if (data.statusCode === 400) {
            messageAlert(data.mensagem, error);
        } else {
            messageAlert(data.mensagem, success);
        }
    }).fail(function (data) {
        if (data.status === 403) {
            messageAlert(deletarPermicaoAcesso, error);
        }
    });
}

function deletarById(id, urlDelete) {
    var objeto = { id: id };
    return $.post(urlDelete, objeto, function (data) {
        if (data.statusCode === 400) {
            messageAlert(data.mensagem, error);
        } else {
            messageAlert(data.mensagem, success);
        }
    }).fail(function (data) {
        if (data.status === 403) {
            messageAlert(deletarPermicaoAcesso, error);
        }
    });
}

function deleteWithUser(urlDelete) {
    var objeto = { id: ID, idUsuario: IdUsuario };
    return $.post(urlDelete, objeto, function (data) {
        if (data.statusCode === 400) {
            messageAlert(data.mensagem, error);
        } else {
            messageAlert(data.mensagem, success);
        }
    }).fail(function (data) {
        if (data.status === 403) {
            messageAlert(deletarPermicaoAcesso, error);
        }
    });
}

function list(urlTable) {
    return $.get(urlTable, function (data) {
        $("#panel").html(data);
        $('[data-toggle="tooltip"]').tooltip({
            trigger: 'hover'
        });
    }).fail(function (data) {
        if (data.status === 403) {
            messageAlert(visualizarPermicaoAcesso, error);
        }
    });
}

function listBy(urlTable, jsonkey, selector) {
    return $.get(urlTable, jsonkey, function (data) {
        $(selector).html(data).focus();
        $('[data-toggle="tooltip"]').tooltip({
            trigger: 'hover'
        });
    }).fail(function (data) {
        if (data.status === 403) {
            messageAlert(visualizarPermicaoAcesso, error);
        }
    });
}

function form(urlForm) {
    return $.get(urlForm, function (data) {
        $("#panel").html(data);
    }).fail(function (e) {
        messageAlert(e, error);
    });
}

//Manipulação Arquivos
function getExistFile(idArquivo, form, url) {
    if (idArquivo > 0) {
        return $.get(url, { idArquivo: idArquivo }, function (data) {
            if (!jQuery.isEmptyObject(data.value)) {
                var embedLink = "<embed width='100%' height='100%' src='" + data.value.link + "' type='" + data.value.contentType + "'>";

                form.emit("addedfile", data.value);
                form.emit("complete", data.value);

                $(form.element).find(".dz-preview.dz-file-preview")
                    .append("<a class=\"btn btn-xs bg-blue btn-block\"  target=\"_blank\"  href=\'" + data.value.link + "\'>Visualizar</a>");
                $(form.element).find(".dz-filename").html(embedLink);
            }
        }).fail(function (data) {
            if (data.status === 403) {
                messageAlert(visualizarPermicaoAcesso, error);
            }
        });
    }
}

function deleteExistFile(idTipo, url) {
    return $.post(url, { id: idTipo }, function (data) {
        if (data.statusCode === 400) {
            messageAlert(data.mensagem, error);
        } else {
            messageAlert(data.mensagem, success);
        }
    }).fail(function (data) {
        if (data.status === 403) {
            messageAlert(deletarPermicaoAcesso, error);
        }
    });
}

//Combos metodos
function preencheCombo(data, text, objectHtml) {
    objectHtml.html("<option value=''>" + text + "</option>");
    $.each(data, function (i, item) {
        objectHtml.append("<option value='" + item.Id + "'>" + item.Descricao + "</option>");
    });

    objectHtml.select2({ width: '100%' });

}

function preencheMultiselect(data, objectHtml) {
    objectHtml.html("");

    $.each(data, function (i, item) {
        objectHtml.append("<option value='" + item.Id + "'>" + item.Descricao + "</option>");
    });

    objectHtml.hide();
    objectHtml.multiselect({
        includeSelectAllOption: true,
        enableFiltering: true,
        numberDisplayed: 4,
        filterPlaceholder: 'Pesquisar',
        nSelectedText: 'Selecionado',
        nonSelectedText: 'Selecione',
        selectAllText: 'Todos',
        selectAllName: 'Todos',
        allSelectedText: 'Todos',
        setAllSelectedText: 'Todos',
        buttonWidth: '100%',
        buttonClass: 'form-control',
        inheritClass: true,
        maxHeight: 400
    });

    objectHtml.multiselect('rebuild');
}

