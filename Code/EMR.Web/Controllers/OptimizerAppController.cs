using Microsoft.AspNetCore.Mvc;
using OptimizerApp.Models;
using Microsoft.AspNetCore.Http;
using MediatR;
using AutoMapper;
using OptimizerApp.Infrastructure;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace OptimizerApp.Controllers
{
    public class OptimizerAppController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
/*        EstimationService estimateSvc = new EstimationService();
        OptimizationService optimizationService = new OptimizationService();
        DoctorService doctorService = new DoctorService();
        PatientService patientService = new PatientService();*/

        public OptimizerAppController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _mediator.Send(new GetUserDetailsRequestModel { Name = HttpContext.Session.GetString("email") });
            return View(user.Result);
        }

        [Authorize]
        public IActionResult Read()
        {
            /* var model = new OptimizationModel();
             var SpecialtyList = Common.SpecialtyList;
             model.SpecialtyList = SpecialtyList;
             return View(model);*/

            return View(null);
        }

        
        [Authorize]
        public IActionResult Result(OptimizationModel optimizationModel)
        {
            /*try
            {
                //retrieve estimate rows from database
                var estimates = estimateSvc.GetEstimatesBySpecialty(optimizationModel.SelectedSpecialty);

                var model = new OptimizationResult();

                //call gurobi optimization backend
                var optimizationResult = optimizationService.Optimize(estimates);

                //get doctor/patient dictionary
                var dict = optimizationResult.Item1;

                var optimizationResModel = new OptimizationResult();

                //format the time taken
                TimeSpan time = TimeSpan.FromMinutes(optimizationResult.Item2);

                //here backslash is must to tell that colon is
                //not the part of format, it just a character that we want in output
                optimizationResModel.TotalTime = time.ToString(@"hh\:mm");

                optimizationResModel.OptimizationResultRows = new List<OptimizationResultRow>();

                //re-import dictionary into a list of doctor/patient pairs
                foreach (var doctorId in dict.Keys)
                {
                    var patientId = dict[doctorId];

                    var optimizationResultRow = new OptimizationResultRow();
                    optimizationResultRow.DoctorName = "Dr." + doctorService.GetDoctor(doctorId).FirstName + " " + doctorService.GetDoctor(doctorId).LastName;
                    optimizationResultRow.PatientName = patientService.GetPatient(patientId).FirstName + " " + patientService.GetPatient(patientId).LastName;

                    optimizationResModel.OptimizationResultRows.Add(optimizationResultRow);

                }

                //return result for display
                return View(optimizationResModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error");
            }*/

            return RedirectToAction("Error");
        }

        
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("key");
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}