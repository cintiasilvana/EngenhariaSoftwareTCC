
using System;
using System.Collections.Generic;

namespace TCC.Web.Models
{
    public class TreinamentoViewModel
    {
        public int Id { get; set; }
        public int? IdColaborador { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdArquivo { get; set; }

        public List<int> DiaSemana { get; set; }

        public string Descricao { get; set; }
        public string Local { get; set; }
        public string Instrutor { get; set; }

        public DateTime? PeriodoInicial { get; set; }
        public DateTime? PeriodoFinal { get; set; }

    }
}