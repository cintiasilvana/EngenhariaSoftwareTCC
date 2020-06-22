using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class PagamentoMap : BaseMap<Pagamento>
    {
        public PagamentoMap()
        {
            this.ToTable("PAGAMENTO", "TCC");

            this.Property(x => x.IdMatricula).HasColumnName("ID_MATRICULA");
            this.Property(x => x.DataPagamento).HasColumnName("DATA_PAGAMENTO").IsRequired();
            this.Property(x => x.ValorPagamento).HasColumnName("VALOR_PAGAMENTO").IsRequired();
            this.Property(x => x.FormaPagamento).HasColumnName("FORMA_PAGAMENTO").HasMaxLength(50).IsRequired();

            this.HasRequired(x => x.Matricula).WithMany(x => x.Pagamento).HasForeignKey(x => x.IdMatricula);
        }
    }
}
