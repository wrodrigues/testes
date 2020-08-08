using AutoMapper;
using Mapeamento.Domain.Dto;
using Mapeamento.Domain.Entities;

namespace Mapeamento.Infra.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
                .ForMember(
                    x => x.HomeStreet,
                    opt =>
                    {
                        opt.PreCondition(condition => condition.HomeAddress.AdressType == AddressType.Home);
                        opt.MapFrom(x => x.HomeAddress.Street);
                    }
                );
        }
    }
}
