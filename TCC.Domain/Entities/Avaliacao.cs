using TCC.Domain.Identity;
using System;

namespace TCC.Domain.Entities
{
    public class Avaliacao : BaseEntity
    {
        //FK
        public int IdFisioterapeuta { get; set; }
        public int IdCliente { get; set; }

        //Campos    
        public string Anamnese { get; set; }
        public string Dobras_cutaneas { get; set; }
        public string Ergometrico { get; set; }
        public DateTime DataAvaliacao { get; set; }


        public virtual Fisioterapeuta Fisioterapeuta { get; set; }
        public virtual Aluno Cliente { get; set; }
    }
}
