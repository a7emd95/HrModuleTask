using Core.Interfaces.AppServices;
using Core.Models.Candidate;
using Core.Models.InterviewExam;
using Microsoft.AspNetCore.Mvc;
using MvcUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public InterviewController(ICandidateService candidateAppService,
            IJobPostionService jobPostionAppService, IQuestionService questionAppService)
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


        
        public IActionResult StartExam(int id)
        {
            //TODO : Map to viewModel
            SetQuestionTypeValues();

            var model = _candidateAppService.AssignCandidateToExam(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult StartExam(CandidateExamAnswersViewModel examAnswers)
        {
            SetQuestionTypeValues();

            return View();
        }

        private void SetQuestionTypeValues()
        {
            ViewBag.mcq = 1;
            ViewBag.yseOrNO = 2;
            ViewBag.multi = 3;
        }

    }
}
