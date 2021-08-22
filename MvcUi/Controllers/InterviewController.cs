using Core.Interfaces.AppServices;
using Core.Models.Candidate;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUi.Controllers
{
    public class InterviewController : Controller
    {
        private readonly ICandidateAppService _candidateAppService;
        private readonly IJobPostionAppService _jobPostionAppService;

        public IActionResult Index()
        {
            return View();
        }

        public InterviewController(ICandidateAppService candidateAppService, IJobPostionAppService jobPostionAppService)
        {
            this._candidateAppService = candidateAppService;
            this._jobPostionAppService = jobPostionAppService;
        }

        public IActionResult CreateCandidate()
        {
            ViewBag.jopPositions = _jobPostionAppService.GetAllActiveJobPosition();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
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

        public IActionResult GetAllCandidates()
        {
            return View(_candidateAppService.GetAllCandidate());
        }

        public IActionResult DeleteCandidate(int id)
        {
            _candidateAppService.DeleteCandidate(id);
            return RedirectToAction("GetAllCandidates");
        }

    }
}
