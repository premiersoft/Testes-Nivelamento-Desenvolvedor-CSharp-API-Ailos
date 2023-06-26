using AutoMapper;
using Questao5.Application.Commands.Requests;
using Questao5.Domain.Entities;

namespace Questao5.Application.AutoMapper
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            CreateMap<CheckingAccountMovementCommand, Movement>();
        }
    }
}
