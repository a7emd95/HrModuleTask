using AutoMapper;
using Core.Entites;
using Core.Interfaces.AppServices;
using Core.Interfaces.Base;
using Core.Models.JobPosition;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// get all positions
        /// </summary>
        /// <returns> list of positions</returns>
        public List<GetJobPositionModel> GetAllJobPositions()
        {
            return _mapper.Map<List<GetJobPositionModel>>(_unitOfWork.JobPositionRepositroy.GetAll());
        }

        /// <summary>
        /// get position by id
        /// </summary>
        /// <param name="JobPositionId"></param>
        /// <returns>position</returns>
        public GetJobPositionModel GetJobPosition(int JobPositionId)
        {
            return _mapper.Map<GetJobPositionModel>(_unitOfWork.JobPositionRepositroy.GetById(JobPositionId));
        }

        /// <summary>
        /// create new job position
        /// </summary>
        /// <param name="jobPositionModel"></param>
        /// <returns> created position </returns>
        public GetJobPositionModel CreateNewJobPosition(CreateJobPositionModel jobPositionModel)
        {
            var newJobPosition = _mapper.Map<JobPosition>(jobPositionModel);
            var insertedJobPosition = _unitOfWork.JobPositionRepositroy.Insert(newJobPosition);

            if (_unitOfWork.SaveChanges() > new int())
                return _mapper.Map<GetJobPositionModel>(insertedJobPosition);
            return null;
        }

        /// <summary>
        /// update job position 
        /// </summary>
        /// <param name="jobPositionModel"></param>
        /// <returns> bool </returns>
        public bool UpdateJobPosition(UpdateJobPositionModel jobPositionModel)
        {
            var jobPosition = _mapper.Map<JobPosition>(jobPositionModel);
            _unitOfWork.JobPositionRepositroy.Update(jobPosition);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        /// <summary>
        /// delete position 
        /// </summary>
        /// <param name="jobPositionId"></param>
        /// <returns> bool </returns>
        public bool DeleteJobPosition(Guid jobPositionId)
        {
            _unitOfWork.JobPositionRepositroy.DeletePosition(jobPositionId);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        /// <summary>
        /// list of all active position
        /// </summary>
        /// <returns> list of position</returns>
        public List<GetJobPositionModel> GetAllActiveJobPosition()
        {
            return _mapper.Map<List<GetJobPositionModel>>(_unitOfWork.JobPositionRepositroy.GetAllActivePositions());
        }

        /// <summary>
        /// assign questions to positions
        /// </summary>
        /// <param name="positionId"></param>
        /// <param name="questionId"></param>
        /// <returns> bool </returns>
        public bool AssignQuestionToPosition(int positionId, int questionId)
        {
            var positionQuestion = new PositionQuestion() { JobPositionId = positionId, OuestionId = questionId };
            _unitOfWork.PositionQuestionRepository.Insert(positionQuestion);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }
        /// <summary>
        /// search for position by title
        /// </summary>
        /// <param name="title"></param>
        /// <returns> bool </returns>
        public bool SearchByTitle(string title)
        {
            if (_unitOfWork.JobPositionRepositroy.GetAny(jp => jp.Title.ToLower() == title.ToLower()))
                return true;
            return false;
        }
    }
}
