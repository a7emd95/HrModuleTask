﻿using AutoMapper;
using Core.Entites;
using Core.Interfaces.AppServices;
using Core.Interfaces.Base;
using Core.Models.Candidate;
using Core.Models.InterviewExam;
using Core.Models.JobPosition;
using Core.Models.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper)
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
                candiateModel.Positions
                    .Add(_mapper.Map<GetJobPositionModel>(_unitOfWork.JobPositionRepositroy.GetById(position.JobPositionId)));


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

        public ExamModel AssignCandidateToExam(int candidateId)
        {
            var exam = new InterviewExam() { CreatedDateTime = DateTime.Now, CandidateId = candidateId };
            var candidate = GetCandidate(candidateId);

            var insertedExam = _unitOfWork.InterviewExamRepository.Insert(exam);

            if (_unitOfWork.SaveChanges() > new int())
            {
                var questions = GenrateAllQuestionForCandidatePosition(candidateId);
                var examQuestions = SelectQuestionsRandomlyForExam(questions);

                return new ExamModel()
                { ExamQuestions = examQuestions, Candidate = candidate, InterViewExamId = insertedExam.Id, };
            }

            return null;
        }

        private List<GetQuestionWithAnswersModel> GenrateAllQuestionForCandidatePosition(int candidateId)
        {
            List<Question> questions = new List<Question>();
            var candidatePosition = _unitOfWork.CandidatePositionRepositroy.GetFristOrDefult(ca => ca.CandidateId == candidateId);
            var positionId = candidatePosition.JobPositionId;
            var jobposition = _unitOfWork.JobPositionRepositroy.GetJobPositionWithPositionsQuestions(positionId);

            foreach (var item in jobposition.PositionQuestions)
            {
                questions.Add(_unitOfWork.QuestionRepositroy.GetQuestionWithAnswer(item.OuestionId));
            }

            return _mapper.Map<List<GetQuestionWithAnswersModel>>(questions);

        }

        private List<GetQuestionWithAnswersModel> SelectQuestionsRandomlyForExam(List<GetQuestionWithAnswersModel> allQuestions)
        {
            Random random = new Random();
            List<GetQuestionWithAnswersModel> questions = new List<GetQuestionWithAnswersModel>();

            int randomNumberOfQuestin = random.Next(5, 9);
            int numberOfQuestin = (randomNumberOfQuestin > allQuestions.Count) ? allQuestions.Count : randomNumberOfQuestin;

            List<int> numbers = new List<int>();
            for (int i = 0; i < numberOfQuestin; i++)
            {

                // questions.Add(allQuestions[random.Next(allQuestions.Count)]);
                questions.Add(allQuestions[i]);
            }


            return questions;
        }

        public ResultModel SubmitExam(ExamModel examModel)
        {
            double score = CalcluateScore(examModel);

            foreach (var item in examModel.ExamQuestions)
            {
                var candidatAnswer = new CandidateAnswer { InterviewExamId = examModel.InterViewExamId, QuestionId = item.ID };
                _unitOfWork.CandidateAnswerRepository.Insert(candidatAnswer);
            }
            var interviewExam = _unitOfWork.InterviewExamRepository.GetById(examModel.InterViewExamId);
            interviewExam.SubmissionDateTime = DateTime.Now;
            interviewExam.Score = score;
            _unitOfWork.InterviewExamRepository.Update(interviewExam);
            _unitOfWork.SaveChanges();

            return new ResultModel { Score = (int)score };

        }



        private double CalcluateScore(ExamModel examModel)
        {
            double score = 0;
            int questionDegree = 100 / examModel.NumberOfOuestion;

            foreach (var question in examModel.ExamQuestions)
            {
                if (question.QuestionTypeId == (int)QuestionTypeEnum.mcq || question.QuestionTypeId == (int)QuestionTypeEnum.yseOrNO)
                {
                    foreach (var answer in question.QuestionAnswers)
                    {
                        if (question.CandidateSelectedAnswer != 0 && question.CandidateSelectedAnswer == answer.ID)
                        {
                            if (answer.IsCorrect)
                                score +=questionDegree;
                        }
                    }
                }

                if (question.QuestionTypeId == (int)QuestionTypeEnum.multi)
                {
                    bool isCandidateAnswerCoreect = true;
                    foreach (var answer in question.QuestionAnswers)
                    {

                        if (answer.IsSlected == true && answer.IsCorrect == false || answer.IsSlected == false && answer.IsCorrect == true)
                        {

                            isCandidateAnswerCoreect = false;
                        }

                    }
                    if (isCandidateAnswerCoreect)
                        score += questionDegree;
                    else
                        score += 0;
                }
            }
            return score;
        }



    }

    enum QuestionTypeEnum
    {
        mcq = 1,
        yseOrNO = 2,
        multi = 3
    }
}
