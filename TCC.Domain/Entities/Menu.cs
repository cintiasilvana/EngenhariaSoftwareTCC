using System.Collections.Generic;

namespace TCC.Domain.Entities
{
    public class Menu : BaseEntity
    {
        //CAMPOS
        public string Descricao { get; set; }
        
        //PROPRIEDADES DE NAVEGACAO        
        public virtual ICollection<SubMenu> RelSubMenu { get; set; }       
    }
}
