using AutoMapper;
using ProstorTest.Database.Entities;
using ProstorTest.Shared;

namespace ProstorTest.Service.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDb>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.FirstName, x => x.MapFrom(y => y.FirstName))
            .ForMember(x => x.LastName, x => x.MapFrom(y => y.LastName));

        CreateMap<PersonDb, Person>()
            .ForMember(x => x.Id, x => x.MapFrom(y => y.Id))
            .ForMember(x => x.FirstName, x => x.MapFrom(y => y.FirstName))
            .ForMember(x => x.LastName, x => x.MapFrom(y => y.LastName));
    }
}
