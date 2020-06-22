using TCC.Domain.Identity;
using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Plano : BaseEntity
    {
        //FK
        public int IdEmpresa { get; set; }

        //Campos    
        public string Descricao { get; set; }
        public decimal Valor { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
