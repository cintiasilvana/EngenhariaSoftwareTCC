using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class CidadeMap : BaseMap<Cidade>
    {
        public CidadeMap()
        {
            this.ToTable("CIDADE", "TCC");

            this.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(255).IsRequired();
            this.Property(x => x.IDEstado).HasColumnName("ID_ESTADO");
            this.HasRequired(x => x.Estado).WithMany(x => x.Cidade).HasForeignKey(x => x.IDEstado);
        }
    }
}
