using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Estado : BaseEntity
    {
        //FK's
        public int IdPais { get; set; }

        //Mapeamento das tabelas virtuais
        public virtual Pais Pais { get; set; }

        //Campos
        
        public string Descricao { get; set; }

        //PROPRIEDADES DE NAVEGACAO
        public virtual ICollection<Cidade> Cidade { get; set; }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
