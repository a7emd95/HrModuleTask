using Core.Interfaces.AppServices;
using Core.Models.JobPosition;
using Core.Models.Question;
using Core.Models.QuestionAnswer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUi.Controllers
{
    public class AdminController : Controller
    {
        private readonly IJobPostionAppService _jobPostionAppService;
        private readonly IQuestionAppService _questionAppService;

        public AdminController(IJobPostionAppService jobPostionAppService, IQuestionAppService questionAppService)
        {
            _jobPostionAppService = jobPostionAppService;
            _questionAppService = questionAppService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("admin/jobposition/create")]
        public IActionResult CreateJobPosition()
        {
            return View();
        }

        [HttpPost("admin/jobposition/create")]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateJobPosition(CreateJobPositionModel jobPosition)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_jobPostionAppService.SearchByTitle(jobPosition.Title))
                    {
                        ModelState.AddModelError("", "This title is exist");
                        return View(jobPosition);
                    }

                    _jobPostionAppService.CreateNewJobPosition(jobPosition);
                    return RedirectToAction("GetAllPosition", "Admin");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(jobPosition);
        }

        [HttpGet]
        public IActionResult GetAllPosition()
        {
            var positions = _jobPostionAppService.GetAllJobPositions();
            return View(positions);
        }

        [HttpGet]
        public IActionResult DeletePosition(Guid id)
        {
            _jobPostionAppService.DeleteJobPosition(id);
            return RedirectToAction("GetAllPosition", "Admin");
        }


        [HttpGet]
        public IActionResult CreateQuestion()
        {
            ViewBag.types = _questionAppService.GetQuestionTypes();
            ViewBag.positions = _jobPostionAppService.GetAllJobPositions();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateQuestion([Bind("QuestionTypeId,QuestionBodyText,Answers , PositionsId")] CreateQuestionModel questionModel)
        {         
            ViewBag.types = _questionAppService.GetQuestionTypes();
            ViewBag.positions = _jobPostionAppService.GetAllJobPositions();
            if (ModelState.IsValid)
            {
                try
                {
                    if (questionModel.Answers.Count == 0)
                    {
                        ModelState.AddModelError("", "No Answers Added For Question");
                        return View(questionModel);
                    }

                    foreach (var item in questionModel.Answers)
                    {
                        if (item.AnswerBodyText == null)
                        {
                            ModelState.AddModelError("", " Answers Is Empty");
                            return View(questionModel);
                        }
                    }

                    var questionType = _questionAppService.GetQuestionTypeByID(questionModel.QuestionTypeId);
                    if (questionModel.Answers.Count > questionType.AnswersCapcity || questionModel.Answers.Count < 4)
                    {
                        ModelState
                            .AddModelError("", $"this is {questionType.Type} question and be must has {questionType.AnswersCapcity} answers");
                    }

                    var newQuestion = _questionAppService.CreateNewQuestion(questionModel);
                    foreach (var answer in questionModel.Answers)
                    {
                        answer.QuestionId = newQuestion.ID;
                        _questionAppService.AddAnswerToQuestion(answer);
                    }

                    foreach (var positionId in questionModel.PositionsId)
                    {
                        _jobPostionAppService.AssignQuestionToPosition(positionId, newQuestion.ID);
                    }

                    return RedirectToAction("GetAllQuestuion");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(questionModel);
                }
            }
            return View(questionModel);
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult AddAnswer([Bind("Answers")] CreateQuestionModel question)
        {
            question.Answers.Add(new CreateQuestionAnswerModel());
            return PartialView("CreateQuestionAnswerModel", question);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult RemoveAnswer([Bind("Answers")] CreateQuestionModel question)
        {
            question.Answers.Remove(question.Answers[question.NumberOfAnswer - 1]);
            return PartialView("CreateQuestionAnswerModel", question);
        }

        public IActionResult GetAllQuestuion()
        {
            var questions = _questionAppService.GetAllQuestionWithType();
            return View(questions);
        }

        [HttpGet]
        public IActionResult DeleteOuestion(int id)
        {
            _questionAppService.DeleteQuestion(id);
            return RedirectToAction("GetAllQuestuion", "Admin");
        }
    }
}