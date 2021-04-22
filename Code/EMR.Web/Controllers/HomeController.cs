using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EMR.Models;
using MediatR;
using PatientService;
using Services;
using System.Configuration;

namespace EMR.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private UserService userService = new UserService();

        public HomeController(IMediator mediator)
        {            
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RegisterSplit()
        {
            return View();
        }

        /// <summary>
        /// Display patient data form
        /// </summary>
        /// <returns></returns>
        public IActionResult RegisterPatient()
        {
            var model = new PatientModel() { Gender = "Male" };

            return View(model);
        }

        /// <summary>
        /// Saves new patient
        /// </summary>
        /// <param name="patientModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterPatient(PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                if (!patientModel.Password.Equals(patientModel.ConfirmPassword))
                {
                    TempData["error"] = "Password and confirm password do not match";
                    return View(patientModel);
                }

                var patient = new Patient()
                {
                    Name = patientModel.Name,
                    Password = patientModel.Password,
                    VisitReason = "N/A",
                    MedicalCondition = "N/A",
                    Hospital = patientModel.Hospital,
                    ResidentialAddress = patientModel.ResidentialAddress,
                    Allergies = patientModel.Allergies,
                    Age = patientModel.Age,
                    CurrentProblems = patientModel.CurrentProblems,
                    Education = patientModel.Education,
                    Employer = patientModel.Employer,
                    FamilyHistory = patientModel.FamilyHistory,
                    Gender = patientModel.Gender,
                    PostalAddress = patientModel.PostalAddress,
                    ContactNumber = patientModel.ContactNumber,
                    Insurance = patientModel.Insurance,
                    Medications = patientModel.Medications,
                    PastProblems = patientModel.PastProblems
                };

                var key = await userService.RegisterPatient(patient).ConfigureAwait(false);

                HttpContext.Session.SetString("key", key);
                return RedirectToAction("Index", "PatientApp");
            }
            else
            {
                return View(patientModel);
            }

        }

        /// <summary>
        /// Display doctor form
        /// </summary>
        /// <returns></returns>
        public IActionResult RegisterDoctor()
        {
            var model = new DoctorModel();
            model.SpecialtyList = Infrastructure.Common.SpecialtyList;
            return View(model);
        }

        /// <summary>
        /// Saves new doctor
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(DoctorModel doctor)
        {
            if (ModelState.IsValid)
            {
                doctor.SpecialtyList = Infrastructure.Common.SpecialtyList;

                if (!doctor.Password.Equals(doctor.ConfirmPassword))
                {
                    TempData["error"] = "Password and confirm password do not match";
                    return View(doctor);
                }
                else if(!doctor.VerificationCode.Equals(ConfigurationManager.AppSettings["DoctorVerificationCode"]))
                {
                    TempData["error"] = "Registration code is invalid";
                    return View(doctor);
                }

                var dbDoctor = new Doctor()
                {
                    Name = doctor.Name,
                    Password = doctor.Password,
                    Speciality = doctor.Specialty,
                    ContactNumber = doctor.ContactNumber,
                    Hospital = doctor.Hospital,
                    Keys = "||"
                };

                var key = await userService.RegisterDoctor(dbDoctor).ConfigureAwait(false);

                HttpContext.Session.SetString("key", key);
                return RedirectToAction("Index", "DoctorApp");
            }
            else
            {
                return View(doctor);
            }

        }

        /// <summary>
        /// Login action
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(EMR.Models.User user)
        {
            var userService = new UserService();

            bool validLogin = await userService.LoginPatient(user.Key, user.Password).ConfigureAwait(false);

            HttpContext.Session.SetString("List", "");

            if (validLogin)
            {
                HttpContext.Session.SetString("key", user.Key);
                return RedirectToAction("Index", "PatientApp");
            }
            else
            {
                validLogin = await userService.LoginDoctor(user.Key, user.Password).ConfigureAwait(false);

                if (validLogin)
                {
                    HttpContext.Session.SetString("key", user.Key);
                    return RedirectToAction("Index", "DoctorApp");
                }
                else
                {
                    ViewData["Error"] = "Invalid Details";
                    return View();
                }
            }
        }

        public IActionResult Register()
        {
            return View();
        }  


        public IActionResult InvalidSession()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
