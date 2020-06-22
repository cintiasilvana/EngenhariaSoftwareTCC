using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Presenca : BaseEntity
    {
        //FK       
        public int IdMatricula { get; set; }
        public int IdTreinamento { get; set; }

        public DateTime DataPresenca { get; set; }

        //Mapeamento das tabelas virtuais
        public virtual Matricula Matricula { get; set; }
        public virtual Treinamento Treinamento { get; set; }
    }
}
