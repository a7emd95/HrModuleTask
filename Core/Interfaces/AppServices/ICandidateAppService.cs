﻿using Core.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.AppServices
{
    public interface ICandidateAppService
    {
        List<GetCandidateModel> GetAllCandidate();
        GetCandiateWithPositionsModel GetCandidate(int candidateId);

        GetCandidateModel CreateNewCandidate(CreateCandidateModel candidateModel);
        bool UpdateCandidate(UpdateCandidateModel candidateModel);

        bool DeleteCandidate(int candidate);
    }
}
