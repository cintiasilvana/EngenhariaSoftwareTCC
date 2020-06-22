using TCC.Domain.Objects;

namespace TCC.Domain.Entities
{
    public class LogOperacao : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_MESSAGE = 1000;
        public const int MAX_LENGTH_INNER_EX = 2000;
        public const int MAX_LENGTH_STACKTRACE = 2000;        
        #endregion

        #region Propeties 

        public int IdSubMenu { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdUsuarioAprova { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }        
        public bool Aprovado { get; set; }
        public bool AprovaRestricao { get; set; }

        public eErrorGravity eErrorGravity { get; set; }     
        
        public virtual Empresa Empresa { get; set; }
        public virtual SubMenu SubMenu { get; set; }
        #endregion      
    }
}
