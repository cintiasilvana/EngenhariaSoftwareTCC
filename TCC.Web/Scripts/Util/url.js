//Base


var baseUrl = window.location.host.indexOf("localhost") > -1 ? "" : "";

var urlGetComboCidade = baseUrl + "/Base/GetComboCidade";
var urlGetPaisEstado = baseUrl + "/Base/GetPaisEstadoById";
//var urlValidaCnpj = baseUrl + "/Base/ValidaCnpj";
var urlGetComboEmpresa = baseUrl + "/Base/GetComboEmpresa";


//Cliente
var urlGetCliente = baseUrl + "/Cliente/Get";
var urlCreateCliente = baseUrl + "/Cliente/Create";
var urlTableCliente = baseUrl + "/Cliente/Table";
var urlTableFiltroCliente = baseUrl + "/Cliente/TableFiltro";
var urlDeleteCliente = baseUrl + "/Cliente/Delete";
var urlGetCombosCliente = baseUrl + "/Cliente/GetCombos";


//Colaborador
var urlGetColaborador = baseUrl + "/Colaborador/Get";
var urlCreateColaborador = baseUrl + "/Colaborador/Create";
var urlTableColaborador = baseUrl + "/Colaborador/Table";
var urlTableFiltroColaborador = baseUrl + "/Colaborador/TableFiltro";
var urlDeleteColaborador = baseUrl + "/Colaborador/Delete";
var urlGetCombosColaborador = baseUrl + "/Colaborador/GetCombo";


//Treinamento
var urlGetTreinamento = baseUrl + "/Treinamento/Get";
var urlCreateTreinamento = baseUrl + "/Treinamento/Create";
var urlTableTreinamento = baseUrl + "/Treinamento/Table";
var urlTableFiltroTreinamento = baseUrl + "/Treinamento/TableFiltro";
var urlDeleteTreinamento = baseUrl + "/Treinamento/Delete";
var urlGetComboTreinamento = baseUrl + "/Treinamento/GetCombo";


//Empresa
var urlGetEmpresa = baseUrl + "/Empresa/Get";
var urlCreateEmpresa = baseUrl + "/Empresa/Create";
var urlTableEmpresa = baseUrl + "/Empresa/Table";
var urlDeleteEmpresa = baseUrl + "/Empresa/Delete";

