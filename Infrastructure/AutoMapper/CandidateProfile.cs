using AutoMapper;
using Core.Entites;
using Core.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, GetCandidateModel>()
                .ReverseMap();

            CreateMap<Candidate, GetCandiateWithPositionsModel>()
               .ForMember(c => c.Positions, opt => opt.Ignore())
               .ReverseMap();

            CreateMap<Candidate, CreateCandidateModel>()
                .ForMember(c => c.PositionId, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Candidate, UpdateCandidateModel>()
                .ReverseMap();
        }
    }
}
