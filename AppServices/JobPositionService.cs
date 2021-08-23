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
    public class JobPositionService : IJobPostionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobPositionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public List<GetJobPositionModel> GetAllJobPositions()
        {
            return _mapper.Map<List<GetJobPositionModel>>(_unitOfWork.JobPositionRepositroy.GetAll());
        }

        public GetJobPositionModel GetJobPosition(int JobPositionId)
        {
            return _mapper.Map<GetJobPositionModel>(_unitOfWork.JobPositionRepositroy.GetById(JobPositionId));
        }

        public GetJobPositionModel CreateNewJobPosition(CreateJobPositionModel jobPositionModel)
        {
            var newJobPosition = _mapper.Map<JobPosition>(jobPositionModel);
            var insertedJobPosition = _unitOfWork.JobPositionRepositroy.Insert(newJobPosition);

            if (_unitOfWork.SaveChanges() > new int())
                return _mapper.Map<GetJobPositionModel>(insertedJobPosition);
            return null;
        }


        public bool UpdateJobPosition(UpdateJobPositionModel jobPositionModel)
        {
            var jobPosition = _mapper.Map<JobPosition>(jobPositionModel);
            _unitOfWork.JobPositionRepositroy.Update(jobPosition);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        public bool DeleteJobPosition(Guid jobPositionId)
        {
            _unitOfWork.JobPositionRepositroy.DeletePosition(jobPositionId);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        public List<GetJobPositionModel> GetAllActiveJobPosition()
        {
            return _mapper.Map<List<GetJobPositionModel>>(_unitOfWork.JobPositionRepositroy.GetAllActivePositions());
        }

        public bool AssignQuestionToPosition(int positionId, int questionId)
        {
            var positionQuestion = new PositionQuestion() { JobPositionId = positionId, OuestionId = questionId };
            _unitOfWork.PositionQuestionRepository.Insert(positionQuestion);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        public bool SearchByTitle(string title)
        {
            if (_unitOfWork.JobPositionRepositroy.GetAny(jp => jp.Title.ToLower() == title.ToLower()))
                return true;
            return false;
        }
    }
}
