using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class FeriasMap : BaseMap<Ferias>
    {
        public FeriasMap()
        {
            this.ToTable("FERIAS", "TCC");

            this.Property(x => x.IdMatricula).HasColumnName("ID_MATRICULA");
            this.Property(x => x.DataInicial).HasColumnName("DATA_INICIAL").IsOptional();
            this.Property(x => x.DataFinal).HasColumnName("DATA_FINAL").IsOptional();

            this.HasRequired(x => x.Matricula).WithMany(x => x.Ferias).HasForeignKey(x => x.IdMatricula);
        }
    }
}
