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
using EthereumSmartContracts.Contracts.DoctorContract.ContractDefinition;

namespace EthereumSmartContracts.Contracts.DoctorContract
{
    public partial class DoctorContractService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DoctorContractDeployment doctorContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DoctorContractDeployment>().SendRequestAndWaitForReceiptAsync(doctorContractDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DoctorContractDeployment doctorContractDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DoctorContractDeployment>().SendRequestAsync(doctorContractDeployment);
        }

        public static async Task<DoctorContractService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DoctorContractDeployment doctorContractDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, doctorContractDeployment, cancellationTokenSource);
            return new DoctorContractService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DoctorContractService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddPatientRequestAsync(AddPatientFunction addPatientFunction)
        {
             return ContractHandler.SendRequestAsync(addPatientFunction);
        }

        public Task<TransactionReceipt> AddPatientRequestAndWaitForReceiptAsync(AddPatientFunction addPatientFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPatientFunction, cancellationToken);
        }

        public Task<string> AddPatientRequestAsync(string doctorAdd, string patientKey)
        {
            var addPatientFunction = new AddPatientFunction();
                addPatientFunction.DoctorAdd = doctorAdd;
                addPatientFunction.PatientKey = patientKey;
            
             return ContractHandler.SendRequestAsync(addPatientFunction);
        }

        public Task<TransactionReceipt> AddPatientRequestAndWaitForReceiptAsync(string doctorAdd, string patientKey, CancellationTokenSource cancellationToken = null)
        {
            var addPatientFunction = new AddPatientFunction();
                addPatientFunction.DoctorAdd = doctorAdd;
                addPatientFunction.PatientKey = patientKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPatientFunction, cancellationToken);
        }

        public Task<string> AddressMapQueryAsync(AddressMapFunction addressMapFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AddressMapFunction, string>(addressMapFunction, blockParameter);
        }

        
        public Task<string> AddressMapQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var addressMapFunction = new AddressMapFunction();
                addressMapFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<AddressMapFunction, string>(addressMapFunction, blockParameter);
        }

        public Task<string> CreateRequestAsync(CreateFunction createFunction)
        {
             return ContractHandler.SendRequestAsync(createFunction);
        }

        public Task<TransactionReceipt> CreateRequestAndWaitForReceiptAsync(CreateFunction createFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createFunction, cancellationToken);
        }

        public Task<string> CreateRequestAsync(string add, string name, string password, string hospital, string contactNumber, string specialty, string keys)
        {
            var createFunction = new CreateFunction();
                createFunction.Add = add;
                createFunction.Name = name;
                createFunction.Password = password;
                createFunction.Hospital = hospital;
                createFunction.ContactNumber = contactNumber;
                createFunction.Specialty = specialty;
                createFunction.Keys = keys;
            
             return ContractHandler.SendRequestAsync(createFunction);
        }

        public Task<TransactionReceipt> CreateRequestAndWaitForReceiptAsync(string add, string name, string password, string hospital, string contactNumber, string specialty, string keys, CancellationTokenSource cancellationToken = null)
        {
            var createFunction = new CreateFunction();
                createFunction.Add = add;
                createFunction.Name = name;
                createFunction.Password = password;
                createFunction.Hospital = hospital;
                createFunction.ContactNumber = contactNumber;
                createFunction.Specialty = specialty;
                createFunction.Keys = keys;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createFunction, cancellationToken);
        }

        public Task<string> FindQueryAsync(FindFunction findFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FindFunction, string>(findFunction, blockParameter);
        }

        
        public Task<string> FindQueryAsync(BigInteger id, BlockParameter blockParameter = null)
        {
            var findFunction = new FindFunction();
                findFunction.Id = id;
            
            return ContractHandler.QueryAsync<FindFunction, string>(findFunction, blockParameter);
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

        public Task<string> UpdateRequestAsync(UpdateFunction updateFunction)
        {
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(UpdateFunction updateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }

        public Task<string> UpdateRequestAsync(string add, string name, string hospital, string specialty, string contactNumber, string password, string keys)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.Add = add;
                updateFunction.Name = name;
                updateFunction.Hospital = hospital;
                updateFunction.Specialty = specialty;
                updateFunction.ContactNumber = contactNumber;
                updateFunction.Password = password;
                updateFunction.Keys = keys;
            
             return ContractHandler.SendRequestAsync(updateFunction);
        }

        public Task<TransactionReceipt> UpdateRequestAndWaitForReceiptAsync(string add, string name, string hospital, string specialty, string contactNumber, string password, string keys, CancellationTokenSource cancellationToken = null)
        {
            var updateFunction = new UpdateFunction();
                updateFunction.Add = add;
                updateFunction.Name = name;
                updateFunction.Hospital = hospital;
                updateFunction.Specialty = specialty;
                updateFunction.ContactNumber = contactNumber;
                updateFunction.Password = password;
                updateFunction.Keys = keys;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateFunction, cancellationToken);
        }
    }
}
