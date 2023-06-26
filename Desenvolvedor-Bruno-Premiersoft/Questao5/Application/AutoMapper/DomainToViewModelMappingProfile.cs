using AutoMapper;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<CheckingAccount, GetBalanceViewModel>();
        }
    }
}
