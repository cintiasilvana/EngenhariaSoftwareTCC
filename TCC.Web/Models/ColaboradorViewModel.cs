

namespace TCC.Web.Models
{
    public class ColaboradorViewModel
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdAtividade { get; set; }
        public int? IdPerfil { get; set; }
        public int IdUsuarioLogin { get; set; }

        //Campos    

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }   
    }
}