using System;
using System.Collections.Generic;
using TCC.Domain.Entities;


namespace TCC.Infra.Mapping
{

    public class PaisMap : BaseMap<Pais>
    {
        public PaisMap()
        {
            this.ToTable("PAIS", "TCC");
            
            this.Property(x => x.Descricao).HasColumnName("DESCRICAO").HasMaxLength(255).IsRequired();
        }
    }
}
