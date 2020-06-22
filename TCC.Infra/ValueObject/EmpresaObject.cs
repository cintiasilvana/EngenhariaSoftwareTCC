using System.Collections.Generic;
using System.Linq;
using System.Net;
using TCC.Application;
using TCC.Domain.Entities;
using TCC.Infra.Context;
using TCC.Infra.Repositories;

namespace TCC.Infra.ValueObject
{
    public class EmpresaObject : RepositoryBase<Empresa>
    {

        public EmpresaObject(AcademiaContext context) : base(context)
        {
            Context = new AcademiaContext();
        }

        public EmpresaObject()
        {
        }

        public List<EmpresaDto> GetCombo()
        {
            var dados = GetAll()
                .Select(c => new EmpresaDto
                {
                    Id = c.Id,
                    Descricao = c.NomeFantasia
                }).OrderBy(c => c.Descricao).ToList();

            return dados;
        }

        public bool UpdateEmpresa(Empresa empresaNew, Empresa empresaOld)
        {
            if (empresaOld == null)
            {
                return false;
            }

            empresaOld.IdCidade = empresaNew.IdCidade;

            empresaOld.RazaoSocial = empresaNew.RazaoSocial;
            empresaOld.NomeFantasia = empresaNew.NomeFantasia;
            empresaOld.InscricaoEstadual = empresaNew.InscricaoEstadual;

            empresaOld.Responsavel = empresaNew.Responsavel;
            empresaOld.Email = empresaNew.Email;
            empresaOld.PaginaWEB = empresaNew.PaginaWEB;
            empresaOld.TelefoneContato = empresaNew.TelefoneContato;
            empresaOld.Ramal = empresaNew.Ramal;
            empresaOld.TelefoneCelular = empresaNew.TelefoneCelular;

            empresaOld.Logradouro = empresaNew.Logradouro;
            empresaOld.Numero = empresaNew.Numero;
            empresaOld.Complemento = empresaNew.Complemento;
            empresaOld.Bairro = empresaNew.Bairro;
            empresaOld.CEP = empresaNew.CEP;

            Update(empresaOld);
            Save();
            return true;
        }

        public ResponseMessage<Empresa> InsertOrUpdate(Empresa empresa)
        {
            var response = new ResponseMessage<Empresa>();
            var dados = GetById(empresa.Id);
            if (dados == null)
            {
                try
                {
                    Add(empresa);

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
                UpdateEmpresa(empresa, dados);
            }

            Save();

            return response;
        }
    }

    public class EmpresaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
