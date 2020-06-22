using TCC.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace TCC.Infra.Mapping
{
    public class LogOperacaoMap : BaseMap<LogOperacao>
    {
        public LogOperacaoMap()
        {
            ToTable("LOG_OPERACAO", "TCC");

            Property(x => x.IdUsuarioAprova)
             .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute()))
             .HasColumnName("ID_USUARIO_APROVA").HasColumnAnnotation("DefaultValue", 0).IsOptional();

            Property(x => x.IdSubMenu).HasColumnName("ID_SUBMENU").IsRequired();
            Property(x => x.IdEmpresa).HasColumnName("ID_EMPRESA").IsOptional();
            Property(x => x.Message).HasColumnName("MENSAGEM").HasMaxLength(LogOperacao.MAX_LENGTH_MESSAGE).IsOptional();
            Property(x => x.InnerException).HasColumnName("ERRO_EXCECAO").HasMaxLength(LogOperacao.MAX_LENGTH_INNER_EX).IsOptional();               
            Property(x => x.StackTrace).HasColumnName("PILHA_ERRO").HasMaxLength(LogOperacao.MAX_LENGTH_STACKTRACE).IsOptional();
            Property(x => x.eErrorGravity).HasColumnName("ERRO_GRAVIDADE").HasColumnAnnotation("DefaultValue", 0).IsRequired();
            Property(x => x.Aprovado).HasColumnName("APROVADO").IsRequired();
            Property(x => x.AprovaRestricao).HasColumnName("APROVA_RESTRICAO").HasColumnAnnotation("DefaultValue", 0).IsRequired();

            HasRequired(c => c.SubMenu).WithMany().HasForeignKey(c => c.IdSubMenu);
            HasOptional(c => c.Empresa).WithMany().HasForeignKey(c => c.IdEmpresa);
        }
    }
}
