using AutoMapper;
using Mapeamento.Domain.Dto;
using Mapeamento.Domain.Entities;
using Mapeamento.Infra.Mappings;
using System;
using Xunit;

namespace Mapeamento.Infra.Tests
{
    public class PersonMapeamentoTests
    {
        private readonly IMapper mapper;
        private Person person;

        public PersonMapeamentoTests()
        {
            var config = new MapperConfiguration(config =>
            {
                config.AllowNullCollections = true;

                config.AddProfile(new PersonProfile());
            });

            config.AssertConfigurationIsValid();

            this.mapper = config.CreateMapper();

            this.person = new Person { Name = "Wellington Rodrigues da Silva" };
        }

        [Fact]
        public void DeveMapearPersonDtoComSucesso()
        {
            //arrange
            person.HomeAddress = new Address { AdressType = AddressType.Home, Street = "Rua André de Almeida 1620, Bloco 7 Apartamento 44" };

            //action
            var dto = mapper.Map<PersonDto>(person);

            //assert
            Assert.Equal(person.Name, dto.Name);

            Assert.Equal(person.HomeAddress.Street, dto.HomeStreet);
        }

        [Fact]
        public void DeveMapearPersonDtoSemEndereco()
        {
            //arrange
            person.HomeAddress = new Address { AdressType = AddressType.Delivery, Street = "Rua André de Almeida 1620, Bloco 7 Apartamento 44" };

            //action
            var dto = mapper.Map<PersonDto>(person);

            //assert
            Assert.Equal(person.Name, dto.Name);

            Assert.Null(dto.HomeStreet);
        }
    }
}
