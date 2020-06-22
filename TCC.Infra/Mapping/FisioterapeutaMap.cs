using TCC.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace TCC.Infra.Mapping
{
    public class FisioterapeutaMap : BaseMap<Fisioterapeuta>
    {
        public FisioterapeutaMap()
        {
            this.ToTable("FISIOTERAPEUTA", "TCC");

            this.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(255).IsRequired();
            this.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(14).IsRequired();
            this.Property(x => x.Crefito).HasColumnName("CREFITO").IsRequired();
            this.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(255).IsRequired();
            this.Property(x => x.IdEmpresa).HasColumnName("ID_EMPRESA").IsRequired();
            
            this.HasRequired(x => x.Empresa).WithMany(x => x.Fisioterapeuta).HasForeignKey(x => x.IdEmpresa);            
        }
    }
}
