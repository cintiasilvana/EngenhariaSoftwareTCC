using TCC.Domain.Identity;
using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Matricula : BaseEntity
    {
        //FK
        public int IdCliente { get; set; }
        public int IdPlano { get; set; }

        //Campos    
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }

        public virtual Aluno Cliente { get; set; }
        public virtual Plano Plano { get; set; }

        public virtual ICollection<Pagamento> Pagamento { get; set; }
        public virtual ICollection<Ferias> Ferias { get; set; }
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
