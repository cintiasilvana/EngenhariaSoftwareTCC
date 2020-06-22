using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class BaseMap<T> : EntityTypeConfiguration<T>  where T : BaseEntity
    {
        public BaseMap()
        {
            HasKey(x => x.Id).Property(x => x.Id).HasColumnName("ID");
            Property(x => x.IdUsuario)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()))
                .HasColumnName("ID_USUARIO").IsRequired();
            Property(x => x.DataRegistro).HasColumnName("DATA_REGISTRO").IsRequired();
            Property(x => x.DataExclusao).HasColumnName("DATA_EXCLUSAO").IsOptional();
        }
    }
}
