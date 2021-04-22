
using Services;
using EthereumSmartContracts.Contracts.DoctorContract;
using EthereumSmartContracts.Contracts.DoctorContract.ContractDefinition;
using EthereumSmartContracts.Contracts.PatientContract;
using EthereumSmartContracts.Contracts.PatientContract.ContractDefinition;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using PatientService;
using System;
using System.Threading.Tasks;

namespace SimpleStorageConsole
{
    public class DeployProgram
    {       

        public static async Task Deploy()
        {
            try
            {
                string privateKey = KeyService.GetNextkey();

                Console.WriteLine("Getting key done.");

                Console.WriteLine("Deploying Patient Contract.");
                await BlockchainFactory.DeployPatientContract(privateKey);
                Console.WriteLine("Deploying Patient Contract done.");

                Console.WriteLine("");

                Console.WriteLine("Deploying Doctor Contract.");
                await BlockchainFactory.DeployDoctorService(privateKey);
                Console.WriteLine("Deploying Doctor Contract done.");

                Console.WriteLine("Press any key to stop...");

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}