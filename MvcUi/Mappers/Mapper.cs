using Core.Models.InterviewExam;
using MvcUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUi.Mappers
{
    static public class Mapper
    {
        public static ExamViewModel MapToExamViewModel(ExamModel examModel)
        {
            ExamViewModel viewModel = new ExamViewModel();
            viewModel.CandidateName = examModel.Candidate.Name;
            viewModel.CandidatePosition = examModel.Candidate.Positions[0].Title;
            viewModel.InterViewExamId = examModel.InterViewExamId;
            viewModel.ExamQuestions = examModel.ExamQuestions;
            viewModel.NumberOfOuestion = examModel.NumberOfOuestion;
            return viewModel;
        }

        public static ExamModel MapToExamModel(CandidateExamAnswersViewModel viewModel)
        {
            ExamModel model = new ExamModel();
            model.InterViewExamId = viewModel.InterViewExamId;
            model.ExamQuestions = viewModel.ExamQuestions;

            return model;

        }
    }
}
