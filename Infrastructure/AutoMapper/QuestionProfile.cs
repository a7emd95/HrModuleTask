using AutoMapper;
using Core.Entites;
using Core.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
   public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, CreateQuestionModel>()
                .ReverseMap();

            CreateMap<Question, UpdateQuestionModel>()
                .ReverseMap();

            CreateMap<Question, GetQuestionModel>()
                .ReverseMap();
        }
    }
}
