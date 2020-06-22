using System;
using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Treinamento : BaseEntity
    {
        public int? IdColaborador { get; set; }
        public int IdEmpresa { get; set; }

        public string Descricao { get; set; }
        public string Local { get; set; }

        public DateTime? PeriodoInicial { get; set; }
        public DateTime? PeriodoFinal { get; set; }
        
        public virtual Empresa Empresa { get; set; }
        public virtual Instrutor Colaborador { get; set; }

        public virtual ICollection<TreinamentoSemana> TreinamentoSemana { get; set; }
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
