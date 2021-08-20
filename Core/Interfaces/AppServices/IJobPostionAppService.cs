using Core.Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.AppServices
{
    public interface IJobPostionAppService : IDisposable
    {
        List<GetJobPositionModel> GetAllJobPositions();
        List<GetJobPositionModel> GetAllActiveJobPosition();
        GetJobPositionModel GetJobPosition(int JobPositionId);

        GetJobPositionModel CreateNewJobPosition(CreateJobPositionModel jobPositionModel);
        bool UpdateJobPosition(UpdateJobPositionModel jobPositionModel);

        bool DeleteJobPosition(Guid jobPositionId);

        bool AssignQuestionToPosition(int positionId, int questionId);

        public bool SearchByTitle(string title);

    }
}
