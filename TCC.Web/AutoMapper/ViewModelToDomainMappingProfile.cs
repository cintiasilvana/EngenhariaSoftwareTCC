
namespace HTS.MVC.AutoMapper
{
    using global::AutoMapper;

    using TCC.Domain.Entities;
    using TCC.Infra.ValueObject;
    using TCC.Web.Models;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMapping";

        public ViewModelToDomainMappingProfile()
        {

            this.CreateMap<Aluno, ClienteViewModel>();
            this.CreateMap<Instrutor, ColaboradorViewModel>();
            this.CreateMap<Empresa, EmpresaViewModel>();
            this.CreateMap<Treinamento, TreinamentoViewModel>();
            this.CreateMap<TreinamentoDto, TreinamentoViewModel>();
        }
    }
}