using Core.Interfaces.Base;
using Core.Interfaces.Repositroies;
using Infrastructure.Persistence;
using Infrastructure.Repositroies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext context)
        {
            _dbContext = context;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }


        private JobPositionRepositroy jobPositionRepo;
        public IJobPositionRepositroy JobPositionRepositroy
        {
            get
            {
                if (jobPositionRepo == null)
                {
                    jobPositionRepo = new JobPositionRepositroy(_dbContext);
                }
                return jobPositionRepo;
            }
        }

        private CandidateRepositroy candidateRepo;
        public ICandidateRepositroy CandidateRepositroy
        {
            get
            {
                if (candidateRepo == null)
                {
                    candidateRepo = new CandidateRepositroy(_dbContext);
                }
                return candidateRepo;
            }
        }

        private CandidatePositionRepositroy candidatePositionRepo;
        public ICandidatePositionRepositroy CandidatePositionRepositroy
        {
            get
            {
                if (candidatePositionRepo == null)
                {
                    candidatePositionRepo = new CandidatePositionRepositroy(_dbContext);
                }
                return candidatePositionRepo;
            }
        }

        private QuestionRepositroy questionRepo;
        public IQuestionRepositroy QuestionRepositroy
        {
            get
            {
                if (questionRepo == null)
                {
                    questionRepo = new QuestionRepositroy(_dbContext);
                }
                return questionRepo;
            }
        }

        private PositionQuestionRepository positionQuestionRepo;
        public IPositionQuestionRepository PositionQuestionRepository
        {
            get
            {
                if (positionQuestionRepo == null)
                {
                    positionQuestionRepo = new PositionQuestionRepository(_dbContext);
                }
                return positionQuestionRepo;
            }
        }


        private InterviewExamRepository interviewExamRepo;
        public IInterviewExamRepository InterviewExamRepository
        {
            get
            {
                if (interviewExamRepo == null)
                {
                    interviewExamRepo = new InterviewExamRepository(_dbContext);
                }
                return interviewExamRepo;
            }
        }

        private CandidateAnswerRepositroy candidateAnswerRepo;
        public ICandidateAnswerRepository ICandidateAnswerRepository
        {
            get
            {
                if (candidateAnswerRepo == null)
                {
                    candidateAnswerRepo = new CandidateAnswerRepositroy(_dbContext);
                }
                return candidateAnswerRepo;
            }
        }

        private QuestionAnswerRepository questionAnswerRepo;
        public IQuestionAnswerRepository QuestionAnswerRepository
        {
            get
            {
                if (questionAnswerRepo == null)
                {
                    questionAnswerRepo = new QuestionAnswerRepository(_dbContext);
                }
                return questionAnswerRepo;
            }
        }

    }
}

