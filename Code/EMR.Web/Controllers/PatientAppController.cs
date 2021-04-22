using Microsoft.AspNetCore.Mvc;
using EMR.Models;
using Microsoft.AspNetCore.Http;
using MediatR;
using AutoMapper;
using EMR.Infrastructure;
using System.Collections.Generic;
using PatientService;
using Services;
using System.Threading.Tasks;
using System.Text.Json;
using System;

namespace EMR.Controllers
{
    public class PatientAppController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        UserService PatientSvc = new UserService();

        public PatientAppController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Index action
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.message = message;
            }

            string privateKey = HttpContext.Session.GetString("key");
            Patient patient = await new UserService().GetPatient(privateKey).ConfigureAwait(false);

            //var user = _mediator.Send(new GetUserDetailsRequestModel { Name = patient.Name });

            var response = new GetUserDetailsResponseModelResult() { Name = patient.Name, Key = privateKey };

            return View(response);
        }      

        /// <summary>
        /// Patient edit action
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            string privateKey = HttpContext.Session.GetString("key");
            var patient = await PatientSvc.GetPatient(privateKey).ConfigureAwait(false);

            var model = new PatientModel()
            {
                Name = patient.Name,
                Hospital = patient.Hospital,
                VisitReason = patient.VisitReason,
                ResidentialAddress = patient.ResidentialAddress,
                PostalAddress = patient.PostalAddress,
                ContactNumber = patient.ContactNumber,
                Allergies = patient.Allergies,
                Age = patient.Age,
                CurrentProblems = patient.CurrentProblems,
                Education = patient.Education,
                Employer = patient.Employer,
                FamilyHistory = patient.FamilyHistory,
                Gender = patient.Gender,
                Insurance = patient.Insurance,
                Medications = patient.Medications,
                PastProblems = patient.PastProblems
            };

            return View(model);
        }

        /// <summary>
        /// Action to save patient data
        /// </summary>
        /// <param name="mPatient"></param>
        /// <returns></returns>
        [Authorize]
        [System.Web.Http.HttpPost]
        public async Task<IActionResult> Edit(PatientModel mPatient)
        {
            string privateKey = HttpContext.Session.GetString("key");
            Patient patient = await new UserService().GetPatient(privateKey).ConfigureAwait(false);

            patient.Name = mPatient.Name;
            patient.Hospital = mPatient.Hospital;
            patient.MedicalCondition = mPatient.VisitReason;
            patient.VisitReason = mPatient.VisitReason;
            patient.ResidentialAddress = mPatient.ResidentialAddress;
            patient.Allergies = mPatient.Allergies;
            patient.Age = mPatient.Age;
            patient.ContactNumber = mPatient.ContactNumber;
            patient.PostalAddress = mPatient.PostalAddress;
            patient.CurrentProblems = mPatient.CurrentProblems;
            patient.Education = mPatient.Education;
            patient.Employer = mPatient.Employer;
            patient.FamilyHistory = mPatient.FamilyHistory;
            patient.Gender = mPatient.Gender;
            patient.ContactNumber = mPatient.ContactNumber;
            patient.PostalAddress = mPatient.PostalAddress;
            patient.Insurance = mPatient.Insurance;
            patient.Medications = mPatient.Medications;
            patient.PastProblems = mPatient.PastProblems;

            if(patient.MedicalCondition == null)
            {
                patient.MedicalCondition = "N/A";
            }
            if (patient.VisitReason == null)
            {
                patient.VisitReason = "N/A";
            }

            await PatientSvc.SavePatient(patient, privateKey).ConfigureAwait(false);

            return RedirectToAction("Index", new { message = "Profile Saved Successfully!" });
        }

        /// <summary>
        /// Visit ask action
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> VisitAsk()
        {
            var visitAskModel = new VisitRequestModel() { SpecialtyList = EMR.Infrastructure.Common.SpecialtyList, DoctorList = new List<AddressDoctorMap>() };

            string privateKey = HttpContext.Session.GetString("key");
            var doctors = await PatientSvc.GetDoctorList(privateKey).ConfigureAwait(false);

            string jsonString = JsonSerializer.Serialize(doctors);
            HttpContext.Session.SetString("List", jsonString);


            return View(visitAskModel);
        }

        /// <summary>
        /// Retreiving list of doctors
        /// </summary>
        /// <param name="speciality"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetDoctors(string speciality)
        {
            string privateKey = HttpContext.Session.GetString("key");

            List<Doctor> doctors = null;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("List")))
                doctors = JsonSerializer.Deserialize<List<Doctor>>(HttpContext.Session.GetString("List"));
            else
                doctors = await PatientSvc.GetDoctorList(privateKey).ConfigureAwait(false);                

            doctors = doctors.FindAll(d => d.Speciality.Equals(speciality));

            var doctorList = new List<AddressDoctorMap>();
            foreach (Doctor doctor in doctors)
            {
                doctorList.Add(new AddressDoctorMap() { Address = doctor.Address, Name = doctor.Name });
            }

            if(doctors.Count == 0)
            {
                doctorList.Add(new AddressDoctorMap() { Address = null, Name = "Not Available" });
            }

            return new JsonResult(doctorList);
        }

        /// <summary>
        /// Saving visit ask request
        /// </summary>
        /// <param name="visitRequestModel"></param>
        /// <returns></returns>
        [Authorize]
        [System.Web.Http.HttpPost]
        public async Task<IActionResult> VisitAsk(VisitRequestModel visitRequestModel)
        {
            string privateKey = HttpContext.Session.GetString("key");
            var doctor = await PatientSvc.GetDoctor(privateKey, visitRequestModel.Doctor).ConfigureAwait(false);

            var patient = await PatientSvc.GetPatient(privateKey).ConfigureAwait(false);

            List<VisitRequestDetailsModel> visitRequestDetailsModels = new List<VisitRequestDetailsModel>();
            if (!string.IsNullOrEmpty(patient.VisitReason) && !patient.VisitReason.Equals("N/A"))
                visitRequestDetailsModels = JsonSerializer.Deserialize<List<VisitRequestDetailsModel>>(patient.VisitReason);

            VisitRequestDetailsModel visitRequestDetailsModel = new VisitRequestDetailsModel()
            {
                Address = doctor.Address,
                Date = DateTime.Now,
                VisitReason = visitRequestModel.VisitReason
            };

            visitRequestDetailsModels.Add(visitRequestDetailsModel);

            patient.VisitReason = JsonSerializer.Serialize(visitRequestDetailsModels);

            await PatientSvc.SavePatient(patient, privateKey).ConfigureAwait(false);

             await PatientSvc.ShareWithDoctor(patient, doctor).ConfigureAwait(false);

            return RedirectToAction("Index", new { message = "Visit Requested Successfully!" });
        }

        
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("key");
            return RedirectToAction("Index", "Home");
        }

    }
}