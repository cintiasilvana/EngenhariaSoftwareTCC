using TCC.Domain.Identity;
using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Fisioterapeuta : BaseEntity
    {
        //FK
        public int IdEmpresa { get; set; }

        //Campos    
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Crefito { get; set; }


        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
