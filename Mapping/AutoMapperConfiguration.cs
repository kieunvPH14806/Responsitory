using System.Collections.Generic;
using AutoMapper;

using Demo_Responsitory.Entities;
using Demo_Responsitory.ViewsModels;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Demo_Responsitory.ViewsModels.ModelsShow;

namespace Demo_Responsitory.Mapping;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<PostClassViewModels, Class>().ReverseMap();

        CreateMap<PostStudentViewModels, Student>().ReverseMap();

        CreateMap<ClassUpdateViewModels, Class>().ReverseMap();
     

    }
}