using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Cidade : BaseEntity
    {
        //FK's
        public int IDEstado { get; set; }

        //Mapeamento das tabelas virtuais
        public virtual Estado Estado { get; set; }

        //Campos
        
        public string Descricao { get; set; }       

      
    }    
}
