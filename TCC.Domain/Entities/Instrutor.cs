using TCC.Domain.Identity;
using System;

namespace TCC.Domain.Entities
{
    public class Instrutor : BaseEntity
    {
        //FK
        public int IdEmpresa { get; set; }
        public int IdAtividade { get; set; }
        public int? IdPerfil { get; set; }
        public int IdUsuarioLogin { get; set; }

        //Campos    

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        

        public virtual Empresa Empresa { get; set; }
        

        public virtual ApplicationUser Usuario { get; set; }
        public virtual ApplicationRole Perfil { get; set; }        
    }
}
