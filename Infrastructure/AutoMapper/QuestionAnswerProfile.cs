using AutoMapper;
using Core.Entites;
using Core.Models.QuestionAnswer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    class QuestionAnswerProfile : Profile
    {
        public QuestionAnswerProfile()
        {
            CreateMap<QuestionAnswer, CreateQuestionAnswerModel>()
                .ReverseMap();

            CreateMap<QuestionAnswer, GetQuestionAnswerModel>()
               .ReverseMap();
        }
    }
}
