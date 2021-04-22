using EthereumSmartContracts.Contracts.DoctorContract;
using EthereumSmartContracts.Contracts.DoctorContract.ContractDefinition;
using EthereumSmartContracts.Contracts.PatientContract;
using EthereumSmartContracts.Contracts.PatientContract.ContractDefinition;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace PatientService
{
    public class BlockchainFactory
    {
        private static string url = ConfigurationManager.AppSettings["NetworkURL"];

        public static string GetNetworkUrl()
        {
            return url;
        }

        public static PatientContractService GetPatientService(Web3 web3)
        {
            PatientContractService patientContractService = null;
            try
            {
                patientContractService = new PatientContractService(web3, KeyService.GetContractAddress(0)); //receipt.ContractAddress);
            }
            catch(Exception ex)
            {
               

            }

            return patientContractService;
        }

        public static async Task<PatientContractService> DeployPatientContract(string privateKey)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, GetNetworkUrl());

            var deploy = new PatientContractDeployment();
            var receipt = await PatientContractService.DeployContractAndWaitForReceiptAsync(web3, deploy);
            var patientContractService = new PatientContractService(web3, receipt.ContractAddress);

            //Add contract address to the contracts json file
            KeyService.AddContractAddress(0, receipt.ContractAddress);

            return patientContractService;
        }

        public static DoctorContractService GetDoctorService(string privateKey)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, GetNetworkUrl());

            DoctorContractService doctorContractService = null;
            try
            {
                doctorContractService = new DoctorContractService(web3, KeyService.GetContractAddress(1)); //receipt.ContractAddress);
            }
            catch (Exception ex)
            {                

            }

            return doctorContractService;
        }

        public static async Task<DoctorContractService> DeployDoctorService(string privateKey)
        {
            var account = new Account(privateKey);

            var web3 = new Web3(account, GetNetworkUrl());

            var deploy = new DoctorContractDeployment();
            var receipt = await DoctorContractService.DeployContractAndWaitForReceiptAsync(web3, deploy);
            var doctorContractService = new DoctorContractService(web3, receipt.ContractAddress);

            //Add contract address to the contracts json file
            KeyService.AddContractAddress(1, receipt.ContractAddress);

            return doctorContractService;
        }
    }
}
