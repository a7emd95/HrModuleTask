using AutoMapper;
using Core.Entites;
using Core.Models.QuestuinType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class QuestionTypeProfile : Profile
    {
        public QuestionTypeProfile()
        {
            CreateMap<QuestionType, GetQuestionTypeModel>()
                .ReverseMap();

        }
    }
}
