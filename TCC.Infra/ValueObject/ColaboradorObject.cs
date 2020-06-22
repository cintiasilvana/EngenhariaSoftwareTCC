using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TCC.Application;
using TCC.Domain.Entities;
using TCC.Domain.Identity;
using TCC.Domain.Objects;
using TCC.Infra.Context;
using TCC.Infra.Repositories;

namespace TCC.Infra.ValueObject
{
    public class ColaboradorObject : RepositoryBase<Instrutor>
    {

        public ColaboradorObject(AcademiaContext context) : base(context)
        {
            Context = new AcademiaContext();
        }

        public ColaboradorObject()
        {
        }

        public List<ColaboradorDto> GetCombo()
        {
            var dados = GetAll()
                .Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Descricao = c.Nome
                }).OrderBy(c => c.Descricao).ToList();

            return dados;
        }

        public bool UpdateColaborador(Instrutor clienteNew, Instrutor clienteOld)
        {
            if (clienteOld == null)
            {
                return false;
            }

            clienteOld.IdPerfil = clienteNew.IdPerfil;
            clienteOld.IdAtividade = clienteNew.IdAtividade;
            clienteOld.IdEmpresa = clienteNew.IdEmpresa;
            clienteOld.Cpf = clienteNew.Cpf;
            clienteOld.Nome = clienteNew.Nome;
            clienteOld.Email = clienteNew.Email;

            Update(clienteOld);
            Save();
            return true;
        }

        public ResponseMessage<Instrutor> InsertOrUpdate(Instrutor colaborador)
        {
            var response = new ResponseMessage<Instrutor>();
            var dados = GetById(colaborador.Id);
            if (dados == null)
            {
                try
                {
                    colaborador.Usuario = new ApplicationUser
                    {
                        PasswordHash = EnumHelper.HashPassword("Tcc12345"),
                        Email = colaborador.Email,
                        UserName = colaborador.Email,
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    Add(colaborador);

                    response.statusCode = HttpStatusCode.OK;
                    response.mensagem = _crudMsgFormater.CreateSuccesCrudMessage();
                }
                catch
                {
                    response.statusCode = HttpStatusCode.BadRequest;
                    response.mensagem = _crudMsgFormater.CreateErrorCrudMessage();
                }
            }
            else
            {
                UpdateColaborador(colaborador, dados);
            }

            Save();

            return response;
        }

        public List<ColaboradorRptDto> GetColaboradorRptDto()
        {
            var dados = GetAll()
                .Select(c => new ColaboradorRptDto
                {
                    Id = c.Id,
                    IdEmpresa = c.IdEmpresa,
                    IdAtividade = c.IdAtividade,
                    NomeAtividade = "",
                    IdPerfil = c.IdPerfil,
                    IdUsuarioLogin = c.IdUsuarioLogin,
                    Nome = c.Nome,
                    Cpf = c.Cpf,
                    Email = c.Email,
                    DataRegistro = c.DataRegistro
                }).ToList();

            var customDados = dados
                .Select(c => new ColaboradorRptDto
                {
                    Id = c.Id,
                    IdEmpresa = c.IdEmpresa,
                    IdAtividade = c.IdAtividade,
                    NomeAtividade = BuscaAtividade(c.IdAtividade),
                    IdPerfil = c.IdPerfil,
                    IdUsuarioLogin = c.IdUsuarioLogin,
                    Nome = c.Nome,
                    Cpf = c.Cpf,
                    Email = c.Email,
                    DataRegistro = c.DataRegistro
                }).ToList();

            return customDados;
        }

        private string BuscaAtividade(int idAtividade)
        {
            if (idAtividade == Convert.ToInt32(eTipoAtividade.Musculacao))
                return EnumHelper.GetEnumDescription(eTipoAtividade.Musculacao);
            else if (idAtividade == Convert.ToInt32(eTipoAtividade.AulaGrupo))
                return EnumHelper.GetEnumDescription(eTipoAtividade.AulaGrupo);
            else
                return string.Empty;
        }
    }

    public class ColaboradorDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }

    public class ColaboradorRptDto
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdAtividade { get; set; }
        public string NomeAtividade { get; set; }
        public int? IdPerfil { get; set; }
        public int IdUsuarioLogin { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime? DataRegistro { get; set; }
    }


}
