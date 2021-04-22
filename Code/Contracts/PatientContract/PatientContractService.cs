using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using EthereumSmartContracts.Contracts.PatientContract.ContractDefinition;

namespace EthereumSmartContracts.Contracts.PatientContract
{
    public partial class PatientContractService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PatientContractDeployment patientContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PatientContractDeployment>().SendRequestAndWaitForReceiptAsync(patientContractDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PatientContractDeployment patientContractDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PatientContractDeployment>().SendRequestAsync(patientContractDeployment);
        }

        public static async Task<PatientContractService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PatientContractDeployment patientContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, patientContractDeployment, cancellationTokenSource);
            return new PatientContractService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PatientContractService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddCommentRequestAsync(AddCommentFunction addCommentFunction)
        {
             return ContractHandler.SendRequestAsync(addCommentFunction);
        }

        public Task<TransactionReceipt> AddCommentRequestAndWaitForReceiptAsync(AddCommentFunction addCommentFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addCommentFunction, cancellationToken);
        }

        public Task<string> AddCommentRequestAsync(string add, string doctorName, string date, string text)
        {
            var addCommentFunction = new AddCommentFunction();
                addCommentFunction.Add = add;
                addCommentFunction.DoctorName = doctorName;
                addCommentFunction.Date = date;
                addCommentFunction.Text = text;
            
             return ContractHandler.SendRequestAsync(addCommentFunction);
        }

        public Task<TransactionReceipt> AddCommentRequestAndWaitForReceiptAsync(string add, string doctorName, string date, string text, CancellationTokenSource cancellationToken = null)
        {
            var addCommentFunction = new AddCommentFunction();
                addCommentFunction.Add = add;
                addCommentFunction.DoctorName = doctorName;
                addCommentFunction.Date = date;
                addCommentFunction.Text = text;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addCommentFunction, cancellationToken);
        }

        public Task<string> CreateRequestAsync(CreateFunction createFunction)
        {
             return ContractHandler.SendRequestAsync(createFunction);
        }

        public Task<TransactionReceipt> CreateRequestAndWaitForReceiptAsync(CreateFunction createFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createFunction, cancellationToken);
        }

        public Task<string> CreateRequestAsync(string add, string name, string password, string hospital, string visitReason, string medicalCondition)
        {
            var createFunction = new CreateFunction();
                createFunction.Add = add;
                createFunction.Name = name;
                createFunction.Password = password;
                createFunction.Hospital = hospital;
                createFunction.VisitReason = visitReason;
                createFunction.MedicalCondition = medicalCondition;
            
             return ContractHandler.SendRequestAsync(createFunction);
        }

        public Task<TransactionReceipt> CreateRequestAndWaitForReceiptAsync(string add, string name, string password, string hospital, string visitReason, string medicalCondition, CancellationTokenSource cancellationToken = null)
        {
            var createFunction = new CreateFunction();
                createFunction.Add = add;
                createFunction.Name = name;
                createFunction.Password = password;
                createFunction.Hospital = hospital;
                createFunction.VisitReason = visitReason;
                createFunction.MedicalCondition = medicalCondition;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createFunction, cancellationToken);
        }

        public Task<string> CreateInfoRequestAsync(CreateInfoFunction createInfoFunction)
        {
             return ContractHandler.SendRequestAsync(createInfoFunction);
        }

        public Task<TransactionReceipt> CreateInfoRequestAndWaitForReceiptAsync(CreateInfoFunction createInfoFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createInfoFunction, cancellationToken);
        }

        public Task<string> CreateInfoRequestAsync(string add, string residentialAddress, string postalCode, string contactNumber, string age, string gender, string employer, string eduction, string insurance)
        {
            var createInfoFunction = new CreateInfoFunction();
                createInfoFunction.Add = add;
                createInfoFunction.ResidentialAddress = residentialAddress;
                createInfoFunction.PostalCode = postalCode;
                createInfoFunction.ContactNumber = contactNumber;
                createInfoFunction.Age = age;
                createInfoFunction.Gender = gender;
                createInfoFunction.Employer = employer;
                createInfoFunction.Eduction = eduction;
                createInfoFunction.Insurance = insurance;
            
             return ContractHandler.SendRequestAsync(createInfoFunction);
        }

        public Task<TransactionReceipt> CreateInfoRequestAndWaitForReceiptAsync(string add, string residentialAddress, string postalCode, string contactNumber, string age, string gender, string employer, string eduction, string insurance, CancellationTokenSource cancellationToken = null)
        {
            var createInfoFunction = new CreateInfoFunction();
                createInfoFunction.Add = add;
                createInfoFunction.ResidentialAddress = residentialAddress;
                createInfoFunction.PostalCode = postalCode;
                createInfoFunction.ContactNumber = contactNumber;
                createInfoFunction.Age = age;
                createInfoFunction.Gender = gender;
                createInfoFunction.Employer = employer;
                createInfoFunction.Eduction = eduction;
                createInfoFunction.Insurance = insurance;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createInfoFunction, cancellationToken);
        }

        public Task<string> CreateMedicsRequestAsync(CreateMedicsFunction createMedicsFunction)
        {
             return ContractHandler.SendRequestAsync(createMedicsFunction);
        }

        public Task<TransactionReceipt> CreateMedicsRequestAndWaitForReceiptAsync(CreateMedicsFunction createMedicsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createMedicsFunction, cancellationToken);
        }

        public Task<string> CreateMedicsRequestAsync(string add, string pastProblems, string familyHistory, string currentProblems, string medications, string allergies)
        {
            var createMedicsFunction = new CreateMedicsFunction();
                createMedicsFunction.Add = add;
                createMedicsFunction.PastProblems = pastProblems;
                createMedicsFunction.FamilyHistory = familyHistory;
                createMedicsFunction.CurrentProblems = currentProblems;
                createMedicsFunction.Medications = medications;
                createMedicsFunction.Allergies = allergies;
            
             return ContractHandler.SendRequestAsync(createMedicsFunction);
        }

        public Task<TransactionReceipt> CreateMedicsRequestAndWaitForReceiptAsync(string add, string pastProblems, string familyHistory, string currentProblems, string medications, string allergies, CancellationTokenSource cancellationToken = null)
        {
            var createMedicsFunction = new CreateMedicsFunction();
                createMedicsFunction.Add = add;
                createMedicsFunction.PastProblems = pastProblems;
                createMedicsFunction.FamilyHistory = familyHistory;
                createMedicsFunction.CurrentProblems = currentProblems;
                createMedicsFunction.Medications = medications;
                createMedicsFunction.Allergies = allergies;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createMedicsFunction, cancellationToken);
        }

        public Task<BigInteger> NextIdQueryAsync(NextIdFunction nextIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextIdFunction, BigInteger>(nextIdFunction, blockParameter);
        }

        
        public Task<BigInteger> NextIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextIdFunction, BigInteger>(null, blockParameter);
        }

        public Task<ReadOutputDTO> ReadQueryAsync(ReadFunction readFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ReadFunction, ReadOutputDTO>(readFunction, blockParameter);
        }

        public Task<ReadOutputDTO> ReadQueryAsync(string add, BlockParameter blockParameter = null)
        {
            var readFunction = new ReadFunction();
                readFunction.Add = add;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ReadFunction, ReadOutputDTO>(readFunction, blockParameter);
        }

        public Task<ReadCommentsOutputDTO> ReadCommentsQueryAsync(ReadCommentsFunction readCommentsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ReadCommentsFunction, ReadCommentsOutputDTO>(readCommentsFunction, blockParameter);
        }

        public Task<ReadCommentsOutputDTO> ReadCommentsQueryAsync(string add, BlockParameter blockParameter = null)
        {
            var readCommentsFunction = new ReadCommentsFunction();
                readCommentsFunction.Add = add;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ReadCommentsFunction, ReadCommentsOutputDTO>(readCommentsFunction, blockParameter);
        }

        public Task<ReadInfoOutputDTO> ReadInfoQueryAsync(ReadInfoFunction readInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ReadInfoFunction, ReadInfoOutputDTO>(readInfoFunction, blockParameter);
        }

        public Task<ReadInfoOutputDTO> ReadInfoQueryAsync(string add, BlockParameter blockParameter = null)
        {
            var readInfoFunction = new ReadInfoFunction();
                readInfoFunction.Add = add;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ReadInfoFunction, ReadInfoOutputDTO>(readInfoFunction, blockParameter);
        }

        public Task<ReadMedicsOutputDTO> ReadMedicsQueryAsync(ReadMedicsFunction readMedicsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ReadMedicsFunction, ReadMedicsOutputDTO>(readMedicsFunction, blockParameter);
        }

        public Task<ReadMedicsOutputDTO> ReadMedicsQueryAsync(string add, BlockParameter blockParameter = null)
        {
            var readMedicsFunction = new ReadMedicsFunction();
                readMedicsFunction.Add = add;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ReadMedicsFunction, ReadMedicsOutputDTO>(readMedicsFunction, blockParameter);
        }

        public Task<RecordsOutputDTO> RecordsQueryAsync(RecordsFunction recordsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsFunction, RecordsOutputDTO>(recordsFunction, blockParameter);
        }

        public Task<RecordsOutputDTO> RecordsQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var recordsFunction = new RecordsFunction();
                recordsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsFunction, RecordsOutputDTO>(recordsFunction, blockParameter);
        }

        public Task<RecordsInfoOutputDTO> RecordsInfoQueryAsync(RecordsInfoFunction recordsInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsInfoFunction, RecordsInfoOutputDTO>(recordsInfoFunction, blockParameter);
        }

        public Task<RecordsInfoOutputDTO> RecordsInfoQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var recordsInfoFunction = new RecordsInfoFunction();
                recordsInfoFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsInfoFunction, RecordsInfoOutputDTO>(recordsInfoFunction, blockParameter);
        }

        public Task<RecordsMedInfoOutputDTO> RecordsMedInfoQueryAsync(RecordsMedInfoFunction recordsMedInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsMedInfoFunction, RecordsMedInfoOutputDTO>(recordsMedInfoFunction, blockParameter);
        }

        public Task<RecordsMedInfoOutputDTO> RecordsMedInfoQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var recordsMedInfoFunction = new RecordsMedInfoFunction();
                recordsMedInfoFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsMedInfoFunction, RecordsMedInfoOutputDTO>(recordsMedInfoFunction, blockParameter);
        }

        public Task<RecordsReportsOutputDTO> RecordsReportsQueryAsync(RecordsReportsFunction recordsReportsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsReportsFunction, RecordsReportsOutputDTO>(recordsReportsFunction, blockParameter);
        }

        public Task<RecordsReportsOutputDTO> RecordsReportsQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var recordsReportsFunction = new RecordsReportsFunction();
                recordsReportsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<RecordsReportsFunction, RecordsReportsOutputDTO>(recordsReportsFunction, blockParameter);
        }

        public Task<string> UpdateRequestAsync(UpdateFunction updateFunction)
        {
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(UpdateFunction updateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }

        public Task<string> UpdateRequestAsync(string add, string name, string password, string hospital, string visitReason, string medicalCondition)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.Add = add;
                updateFunction.Name = name;
                updateFunction.Password = password;
                updateFunction.Hospital = hospital;
                updateFunction.VisitReason = visitReason;
                updateFunction.MedicalCondition = medicalCondition;
            
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(string add, string name, string password, string hospital, string visitReason, string medicalCondition, CancellationTokenSource cancellationToken = null)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.Add = add;
                updateFunction.Name = name;
                updateFunction.Password = password;
                updateFunction.Hospital = hospital;
                updateFunction.VisitReason = visitReason;
                updateFunction.MedicalCondition = medicalCondition;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }

        public Task<string> UpdateInfoRequestAsync(UpdateInfoFunction updateInfoFunction)
        {
             return ContractHandler.SendRequestAsync(updateInfoFunction);
        }

        public Task<TransactionReceipt> UpdateInfoRequestAndWaitForReceiptAsync(UpdateInfoFunction updateInfoFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateInfoFunction, cancellationToken);
        }

        public Task<string> UpdateInfoRequestAsync(string add, string residentialAddress, string postalCode, string contactNumber, string age, string gender, string employer, string eduction, string insurance)
        {
            var updateInfoFunction = new UpdateInfoFunction();
                updateInfoFunction.Add = add;
                updateInfoFunction.ResidentialAddress = residentialAddress;
                updateInfoFunction.PostalCode = postalCode;
                updateInfoFunction.ContactNumber = contactNumber;
                updateInfoFunction.Age = age;
                updateInfoFunction.Gender = gender;
                updateInfoFunction.Employer = employer;
                updateInfoFunction.Eduction = eduction;
                updateInfoFunction.Insurance = insurance;
            
             return ContractHandler.SendRequestAsync(updateInfoFunction);
        }

        public Task<TransactionReceipt> UpdateInfoRequestAndWaitForReceiptAsync(string add, string residentialAddress, string postalCode, string contactNumber, string age, string gender, string employer, string eduction, string insurance, CancellationTokenSource cancellationToken = null)
        {
            var updateInfoFunction = new UpdateInfoFunction();
                updateInfoFunction.Add = add;
                updateInfoFunction.ResidentialAddress = residentialAddress;
                updateInfoFunction.PostalCode = postalCode;
                updateInfoFunction.ContactNumber = contactNumber;
                updateInfoFunction.Age = age;
                updateInfoFunction.Gender = gender;
                updateInfoFunction.Employer = employer;
                updateInfoFunction.Eduction = eduction;
                updateInfoFunction.Insurance = insurance;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateInfoFunction, cancellationToken);
        }

        public Task<string> UpdateMedicsRequestAsync(UpdateMedicsFunction updateMedicsFunction)
        {
             return ContractHandler.SendRequestAsync(updateMedicsFunction);
        }

        public Task<TransactionReceipt> UpdateMedicsRequestAndWaitForReceiptAsync(UpdateMedicsFunction updateMedicsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateMedicsFunction, cancellationToken);
        }

        public Task<string> UpdateMedicsRequestAsync(string add, string pastProblems, string familyHistory, string currentProblems, string medications, string allergies)
        {
            var updateMedicsFunction = new UpdateMedicsFunction();
                updateMedicsFunction.Add = add;
                updateMedicsFunction.PastProblems = pastProblems;
                updateMedicsFunction.FamilyHistory = familyHistory;
                updateMedicsFunction.CurrentProblems = currentProblems;
                updateMedicsFunction.Medications = medications;
                updateMedicsFunction.Allergies = allergies;
            
             return ContractHandler.SendRequestAsync(updateMedicsFunction);
        }

        public Task<TransactionReceipt> UpdateMedicsRequestAndWaitForReceiptAsync(string add, string pastProblems, string familyHistory, string currentProblems, string medications, string allergies, CancellationTokenSource cancellationToken = null)
        {
            var updateMedicsFunction = new UpdateMedicsFunction();
                updateMedicsFunction.Add = add;
                updateMedicsFunction.PastProblems = pastProblems;
                updateMedicsFunction.FamilyHistory = familyHistory;
                updateMedicsFunction.CurrentProblems = currentProblems;
                updateMedicsFunction.Medications = medications;
                updateMedicsFunction.Allergies = allergies;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateMedicsFunction, cancellationToken);
        }

        public Task<UsersOutputDTO> UsersQueryAsync(UsersFunction usersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<UsersFunction, UsersOutputDTO>(usersFunction, blockParameter);
        }

        public Task<UsersOutputDTO> UsersQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var usersFunction = new UsersFunction();
                usersFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryDeserializingToObjectAsync<UsersFunction, UsersOutputDTO>(usersFunction, blockParameter);
        }
    }
}
