using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Ferias : BaseEntity
    {
        //FK       
        public int IdMatricula { get; set; }       

        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }

        //Mapeamento das tabelas virtuais
        public virtual Matricula Matricula { get; set; }
    }
}
