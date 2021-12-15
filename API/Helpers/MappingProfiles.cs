using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Resume, ResumeToReturnDto>().ForMember(d => d.ResumeCategory, o => o.MapFrom(s => s.ResumeCategory.Name));
            CreateMap<Job, JobToReturnDto>().ForMember(d => d.JobCategory, o => o.MapFrom(s => s.JobCategory.Name));
        }
    }
}