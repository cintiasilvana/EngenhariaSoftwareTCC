using TCC.Domain.Entities;

namespace TCC.Infra.Mapping
{
    public class AvaliacaoMap : BaseMap<Avaliacao>
    {
        public AvaliacaoMap()
        {
            this.ToTable("AVALIACAO", "TCC");

            this.Property(x => x.IdFisioterapeuta).HasColumnName("ID_FISIOTERAPEUTA");
            this.Property(x => x.IdCliente).HasColumnName("ID_CLIENTE");
            this.Property(x => x.Anamnese).HasColumnName("ANAMNESE").HasMaxLength(255).IsRequired();
            this.Property(x => x.Dobras_cutaneas).HasColumnName("DOBRAS_CUTANEAS").HasMaxLength(255).IsRequired();
            this.Property(x => x.Ergometrico).HasColumnName("ERGOMETRICO").HasMaxLength(500).IsRequired();
            this.Property(x => x.DataAvaliacao).HasColumnName("DATA_AVALIACAO").IsRequired();

            this.HasRequired(x => x.Fisioterapeuta).WithMany(x => x.Avaliacao).HasForeignKey(x => x.IdFisioterapeuta);
            this.HasRequired(x => x.Cliente).WithMany(x => x.Avaliacao).HasForeignKey(x => x.IdCliente);
        }
    }
}
