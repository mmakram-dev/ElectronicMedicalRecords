using Microsoft.AspNetCore.Mvc;
using OptimizerApp.Models;
using Microsoft.AspNetCore.Http;
using MediatR;
using AutoMapper;
using OptimizerApp.Infrastructure;
using System.Collections.Generic;

namespace OptimizerApp.Controllers
{
    public class EstimationAppController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
       /* DoctorService doctorSvc = new DoctorService();
        PatientService patientService = new PatientService();
        EstimationService estimationService = new EstimationService();*/

        public EstimationAppController(IMediator mediator, IMapper mapper)
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
        public IActionResult Filter()
        {
            var model = new FilterModel();
            //model.SpecialtyList = Common.SpecialtyList;
            model.DoctorModels = new List<DoctorModel>();

            return View(model);
        }

        
        /// <summary>
        /// Get list of doctors
        /// </summary>
        /// <param name="speciality"></param>
        /// <returns></returns>
        [Authorize]
        public IActionResult GetDoctors(string speciality)
        {
            /*  var dbDctors = doctorSvc.GetDoctorsBySpecialty(speciality);

              var doctors = _mapper.Map<List<Doctor>, List<DoctorModel>>(dbDctors);

              return new JsonResult(doctors);*/

            return new JsonResult(null);
        }

        /// <summary>
        /// Prepare the list of estimates for user to fill
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult Estimate(FilterModel filter)
        {
           /* var model = new DoctorEstimateModel();
            model.PatientEstimateModels = new List<PatientEstimateModel>();
            var dbEstimates = new EstimationService().GetEstimatesListByDoctorID(filter.SelectedDoctorID);

            //retrieve the associated doctor from DB
            var doctor = doctorSvc.GetDoctor(filter.SelectedDoctorID);

            var patientsList = patientService.GetPatientsBySpecialtyNeeded(doctor.Specialty);

            foreach(var patient in patientsList)
            {
                //if there is no doctor/patient pair then insert it as a placeholder
                if(dbEstimates.Find(e => e.PatientId == patient.PatientId) == null)
                {
                    var estimate = new Estimate() { DoctorId = filter.SelectedDoctorID, PatientId = patient.PatientId, ExaminationTime = 0 };

                    doctor.Estimates.Add(estimate);
                    dbEstimates.Add(estimate);
                }

            }

            //save new estimations
            doctorSvc.Update(doctor);

            //loop over DB estimations and prepare the model
            foreach (var dbEstimate in dbEstimates)
            {
                if(dbEstimate.Patient == null)
                {
                    dbEstimate.Patient = patientService.GetPatient(dbEstimate.PatientId);
                }

                var patientEstimateModel = new PatientEstimateModel()
                { PatientID = dbEstimate.PatientId, 
                    PatientName = dbEstimate.Patient.FirstName + " " + dbEstimate.Patient.LastName, 
                    DoctorName = doctor.FirstName + " " + doctor.LastName, 
                    DoctorID = doctor.DoctorId,
                    ExaminationTime = dbEstimate.ExaminationTime
                };

                model.PatientEstimateModels.Add(patientEstimateModel);
            }

            return View(model.PatientEstimateModels);*/

            return View(null);
        }

        /// <summary>
        /// Save estimation into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public IActionResult Save(List<PatientEstimateModel> model)
        {
           /* var doctorId = model[0].DoctorID;
            var dbEstimates = new EstimationService().GetEstimatesListByDoctorID(doctorId);

            //retrieve fresh version from DB to attach with entity framework context
            foreach(var estimateModel in model)
            {
                var dbEstimator = dbEstimates.Find(e => e.PatientId == estimateModel.PatientID);

                dbEstimator.ExaminationTime = estimateModel.ExaminationTime;
                estimationService.Save(dbEstimator);
            }*/


            return RedirectToAction("Filter");
        }
       
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("Index", "Home");
        }

    }
}