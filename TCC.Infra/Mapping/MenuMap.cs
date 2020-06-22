using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class MenuMap : BaseMap<Menu>
    {
        public MenuMap()
        {
            this.ToTable("MENU", "TCC");

            this.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(250).IsRequired();
        }
    }
}