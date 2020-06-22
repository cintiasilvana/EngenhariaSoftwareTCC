using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class PresencaMap : BaseMap<Presenca>
    {
        public PresencaMap()
        {
            this.ToTable("PRESENCA", "TCC");

            this.Property(x => x.IdMatricula).HasColumnName("ID_MATRICULA").IsRequired();
            this.Property(x => x.IdTreinamento).HasColumnName("ID_TREINAMENTO").IsRequired();
            this.Property(x => x.DataPresenca).HasColumnName("DATA_PRESENCA").IsRequired();

            this.HasRequired(x => x.Matricula).WithMany(x => x.Presenca).HasForeignKey(x => x.IdMatricula);
            this.HasRequired(x => x.Treinamento).WithMany(x => x.Presenca).HasForeignKey(x => x.IdTreinamento);
        }
    }
}
