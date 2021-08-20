using AutoMapper;
using Core.Entites;
using Core.Interfaces.AppServices;
using Core.Interfaces.Base;
using Core.Models.Candidate;
using Core.Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class CandidateAppService : ICandidateAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CandidateAppService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public List<GetCandidateModel> GetAllCandidate()
        {
            return _mapper.Map<List<GetCandidateModel>>(_unitOfWork.CandidateRepositroy.GetAll());

        }

        public GetCandiateWithPositionsModel GetCandidate(int candidateId)
        {
            var candiate = _unitOfWork.CandidateRepositroy.GetCandidatWithPosition(candidateId);
            var candiateModel = _mapper.Map<GetCandiateWithPositionsModel>(candiate);

            foreach (var position in candiate.CandidatePositions)
            {
                candiateModel.Positions.
                    Add(_mapper.Map<GetJobPositionModel>(_unitOfWork.JobPositionRepositroy.GetById(position.JobPositionId)));
            }
            return candiateModel;
        }

        public GetCandidateModel CreateNewCandidate(CreateCandidateModel candidateModel)
        {
            var PositionId = candidateModel.PositionId;
            var newCandidate = _mapper.Map<Candidate>(candidateModel);
            var insertedCandidate = _unitOfWork.CandidateRepositroy.Insert(newCandidate);

            if (_unitOfWork.SaveChanges() > new int())
            {
                var candidatePosition = new CandidatePosition()
                { CandidateId = insertedCandidate.ID, JobPositionId = PositionId, IsActive = true };
                _unitOfWork.CandidatePositionRepositroy.Insert(candidatePosition);
                _unitOfWork.SaveChanges();
                return _mapper.Map<GetCandidateModel>(insertedCandidate);
            }

            return null;
        }


        //TODO : Make Update With Position
        public bool UpdateCandidate(UpdateCandidateModel candidateModel)
        {

            var candidate = _mapper.Map<Candidate>(candidateModel);
            _unitOfWork.CandidateRepositroy.Update(candidate);

            if (_unitOfWork.SaveChanges() > new int())
            {

                return true;
            }

            return false;
        }

        public bool DeleteCandidate(int candidate)
        {
            _unitOfWork.CandidateRepositroy.Delete(candidate);

            if (_unitOfWork.SaveChanges() > new int())
                return true;
            return false;
        }

        public void AddCandidateToPosition(int candidateId, int jobPositionId)
        {
            var candidatePosition = new CandidatePosition()
            { CandidateId = candidateId, JobPositionId = jobPositionId, IsActive = true };

            _unitOfWork.CandidatePositionRepositroy.Insert(candidatePosition);
            _unitOfWork.SaveChanges();

        }
    }
}
