using AutoMapper;
using Entity;
using ProcessMaker_Data.DataModel;

namespace Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //process mapping
            CreateMap<Process_DataModel, ProcessDto>();
            CreateMap<ProcessDto, Process_DataModel>();
        }
    }
}
