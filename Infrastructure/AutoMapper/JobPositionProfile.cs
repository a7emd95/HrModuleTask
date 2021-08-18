using AutoMapper;
using Core.Entites;
using Core.Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapper
{
    public class JobPositionProfile : Profile
    {
        public JobPositionProfile()
        {
            CreateMap<JobPosition, CreateJobPositionModel>()
                 .ReverseMap();

            CreateMap<JobPosition, GetJobPositionModel>()
                .ReverseMap();

            CreateMap<JobPosition, UpdateJobPositionModel>()
                .ReverseMap();
        }

    }
}
