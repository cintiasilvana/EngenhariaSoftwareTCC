using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Pais : BaseEntity
    {
        //Campos
        
        public string Descricao { get; set; }

        //PROPRIEDADES DE NAVEGACAO
        public virtual ICollection<Estado> Estado { get; set; }
        
        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
