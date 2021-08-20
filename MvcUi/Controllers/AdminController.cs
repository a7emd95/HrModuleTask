using Core.Interfaces.AppServices;
using Core.Models.JobPosition;
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

        public AdminController(IJobPostionAppService jobPostionAppService)
        {
            _jobPostionAppService = jobPostionAppService;
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


    }
}
