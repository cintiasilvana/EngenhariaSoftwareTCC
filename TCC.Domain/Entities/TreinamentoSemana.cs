using TCC.Domain.Objects;

namespace TCC.Domain.Entities
{
    public class TreinamentoSemana : BaseEntity
    {
        //CAMPOS  
        public eDiaSemana DiaSemana { get; set; }
        public int IdTreinamento { get; set; }

        public virtual Treinamento Treinamento { get; set; }

    }
}
