using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class EstadoMap : BaseMap<Estado>
    {
        public EstadoMap()
        {
            this.ToTable("ESTADO", "TCC");
            
            this.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(255).IsRequired();
            this.Property(x => x.IdPais).HasColumnName("ID_PAIS").IsRequired();
            this.HasRequired(x => x.Pais).WithMany(x => x.Estado).HasForeignKey(x => x.IdPais);
        }
    }
}
