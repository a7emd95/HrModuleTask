using Core.Enum;
using Core.Interfaces.AppServices;
using Core.Models.Candidate;
using Core.Models.InterviewExam;
using Microsoft.AspNetCore.Mvc;
using MvcUi.Mappers;
using MvcUi.Models;
using System;

namespace MvcUi.Controllers
{
    public class InterviewController : Controller
    {
        private readonly ICandidateService _candidateAppService;
        private readonly IJobPostionService _jobPostionAppService;
        private readonly IQuestionService _questionAppService;

        public IActionResult Index()
        {
            return View();
        }

        public InterviewController(
            ICandidateService candidateAppService,
            IJobPostionService jobPostionAppService,
            IQuestionService questionAppService)
        {
            _candidateAppService = candidateAppService;
            _jobPostionAppService = jobPostionAppService;
            _questionAppService = questionAppService;
        }

        [Route("interview/candidate/create")]
        public IActionResult CreateCandidate()
        {
            ViewBag.jopPositions = _jobPostionAppService.GetAllActiveJobPosition();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [Route("interview/candidate/create")]
        public IActionResult CreateCandidate(CreateCandidateModel candidate)
        {
            ViewBag.jopPositions = _jobPostionAppService.GetAllActiveJobPosition();

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _candidateAppService.CreateNewCandidate(candidate);
                    if (result == null)
                    {
                        ModelState.AddModelError("", "Failed to add candidate");
                        return View(candidate);
                    }

                    return RedirectToAction("GetAllCandidates");

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(candidate);

                }
            }
            return View(candidate);
        }

        [Route("interview/candidate/all")]
        public IActionResult GetAllCandidates()
        {
            return View(_candidateAppService.GetAllCandidate());
        }

        public IActionResult DeleteCandidate(int id)
        {
            _candidateAppService.DeleteCandidate(id);
            return RedirectToAction("GetAllCandidates");
        }


        [Route("interview/candidate/exam")]
        public IActionResult StartExam(int id)
        {

            SetQuestionTypeValues();

            var model = _candidateAppService.StartCandidateExam(id);
            var viewModel = Mapper.MapToExamViewModel(model);
            return View(viewModel);
        }

        [HttpPost]
        [Route("interview/candidate/exam")]
        public IActionResult StartExam(CandidateExamAnswersViewModel examAnswers)
        {
            SetQuestionTypeValues();
            var model = Mapper.MapToExamModel(examAnswers);
            var resultModel = _candidateAppService.SubmitExam(model);

            return RedirectToAction("Result", new { Score = resultModel.Score });
        }

        [Route("interview/candidate/result")]
        public IActionResult Result(ResultModel model)
        {
            return View(model);

        }
        private void SetQuestionTypeValues()
        {
            ViewBag.mcq = (int) QuestionTypeEnum.mcq;
            ViewBag.yseOrNO = (int) QuestionTypeEnum.yseOrNO;
            ViewBag.multi = (int)QuestionTypeEnum.multi;
        }

    }
}
