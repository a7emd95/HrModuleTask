using AutoMapper;
using Core.Entites;
using Core.Interfaces.AppServices;
using Core.Interfaces.Base;
using Core.Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class JobPositionAppService : IJobPostionAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobPositionAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Dispose(){
            _unitOfWork.Dispose();
        }

        public List<GetJobPositionModel> GetAllJobPositions(){
            return _mapper.Map<List<GetJobPositionModel>>(_unitOfWork.JobPositionRepositroy.GetAll());
        }

        public GetJobPositionModel GetJobPosition(int JobPositionId){
            return _mapper.Map<GetJobPositionModel>(_unitOfWork.JobPositionRepositroy.GetById(JobPositionId));
        }

        public GetJobPositionModel CreateNewJobPosition(CreateJobPositionModel jobPositionModel){
            var newJobPosition = _mapper.Map<JobPosition>(jobPositionModel);
            var insertedJobPosition = _unitOfWork.JobPositionRepositroy.Insert(newJobPosition);
        
            if (_unitOfWork.SaveChanges() > new int())
                return _mapper.Map<GetJobPositionModel>(insertedJobPosition);
            return null;
        }

        public bool UpdateJobPosition(UpdateJobPositionModel jobPositionModel){
             var jobPosition = _mapper.Map<JobPosition>(jobPositionModel);
            _unitOfWork.JobPositionRepositroy.Update(jobPosition);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        public bool DeleteJobPosition(int jobPositionId){
            _unitOfWork.JobPositionRepositroy.Delete(jobPositionId);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }
    }
}
