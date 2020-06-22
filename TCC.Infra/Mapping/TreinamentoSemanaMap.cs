using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class TreinamentoSemanaMap : BaseMap<TreinamentoSemana>
    {
        public TreinamentoSemanaMap()
        {
            ToTable("TREINAMENTO_SEMANA", "TCC");

            Property(x => x.DiaSemana).HasColumnName("DIA_SEMANA");
            Property(x => x.IdTreinamento).HasColumnName("ID_TREINAMENTO");

            HasRequired(x => x.Treinamento).WithMany(c=> c.TreinamentoSemana).HasForeignKey(x => x.IdTreinamento);
        }
    }
}
