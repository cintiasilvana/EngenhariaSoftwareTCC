using TCC.Domain.Entities;
using TCC.Infra.Context;
using TCC.Infra.Repositories;

namespace TCC.Infra.ValueObject
{
    public class LogOperacaoObject : RepositoryBase<LogOperacao>
    {

        public LogOperacaoObject(AcademiaContext context) : base(context)
        {
            Context = new AcademiaContext();
        }

        public LogOperacaoObject()
        {
        }  

       
    }

    public class LogOperacaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
