using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Pagamento : BaseEntity
    {
        //FK       
        public int IdMatricula { get; set; }       

        public DateTime DataPagamento { get; set; }          
        public decimal ValorPagamento { get; set; } 
        public string FormaPagamento { get; set; }

        //Mapeamento das tabelas virtuais
        public virtual Matricula Matricula { get; set; }
    }
}
