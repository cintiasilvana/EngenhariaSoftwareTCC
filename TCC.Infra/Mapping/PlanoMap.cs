using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class PlanoMap : BaseMap<Plano>
    {
        public PlanoMap()
        {
            this.ToTable("PLANO", "TCC");
                        
            this.Property(x => x.IdEmpresa).HasColumnName("ID_EMPRESA");
            this.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(255).IsRequired();
            this.Property(x => x.Valor).HasColumnName("VALOR").IsRequired();

            this.HasRequired(x => x.Empresa).WithMany(x => x.Plano).HasForeignKey(x => x.IdEmpresa);
        }
    }
}
