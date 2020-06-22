using System.Collections.Generic;
using System.Linq;
using TCC.Domain.Entities;
using TCC.Infra.Context;
using TCC.Infra.Repositories;

namespace TCC.Infra.ValueObject
{
    public class TreinamentoSemanaObject : RepositoryBase<TreinamentoSemana>
    {

        public TreinamentoSemanaObject(AcademiaContext context) : base(context)
        {
            Context = new AcademiaContext();
        }

        public TreinamentoSemanaObject()
        {
        }

        public List<int> GetByIdTreinamento(int idTreinamento)
        {
            var diaSemana = GetAll().Where(c => c.IdTreinamento == idTreinamento)
                .Select(c => (int)c.DiaSemana)
                .ToList();

            return diaSemana;
        }


        public void DeleteBy(int idTreinamento)
        {
            var dados = GetBy(c => c.IdTreinamento == idTreinamento).ToList();

            dados.ForEach(c =>
            {
                Context.TreinamentoSemanas.Remove(c);
            });


            Save();
        }
    }

    public class TreinamentoSemanaDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
