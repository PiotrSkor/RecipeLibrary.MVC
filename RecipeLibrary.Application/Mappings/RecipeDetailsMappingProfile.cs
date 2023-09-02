using AutoMapper;
using RecipeLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLibrary.Application.Mappings
{
    public class RecipeDetailsMappingProfile : Profile
    {
        public RecipeDetailsMappingProfile()
        {
            CreateMap<RecipeDetailsDto, RecipeDetails>().ForMember(e => e.Name,
                opt => opt.MapFrom(src => src.Name));
        }
        
    }
}
