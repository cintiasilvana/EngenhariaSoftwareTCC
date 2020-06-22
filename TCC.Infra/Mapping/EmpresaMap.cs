using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{

    public class EmpresaMap : BaseMap<Empresa>
    {
        public EmpresaMap()
        {
            this.ToTable("EMPRESA", "TCC");

            this.Property(x => x.CNPJ).HasColumnName("CNPJ").HasMaxLength(18)
                 .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CNPJ") { IsUnique = false })).IsRequired();
            this.Property(x => x.RazaoSocial).HasColumnName("RAZAO_SOCIAL").HasMaxLength(255).IsRequired();
            this.Property(x => x.NomeFantasia).HasColumnName("NOME_FANTASIA").HasMaxLength(255).IsRequired();
            this.Property(x => x.InscricaoEstadual).HasColumnName("INSCRICAO_ESTADUAL").HasMaxLength(50).IsOptional();

            this.Property(x => x.Responsavel).HasColumnName("RESPONSAVEL").HasMaxLength(255).IsRequired();

            this.Property(x => x.Email).HasColumnName("EMAIL").HasMaxLength(255).IsOptional();
            this.Property(x => x.PaginaWEB).HasColumnName("PAGINA_WEB").HasMaxLength(150).IsOptional();
            this.Property(x => x.TelefoneContato).HasColumnName("TEL_CONTATO").HasMaxLength(15).IsOptional();
            this.Property(x => x.Ramal).HasColumnName("RAMAL").HasMaxLength(10).IsOptional();
            this.Property(x => x.TelefoneCelular).HasColumnName("TEL_CELULAR").HasMaxLength(16).IsOptional();

            this.Property(x => x.Logradouro).HasColumnName("LOGRADOURO").HasMaxLength(255).IsRequired();
            this.Property(x => x.Numero).HasColumnName("NUMERO").IsRequired();
            this.Property(x => x.Complemento).HasColumnName("COMPLEMENTO").HasMaxLength(100).IsOptional();
            this.Property(x => x.Bairro).HasColumnName("BAIRRO").HasMaxLength(150).IsRequired();
            this.Property(x => x.CEP).HasColumnName("CEP").HasMaxLength(100).IsRequired();
            this.Property(x => x.IdCidade).HasColumnName("ID_CIDADE").IsRequired();

            this.HasRequired(x => x.Cidade).WithMany().HasForeignKey(x => x.IdCidade);
        }
    }
}
