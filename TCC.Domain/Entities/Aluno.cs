using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        //FK
       
        public int IdCidade { get; set; }
        public int IdEmpresa { get; set; }

        public string Nome { get; set; }          
        public string Email { get; set; } 
        public string TelefoneContato { get; set; }
        public string Ramal { get; set; }
        public string Cpf { get; set; }
        public string Identidade { get; set; }
        public string TelefoneCelular { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }

        //Mapeamento das tabelas virtuais
        public virtual Empresa Empresa { get; set; }      
        public virtual Cidade Cidade { get; set; }

        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }

    }
}
