
namespace TCC.Web.Models
{
    public class EmpresaViewModel
    {
        //FK's
        public int Id { get; set; }
        public int IdCidade { get; set; }        
        //Campos
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string InscricaoEstadual { get; set; }
        public string Responsavel { get; set; }

        public string Email { get; set; }
        public string PaginaWEB { get; set; }
        public string TelefoneContato { get; set; }
        public string Ramal { get; set; }
        public string TelefoneCelular { get; set; }


        //Endereço 
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }

    }
}