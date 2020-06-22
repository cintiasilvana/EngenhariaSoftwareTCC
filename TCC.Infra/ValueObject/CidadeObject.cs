using System.Collections.Generic;
using System.Linq;
using System.Net;
using TCC.Application;
using TCC.Domain.Entities;
using TCC.Infra.Context;
using TCC.Infra.Repositories;

namespace TCC.Infra.ValueObject
{
    public class CidadeObject : RepositoryBase<Cidade>
    {

        public CidadeObject(AcademiaContext context) : base(context)
        {
            Context = new AcademiaContext();
        }

        public CidadeObject()
        {
        }

        public List<CidadeDto> GetCombo()
        {
            var dados = GetAll()
                .Select(c => new CidadeDto
                {
                    Id = c.Id,
                    Descricao = c.Descricao
                }).OrderBy(c => c.Descricao).ToList();

            return dados;
        }      

       
    }

    public class CidadeDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
