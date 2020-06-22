using System.Collections.Generic;
using System.Linq;
using System.Net;
using TCC.Application;
using TCC.Domain.Entities;
using TCC.Infra.Context;
using TCC.Infra.Repositories;

namespace TCC.Infra.ValueObject
{
    public class ClienteObject : RepositoryBase<Aluno>
    {

        public ClienteObject(AcademiaContext context) : base(context)
        {
            Context = new AcademiaContext();
        }

        public ClienteObject()
        {
        }

        public List<ClienteDto> GetCombo()
        {
            var dados = GetAll()
                .Select(c => new ClienteDto
                {
                    Id = c.Id,
                    Descricao = c.Nome
                }).OrderBy(c => c.Descricao).ToList();

            return dados;
        }

        public bool UpdateCliente(Aluno clienteNew, Aluno clienteOld)
        {
            if (clienteOld == null)
            {
                return false;
            }

            clienteOld.IdCidade = clienteNew.IdCidade;
            clienteOld.IdEmpresa = clienteNew.IdEmpresa;
            clienteOld.Nome = clienteNew.Nome;
            clienteOld.Email = clienteNew.Email;
            clienteOld.TelefoneContato = clienteNew.TelefoneContato;
            clienteOld.Ramal = clienteNew.Ramal;
            clienteOld.Cpf = clienteNew.Cpf;
            clienteOld.Identidade = clienteNew.Identidade;
            clienteOld.TelefoneCelular = clienteNew.TelefoneCelular;
            clienteOld.Logradouro = clienteNew.Logradouro;
            clienteOld.Numero = clienteNew.Numero;
            clienteOld.Complemento = clienteNew.Complemento;
            clienteOld.Bairro = clienteNew.Bairro;
            clienteOld.CEP = clienteNew.CEP;

            Update(clienteOld);
            Save();
            return true;
        }

        public ResponseMessage<Aluno> InsertOrUpdate(Aluno cliente)
        {
            var response = new ResponseMessage<Aluno>();
            var dados = GetById(cliente.Id);
            if (dados == null)
            {
                try
                {
                    Add(cliente);

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
                UpdateCliente(cliente, dados);
            }

            Save();

            return response;
        }
    }

    public class ClienteDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
