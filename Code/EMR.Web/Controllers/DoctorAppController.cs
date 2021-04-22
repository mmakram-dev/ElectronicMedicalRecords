using Microsoft.AspNetCore.Mvc;
using EMR.Models;
using Microsoft.AspNetCore.Http;
using MediatR;
using AutoMapper;
using EMR.Infrastructure;
using Services;
using PatientService;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json;

namespace EMR.Controllers
{
    public class DoctorAppController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        UserService PatientSvc = new UserService();

        public DoctorAppController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        public async Task<IActionResult> Index(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.message = message;
            }

            string privateKey = HttpContext.Session.GetString("key");
            var doctor = await new UserService().GetDoctor(privateKey).ConfigureAwait(false);

            var response = new GetUserDetailsResponseModelResult() { Name = doctor.Name, Key = privateKey };

            HttpContext.Session.SetString("name", doctor.Name);

            return View(response);
        }

        [Authorize]
        public IActionResult AddDoctor()
        {
            var model = new DoctorModel();
            return View(model);
        }

        /// <summary>
        /// Adding doctor
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]       
        public async Task<IActionResult> AddDoctor(DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                var dbDoctor = new Doctor() {
                    Name = doctor.Name,
                    Speciality = doctor.Specialty };

                var key = await PatientSvc.RegisterDoctor(dbDoctor).ConfigureAwait(false);

                return RedirectToAction("ViewAll");
            }
            else
            {
                return View(doctor);
            }

        }

        /// <summary>
        /// List my patients
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> ViewAll(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.message = message;
            }
            string privateKey = HttpContext.Session.GetString("key");
            var doctor = await PatientSvc.GetDoctor(privateKey).ConfigureAwait(false);

            var patientList = await PatientSvc.GetMyPatients(privateKey).ConfigureAwait(false);

            var modelList = new List<PatientModel>();
            foreach(Patient patient in patientList)
            {

                List<VisitRequestDetailsModel> visitRequestDetailsModels = JsonSerializer.Deserialize<List<VisitRequestDetailsModel>>(patient.VisitReason);
                visitRequestDetailsModels = visitRequestDetailsModels.FindAll(v => v.Address.Equals(doctor.Address, StringComparison.InvariantCultureIgnoreCase));

                var lastModel = visitRequestDetailsModels.ToList().OrderByDescending(p => p.Date).FirstOrDefault();

                modelList.Add(new PatientModel()
                {
                    Name = patient.Name,
                    VisitReason = lastModel.VisitReason,
                    RequestDate = lastModel.Date,
                    Key = patient.Key
                });
            }

            return View(modelList);         
        }

        /// <summary>
        /// Editing patient
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditPatient(string Key)
        {
            string privateKey = HttpContext.Request.Path.Value.Split('/')[3];
            var patient = await PatientSvc.GetPatient(privateKey).ConfigureAwait(false);

            var model = new EditPatientModel()
            {
                Name = patient.Name,
                Hospital = patient.Hospital,
                ResidentialAddress = patient.ResidentialAddress,
                Allergies = patient.Allergies,
                Age = patient.Age,
                CurrentProblems = patient.CurrentProblems,
                Education = patient.Education,
                Employer = patient.Employer,
                FamilyHistory = patient.FamilyHistory,
                Gender = patient.Gender,
                ContactNumber = patient.ContactNumber,
                PostalAddress = patient.PostalAddress,
                Insurance = patient.Insurance,
                Medications = patient.Medications,
                PastProblems = patient.PastProblems,
                Key = privateKey,
                PatientCommentModels = GetComemnts(patient.MedicalCondition)
            };

            return View(model);
        }

        /// <summary>
        /// Retrieve comments listed on patient
        /// </summary>
        /// <param name="fullComments"></param>
        /// <returns></returns>
        private List<PatientCommentModel> GetComemnts(string fullComments)
        {
            List<PatientCommentModel> patientCommentModels = new List<PatientCommentModel>();
            if (string.IsNullOrEmpty(fullComments))
                return patientCommentModels;

            string[] commentsArr = fullComments.Split("||", System.StringSplitOptions.RemoveEmptyEntries);

            if(commentsArr.Length > 1)
            {
                for(int i = 0; i < commentsArr.Length; i++)
                {
                    string[] parts = commentsArr[i].Split("|");

                    if (parts.Length < 3)
                        continue;

                    var comment = new PatientCommentModel()
                    {
                        DoctorName = parts[0],
                        Date = DateTime.Parse(parts[1]),
                        Text = parts[2]
                    };
                    patientCommentModels.Add(comment);
                }
            }

            patientCommentModels = patientCommentModels.ToList().OrderByDescending(p => p.Date).ToList();

            return patientCommentModels;
        }

        /// <summary>
        /// Editing patient
        /// </summary>
        /// <param name="mEditPatient"></param>
        /// <returns></returns>
        [Authorize]
        [System.Web.Http.HttpPost]
        public async Task<IActionResult> EditPatient(EditPatientModel mEditPatient)
        {
            var patient = await PatientSvc.GetPatient(mEditPatient.Key).ConfigureAwait(false);

            patient.MedicalCondition = patient.MedicalCondition + "||" +
                HttpContext.Session.GetString("name") +
                "|" +  DateTime.Now +            
                "|" +  mEditPatient.MedicalCondition;

            await PatientSvc.SavePatient(patient, mEditPatient.Key).ConfigureAwait(false);

            return RedirectToAction("ViewAll", new { message = "Notes Added Successfully!" });
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            string privateKey = HttpContext.Session.GetString("key");
            var doctor = await PatientSvc.GetDoctor(privateKey).ConfigureAwait(false);

            var model = new DoctorModel()
            {
                Name = doctor.Name,
                Hospital = doctor.Hospital,
                ContactNumber = doctor.ContactNumber,
                Specialty = doctor.Speciality,
                SpecialtyList = EMR.Infrastructure.Common.SpecialtyList
            };

            return View(model);
        }

        [Authorize]
        [System.Web.Http.HttpPost]
        public async Task<IActionResult> Edit(DoctorModel mDoctor)
        {
            string privateKey = HttpContext.Session.GetString("key");
            var doctor = await new UserService().GetDoctor(privateKey).ConfigureAwait(false);

            doctor.Name = mDoctor.Name;
            doctor.Hospital = mDoctor.Hospital;
            doctor.ContactNumber = mDoctor.ContactNumber;
            doctor.Speciality = mDoctor.Specialty;         

            await PatientSvc.SaveDoctor(doctor, privateKey).ConfigureAwait(false);

            return RedirectToAction("Index", new { message = "Profile Saved Successfully!" });
        }
        
        
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("key");
            return RedirectToAction("Index", "Home");
        }

    }
}