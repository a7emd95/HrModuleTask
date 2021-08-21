using Core.Interfaces.AppServices;
using Core.Models.JobPosition;
using Core.Models.Question;
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


        public IActionResult CreateJobPosition()
        {
            return View();
        }

        [HttpPost]
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
                    ViewBag.questionId = result.PublicId ;
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
    }
}