using TCC.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace TCC.Infra.Mapping
{
    public class InstrutorMap : BaseMap<Instrutor>
    {
        public InstrutorMap()
        {
            this.ToTable("INSTRUTOR", "TCC");

            
            this.Property(x => x.Nome).HasColumnName("NOME").HasMaxLength(255).IsRequired();
            this.Property(x => x.Cpf).HasColumnName("CPF").HasMaxLength(14).IsOptional();
            
            this.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(255).IsRequired();
            this.Property(x => x.IdEmpresa).HasColumnName("ID_EMPRESA").IsRequired();

            this.Property(x => x.IdAtividade).HasColumnName("ID_ATIVIDADE")
                  .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_ID_ATIVIDADE") { IsUnique = false })).IsOptional();

            this.Property(x => x.IdUsuarioLogin).HasColumnName("ID_USUARIO_LOGIN").IsRequired();
            this.Property(x => x.IdPerfil).HasColumnName("ID_PERFIL").IsOptional();
            
            this.HasRequired(x => x.Empresa).WithMany(x => x.Colaborador).HasForeignKey(x => x.IdEmpresa);            
            this.HasRequired(x => x.Usuario).WithMany().HasForeignKey(x => x.IdUsuarioLogin);
            this.HasOptional(x => x.Perfil).WithMany().HasForeignKey(x => x.IdPerfil);            
        }
    }
}
