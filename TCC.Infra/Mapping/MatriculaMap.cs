using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class MatriculaMap : BaseMap<Matricula>
    {
        public MatriculaMap()
        {
            this.ToTable("MATRICULA", "TCC");

            this.Property(x => x.IdCliente).HasColumnName("ID_CLIENTE");
            this.Property(x => x.IdPlano).HasColumnName("ID_PLANO");

            this.Property(x => x.DataInicio).HasColumnName("DATA_INICIO").IsRequired();
            this.Property(x => x.DataTermino).HasColumnName("DATA_TERMINO").IsOptional();

            this.HasRequired(x => x.Cliente).WithMany(x => x.Matricula).HasForeignKey(x => x.IdCliente);
            this.HasRequired(x => x.Plano).WithMany(x => x.Matricula).HasForeignKey(x => x.IdPlano);
        }
    }
}
