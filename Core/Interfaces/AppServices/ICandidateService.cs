using Core.Models.Candidate;
using Core.Models.InterviewExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.AppServices
{
    public interface ICandidateService
    {
        List<GetCandidateModel> GetAllCandidate();
        GetCandiateWithPositionsModel GetCandidate(int candidateId);

        GetCandidateModel CreateNewCandidate(CreateCandidateModel candidateModel);
        bool UpdateCandidate(UpdateCandidateModel candidateModel);

        bool DeleteCandidate(int candidate);

        void AddCandidateToPosition(int candidateId, int jobPositionId);
        ExamModel StartCandidateExam(int candidateId);
        ResultModel SubmitExam(ExamModel examModel);
    }
}
