using Core.Interfaces.AppServices;
using Core.Models.JobPosition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUi.Controllers
{
    public class JobPositionController : Controller
    {
        private readonly IJobPostionAppService _jobPostionAppService;

        public JobPositionController(IJobPostionAppService jobPostionAppService)
        {
            _jobPostionAppService = jobPostionAppService;
        }
        // GET: JobPositionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobPositionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobPositionController/CreateJobPosition
        [HttpGet]
        public ActionResult CreateJobPosition()
        {
            return View();
        }

        // POST: JobPositionController/CreateJobPosition
        [HttpPost]   
        [AutoValidateAntiforgeryToken]
        public ActionResult CreateJobPosition(CreateJobPositionModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _jobPostionAppService.CreateNewJobPosition(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }
            }
            return View(model);
        }

        // GET: JobPositionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobPositionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            

        }

        // GET: JobPositionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobPositionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
