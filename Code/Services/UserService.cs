using Services;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PatientService
{
    public class UserService
    {
        private string url = ConfigurationManager.AppSettings["NetworkURL"];

        /// <summary>
        /// Register patient to blockchain
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public async Task<string> RegisterPatient(Patient patient)
        {
            string privateKey = KeyService.GetNextkey();

            var account = new Account(privateKey);

            var web3 = new Web3(account, url);

            var service = BlockchainFactory.GetPatientService(web3);

            var receiptForSetFunctionCall = await service.CreateRequestAndWaitForReceiptAsync
               (new EthereumSmartContracts.Contracts.PatientContract.ContractDefinition.CreateFunction()
               {
                   Add = account.Address,
                   Name = patient.Name,
                   Hospital = patient.Hospital,
                   VisitReason = patient.VisitReason,
                   Password = patient.Password,
                   MedicalCondition = patient.MedicalCondition,                   
                   Gas = 200000
               });

            var receiptForSetFunctionCall2 = await service.CreateInfoRequestAndWaitForReceiptAsync
               (new EthereumSmartContracts.Contracts.PatientContract.ContractDefinition.CreateInfoFunction()
               {
                   Add = account.Address,
                   Age = patient.Age,
                   Eduction = patient.Education,
                   Employer = patient.Employer,
                   Insurance = patient.Insurance,
                   Gender = patient.Gender,
                   ContactNumber = patient.ContactNumber,
                   PostalCode = patient.PostalAddress,
                   ResidentialAddress = patient.ResidentialAddress,
                   Gas = 200000
               });

            var receiptForSetFunctionCall3 = await service.CreateMedicsRequestAndWaitForReceiptAsync
               (new EthereumSmartContracts.Contracts.PatientContract.ContractDefinition.CreateMedicsFunction()
               {
                   Add = account.Address,
                   Allergies = patient.Allergies,
                   CurrentProblems = patient.CurrentProblems,
                   FamilyHistory = patient.FamilyHistory,
                   Medications = patient.Medications,
                   PastProblems = patient.PastProblems,
                   Gas = 200000
               });

            return privateKey;
        }


        /// <summary>
        /// Register doctor to blockchain
        /// </summary>
        /// <param name="doctor"></param>
        /// <returns></returns>
        public async Task<string> RegisterDoctor(Doctor doctor)
        {
            string privateKey = KeyService.GetNextkey();

            var account = new Account(privateKey);

            var web3 = new Web3(account, url);

            var service = BlockchainFactory.GetDoctorService(privateKey);

            try
            {
                var receiptForSetFunctionCall = await service.CreateRequestAndWaitForReceiptAsync
                   (new EthereumSmartContracts.Contracts.DoctorContract.ContractDefinition.CreateFunction()
                   {
                       Add = account.Address,
                       Name = doctor.Name,
                       Hospital = doctor.Hospital,
                       ContactNumber = doctor.ContactNumber,
                       Specialty = doctor.Speciality,
                       Password = doctor.Password,
                       Keys = doctor.Keys,
                       Gas = 500000
                   });
            }catch(Exception ex)
            {
                throw;
            }

            return privateKey;
        }

        /// <summary>
        /// Validate paitent login
        /// </summary>
        /// <param name="key"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> LoginPatient(string key, string password)
        {
            var patient = await GetPatient(key);

            return patient.Password.Equals(password);
        }

        /// <summary>
        /// Validate doctor login
        /// </summary>
        /// <param name="key"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> LoginDoctor(string key, string password)
        {
            var doctor = await GetDoctor(key);

            return doctor.Password.Equals(password);
        }

        /// <summary>
        /// Read patient details
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="includeComments"></param>
        /// <returns></returns>
        public async Task<Patient> GetPatient(string privateKey, bool includeComments = false)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, url);

            var service = BlockchainFactory.GetPatientService(web3);

            var data = await service.ReadQueryAsync(account.Address);
            var info = await service.ReadInfoQueryAsync(account.Address);
            var medics = await service.ReadMedicsQueryAsync(account.Address);

            var patient = new Patient()
            {
                Name = data.Name,
                VisitReason = data.VisitReason,
                Hospital = data.Hospital,
                Password = data.Password,
                Address = account.Address,
                MedicalCondition = data.MedicalCondition,
                ContactNumber = info.ContactNumber,
                PostalAddress = info.PostalCode,
                Age = info.Age,
                ResidentialAddress = info.ResidentialAddress,
                PastProblems = medics.PastProblems,
                Medications = medics.Medications,
                Gender = info.Gender,
                Allergies = medics.Allergies,
                CurrentProblems = medics.CurrentProblems,
                Education = info.Eduction,
                Employer = info.Employer,
                FamilyHistory = medics.FamilyHistory,
                Insurance = info.Insurance,

                Key = privateKey
            };         

            return patient;
        }


        /// <summary>
        /// Save paitent to blockchain
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public async Task<bool> SavePatient(Patient patient, string privateKey)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, url);

            var service = BlockchainFactory.GetPatientService(web3);

            var receiptForSetFunctionCall = await service.UpdateRequestAndWaitForReceiptAsync
               (new EthereumSmartContracts.Contracts.PatientContract.ContractDefinition.UpdateFunction()
               {
                   Add = account.Address,
                   Name = patient.Name,
                   Hospital = patient.Hospital,
                   VisitReason = patient.VisitReason,
                   Password = patient.Password,
                   MedicalCondition = patient.MedicalCondition,
                   Gas = 300000
               });

            var receiptForSetFunctionCall2 = await service.UpdateInfoRequestAndWaitForReceiptAsync
               (new EthereumSmartContracts.Contracts.PatientContract.ContractDefinition.UpdateInfoFunction()
               {
                   Add = account.Address,
                   Age = patient.Age,
                   Insurance = patient.Insurance,
                   ContactNumber = patient.ContactNumber,
                   PostalCode = patient.PostalAddress,
                   Employer = patient.Employer,
                   Eduction = patient.Education,
                   ResidentialAddress = patient.ResidentialAddress,
                   Gender = patient.Gender,

                   Gas = 400000
               });

            var receiptForSetFunctionCall3 = await service.UpdateMedicsRequestAndWaitForReceiptAsync
              (new EthereumSmartContracts.Contracts.PatientContract.ContractDefinition.UpdateMedicsFunction()
              {
                  Add = account.Address,
                  FamilyHistory = patient.FamilyHistory,
                  Allergies = patient.Allergies,
                  CurrentProblems = patient.CurrentProblems,
                  Medications = patient.Medications,
                  PastProblems = patient.PastProblems,

                  Gas = 400000
              });

            return true;
        }

        public async Task<bool> AddCommentToPatient(PatientComment patientComment, string privateKey)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, url);

            var service = BlockchainFactory.GetPatientService(web3);

            var receiptForSetFunctionCall = await service.AddCommentRequestAsync
               (new EthereumSmartContracts.Contracts.PatientContract.ContractDefinition.AddCommentFunction()
               {
                   Add = account.Address,
                   DoctorName = patientComment.DoctorName,
                   Date = patientComment.Date,
                   Text = patientComment.Text,
                   Gas = 200000
               });

            return true;
        }

        /// <summary>
        /// Get doctor by key
        /// </summary>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        public async Task<Doctor> GetDoctor(string privateKey)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, url);

            return await GetDoctor(privateKey, account.Address);
        }

        /// <summary>
        /// Get doctor by key and address
        /// </summary>
        /// <param name="privateKey"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public async Task<Doctor> GetDoctor(string privateKey, string address)
        {
            var service = BlockchainFactory.GetDoctorService(privateKey);
            var data = await service.ReadQueryAsync(address);

            var doctor = new Doctor()
            {
                Name = data.Name,
                Hospital = data.Hospital,
                Password = data.Password,
                Speciality = data.Specialty,
                ContactNumber = data.ContactNumber,
                Keys = data.Keys,
                Address = address,
                Key = privateKey            
            };

            return doctor;
        }

        public async Task<bool> SaveDoctor(Doctor doctor, string privateKey)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, url);

            var service = BlockchainFactory.GetDoctorService(privateKey);

            var data = await service.ReadQueryAsync(account.Address);

            var receiptForSetFunctionCall = await service.UpdateRequestAndWaitForReceiptAsync
               (new EthereumSmartContracts.Contracts.DoctorContract.ContractDefinition.UpdateFunction()
               {
                   Add = account.Address,
                   Name = doctor.Name,
                   Hospital = doctor.Hospital,
                   Specialty = doctor.Speciality,
                   ContactNumber = doctor.ContactNumber,
                   Password = doctor.Password,
                   Keys = data.Keys,
                   Gas = 400000
               });

            return true;
        }

        public async Task<TransactionReceipt> ShareWithDoctor(Patient patient, Doctor doctor)
        {
            var service = BlockchainFactory.GetDoctorService(doctor.Key);

            if (!doctor.Keys.Contains(patient.Key))
                return await service.AddPatientRequestAndWaitForReceiptAsync(doctor.Address, patient.Key);
            else
                return null;

        }

        public async Task<List<Doctor>> GetDoctorList(string privateKey)
        {
            var list = new List<Doctor>();
            var service = BlockchainFactory.GetDoctorService(privateKey);

            for (int i = 0; i < 20; i++)
            {
                var doctorAddress = await service.FindQueryAsync(i);

                if (!doctorAddress.Contains("000000"))
                {
                    var doctor = await GetDoctor(privateKey, doctorAddress);

                    list.Add(doctor);
                }
            }

            return list;

        }

        public async Task<List<Patient>> GetMyPatients(string privateKey)
        {
            var list = new List<Patient>();
            var doctor = await GetDoctor(privateKey);

            string[] keys = doctor.Keys.Split("||", StringSplitOptions.RemoveEmptyEntries);

            foreach(string key in keys)
            {
                var patient = await GetPatient(key);
                list.Add(patient);
            }

            return list;

        }
    }
}
