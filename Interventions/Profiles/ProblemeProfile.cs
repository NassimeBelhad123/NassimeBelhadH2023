using AutoMapper;
using Interventions.Entities;
using Interventions.Models;

namespace Interventions.Profiles
{
    public class ProblemeProfile : Profile
    {
        public ProblemeProfile()
        {
            CreateMap<TypeProbleme, TypeProblemeDTO>();
        }
    }
}
