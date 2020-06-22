using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TCC.Domain.Entities;
using TCC.Infra.Context;
using TCC.Infra.Repositories;

namespace HTS.Infra.Visions
{
    public class SubMenuObject : RepositoryBase<SubMenu>
    {
        public SubMenuObject(AcademiaContext context) : base(context)
        {
            Context = new AcademiaContext();
        }

        public SubMenuObject()
        {

        }

        public async Task<IList<SubMenuDto>> GetSubMenuByRota(string action, string controller)
        {
            var dados = GetAll().Where(w => w.Action == action &&
                                  w.Controller == controller ||
                                  w.Controller == controller &&
                                  string.IsNullOrEmpty(w.Action))
                .Select(c => new SubMenuDto
                {
                    Id = c.Id,
                    Action = c.Action,
                    Controller = c.Controller
                }).ToListAsync();

            return await dados;
        }

        public SubMenuDto GetSubMenuByRotaId(string action, string controller)
        {
            var id = GetAll().Where(w => action == null && w.Controller == controller ||
                                w.Controller == controller && w.Action == action)
                .Select(c => new SubMenuDto
                {
                    Id = c.Id
                }).First();

            return id;
        }

    }

    public class SubMenuDto
    {
        public int Id { get; set; }
        public int IdPerfil { get; set; }
        public int IdEmpresa { get; set; }
        public string Descricao { get; set; }
        public bool Checked { get; set; }
        public int IdMenu { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int IdTipoOperacao { get; set; }

        public IEnumerable<SubMenuDto> SubMenus { get; set; }
        public IEnumerable<int> Colaboradores { get; set; }
    }
}
