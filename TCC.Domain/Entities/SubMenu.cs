
namespace TCC.Domain.Entities
{
    public class SubMenu : BaseEntity
    {
        public int IdMenu { get; set; }
        
        public string Descricao { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

     
        //Mapeamento das tabelas virtuais  
        public virtual Menu Menu { get; set; }          
    }
}
