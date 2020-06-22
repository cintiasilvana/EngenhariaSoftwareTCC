using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class SubMenuMap : BaseMap<SubMenu>
    {
        public SubMenuMap()
        {
            this.ToTable("SUBMENU", "TCC");

            this.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(250).IsRequired();
            this.Property(x => x.IdMenu).HasColumnName("ID_MENU")
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("Index") { IsUnique = false, Order = 1 })).IsRequired();
            
            this.Property(x => x.Controller).HasColumnName("TIPO_ACESSO").HasMaxLength(100).IsRequired();
            this.Property(x => x.Action).HasColumnName("VALOR_ACESSO").HasMaxLength(250).IsOptional();

            this.HasRequired(x => x.Menu).WithMany(x => x.RelSubMenu).HasForeignKey(x => x.IdMenu);
        }
    }
}