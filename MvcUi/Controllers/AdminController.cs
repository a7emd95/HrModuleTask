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
            ViewBag.isAdded = false;
            ViewBag.questionId = 0;
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateQuestion(CreateQuestionModel question)
        {
            ViewBag.types = _questionAppService.GetQuestionTypes();
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _questionAppService.CreateNewQuestion(question);
                    if (result == null)
                    {
                        ModelState.AddModelError("", "Question not Created");
                        ViewBag.isAdded = false;
                        ViewBag.questionId = 0;
                        return View(question);
                    }
                    ViewBag.isAdded = true;
                    ViewBag.questionId = result.ID;
                    return View();
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.questionId = 0;
                    ViewBag.isAdded = false;
                    return View();
                }

            }
            ViewBag.isAdded = false;
            ViewBag.questionId = 0;
            return View(question);
        }

        public IActionResult AddAnswerToQuestion(int? questionId)
        {
            ViewBag.isAnswerAdded = false;
            if (questionId != null)
            {
                ViewBag.qstId = questionId;
            }
            else
            {
                ViewBag.qstId = 0;
            }
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult AddAnswerToQuestion(CreateQuestionAnswerModel answer)
        {
            ViewBag.qstId = answer.QuestionId;

            if (ModelState.IsValid)
            {
                try
                {
                    _questionAppService.AddAnswerToQuestion(answer);
                    ViewBag.isAnswerAdded = true;
                    return View(new CreateQuestionAnswerModel() { AnswerBodyText = "", IsCorrect = false, QuestionId = answer.QuestionId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.isAnswerAdded = false;
                    return View(answer);

                }

            }
            ViewBag.isAnswerAdded = false;
            return View(answer);
        }

        //public IActionResult AssignQuestionToAnswer(int? questionId)
        //{
        //   
        //    if (questionId != null)
        //    {
        //        ViewBag.qstId = questionId;
        //    }
        //    else
        //    {
        //        ViewBag.qstId = 0;
        //    }
        //    return View();
        //}

        public IActionResult AssignQuestionToPosition()
        {
            ViewBag.positions = _jobPostionAppService.GetAllJobPositions();

            return View();
        }
    }
}