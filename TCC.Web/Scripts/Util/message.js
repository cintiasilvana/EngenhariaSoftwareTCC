const success = "../assets/img/check.png";
const error = "../assets/img/error.png";
const info = "info";
const textSuccess = "Dados da Empresa Salvo.";
const textError = "Não foi possível salconst, tente novamente.";
const validation = "Existem campos obrigatórios não preenchidos";


const salvarPermicaoAcesso = "Desculpe, você não possui autorização para SALVAR nesta página. Por favor, verifique com o administrador.";
const formPermicaoAcesso = "Desculpe, você não possui autorização para ACESSAR o FORMULÁRIO nesta página. Por favor, verifique com o administrador.";
const deletarPermicaoAcesso = "Desculpe, você não possui autorização para DELETAR nesta página. Por favor, verifique com o administrador.";
const editarPermicaoAcesso = "Desculpe, você não possui autorização para SALVAR nesta página. Por favor, verifique com o administrador.";
const visualizarPermicaoAcesso = "Desculpe, você não possui autorização para VISUALIZAR nesta página. Por favor, verifique com o administrador.";
const aprovarPermicaoAcesso = "Desculpe, você não possui autorização para APROVAR e REJEITAR nesta página. Por favor, verifique com o administrador.";
const rejeitarPermicaoAcesso = "Desculpe, você não possui autorização para REJEITAR nesta página. Por favor, verifique com o administrador.";
const paraSalvarRestricoes = "Para SALVAR é necessário definir as restrições.";
const paraSalvarPeloMenosUm = "Para SALVAR é necessário definir pelo menos uma presença.";
const paraSalvarAvaliacao = "Para SALVAR é necessário realizar a avaliação de todas as perguntas.";
const paraVisualizarRestricoes = "É necessário selecionar um colaborador para visualizar as restrições.";
const desejaAlterarAsPermissoes = "Deseja realmente alterar as permissões?";
const confirmaPresenca = "Deseja confirmar a presença dos colaboradores selecionados?";
const confirmaAvaliacao = "Deseja confirmar a avaliação do Treinamento?";
const selecionePerfilParaVisualizar = "Selecione o perfil para visualizar os usuários do grupo.";
const emailJaExiste = "Não é permitido criar um colaborador com um email já existente.";
const emailDesativado = "Este e-mail encontra-se desativado em nossa base, deseja reativá-lo?";
const selecioneUmTreinamento = "Selecione um Treinamento Programado para criar a elaboração.";
const treinamentoRealizadoComSucesso = "Treinamento realizado com sucesso. Você será redirecionado para a Avaliação da Capacitação.";
const sucessoConfirmaAvaliacao = "Avaliação Realizada com Sucesso. Você será redirecionado para a Página inicial.";
const manterCheckboxMarcadoCeo = "É necessário manter o checkbox marcado para cadastrar o CEO da empresa.";

function messageAlert(message, type) {
    $.gritter.add({
        style: 'flip',
        text: message,
        image: type,
        time: 2000
    });
}

function modalAlert(title, text) {
    $("#modalAlert").modal("show");
    $("#title-content").text(title);
    $("#text-content").text(text);
}

function modalInfo(title, text) {
    $("#modalInfo").modal("show");
    $("#title-content-info").text(title);
    $("#text-content-info").text(text);
}

