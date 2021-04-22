
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
    class Program
    {
        static void Main(string[] args)
        {
            DeployProgram.Deploy().Wait();
        }
    
    }
}