using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarotApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Card, Card_Read_Dto>();
            CreateMap<ReadingType, ReadingType_Create_Dto>();
            CreateMap<ReadingType, ReadingType_Create_Dto>().ReverseMap();
            CreateMap<Reading, Reading_Create_Dto>();
            CreateMap<Reading, Reading_Create_Dto>().ReverseMap();
            // CreateMap<Reading_Read_Dto, Reading>(); unsure if needed yet
            CreateMap<ReadingType, ReadingType_Read_Dto>();
            CreateMap<ReadingType, ReadingType_Read_Dto>().ReverseMap();
        }
    }
}
