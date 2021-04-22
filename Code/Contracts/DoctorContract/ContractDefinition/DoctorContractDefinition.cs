using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace EthereumSmartContracts.Contracts.DoctorContract.ContractDefinition
{


    public partial class DoctorContractDeployment : DoctorContractDeploymentBase
    {
        public DoctorContractDeployment() : base(BYTECODE) { }
        public DoctorContractDeployment(string byteCode) : base(byteCode) { }
    }

    public class DoctorContractDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052600060025534801561001557600080fd5b506111de806100256000396000f3fe608060405234801561001057600080fd5b50600436106100885760003560e01c8063a087a87e1161005b578063a087a87e14610110578063a48e8d5114610135578063bbf722a214610148578063db66c0601461017157610088565b806309fae79e1461008d5780633e530e5b146100a2578063469e9067146100d257806361b8ce8c146100f9575b600080fd5b6100a061009b366004610dcb565b610184565b005b6100b56100b0366004610ecb565b6102a1565b6040516001600160a01b0390911681526020015b60405180910390f35b6100e56100e0366004610d5e565b6102bf565b6040516100c9989796959493929190611064565b61010260025481565b6040519081526020016100c9565b61012361011e366004610d5e565b61063f565b6040516100c996959493929190610fe2565b6100a0610143366004610dcb565b610a4b565b6100b5610156366004610ecb565b6001602052600090815260409020546001600160a01b031681565b6100a061017f366004610d7f565b610ba5565b6001600160a01b03871660009081526020818152604090912087516101b192600190920191890190610c27565b506001600160a01b03871660009081526020818152604090912086516101df92600390920191880190610c27565b506001600160a01b038716600090815260208181526040909120855161020d92600490920191870190610c27565b506001600160a01b038716600090815260208181526040909120845161023b92600590920191860190610c27565b506001600160a01b038716600090815260208181526040909120835161026992600690920191850190610c27565b506001600160a01b038716600090815260208181526040909120825161029792600790920191840190610c27565b5050505050505050565b6000818152600160205260409020546001600160a01b03165b919050565b600060208190529081526040902080546001820180549192916102e190611130565b80601f016020809104026020016040519081016040528092919081815260200182805461030d90611130565b801561035a5780601f1061032f5761010080835404028352916020019161035a565b820191906000526020600020905b81548152906001019060200180831161033d57829003601f168201915b505050600284015460038501805494956001600160a01b0390921694919350915061038490611130565b80601f01602080910402602001604051908101604052809291908181526020018280546103b090611130565b80156103fd5780601f106103d2576101008083540402835291602001916103fd565b820191906000526020600020905b8154815290600101906020018083116103e057829003601f168201915b50505050509080600401805461041290611130565b80601f016020809104026020016040519081016040528092919081815260200182805461043e90611130565b801561048b5780601f106104605761010080835404028352916020019161048b565b820191906000526020600020905b81548152906001019060200180831161046e57829003601f168201915b5050505050908060050180546104a090611130565b80601f01602080910402602001604051908101604052809291908181526020018280546104cc90611130565b80156105195780601f106104ee57610100808354040283529160200191610519565b820191906000526020600020905b8154815290600101906020018083116104fc57829003601f168201915b50505050509080600601805461052e90611130565b80601f016020809104026020016040519081016040528092919081815260200182805461055a90611130565b80156105a75780601f1061057c576101008083540402835291602001916105a7565b820191906000526020600020905b81548152906001019060200180831161058a57829003601f168201915b5050505050908060070180546105bc90611130565b80601f01602080910402602001604051908101604052809291908181526020018280546105e890611130565b80156106355780601f1061060a57610100808354040283529160200191610635565b820191906000526020600020905b81548152906001019060200180831161061857829003601f168201915b5050505050905088565b606080606080606080600080886001600160a01b03166001600160a01b03168152602001908152602001600020600101805461067a90611130565b80601f01602080910402602001604051908101604052809291908181526020018280546106a690611130565b80156106f35780601f106106c8576101008083540402835291602001916106f3565b820191906000526020600020905b8154815290600101906020018083116106d657829003601f168201915b505050506001600160a01b03891660009081526020819052604090206003018054929850916107229150611130565b80601f016020809104026020016040519081016040528092919081815260200182805461074e90611130565b801561079b5780601f106107705761010080835404028352916020019161079b565b820191906000526020600020905b81548152906001019060200180831161077e57829003601f168201915b505050506001600160a01b03891660009081526020819052604090206004018054929750916107ca9150611130565b80601f01602080910402602001604051908101604052809291908181526020018280546107f690611130565b80156108435780601f1061081857610100808354040283529160200191610843565b820191906000526020600020905b81548152906001019060200180831161082657829003601f168201915b505050506001600160a01b03891660009081526020819052604090206005018054929650916108729150611130565b80601f016020809104026020016040519081016040528092919081815260200182805461089e90611130565b80156108eb5780601f106108c0576101008083540402835291602001916108eb565b820191906000526020600020905b8154815290600101906020018083116108ce57829003601f168201915b505050506001600160a01b038916600090815260208190526040902060060180549295509161091a9150611130565b80601f016020809104026020016040519081016040528092919081815260200182805461094690611130565b80156109935780601f1061096857610100808354040283529160200191610993565b820191906000526020600020905b81548152906001019060200180831161097657829003601f168201915b505050506001600160a01b03891660009081526020819052604090206007018054929450916109c29150611130565b80601f01602080910402602001604051908101604052809291908181526020018280546109ee90611130565b8015610a3b5780601f10610a1057610100808354040283529160200191610a3b565b820191906000526020600020905b815481529060010190602001808311610a1e57829003601f168201915b5050505050905091939550919395565b6001600160a01b0387166000908152602081815260409091208751610a7892600190920191890190610c27565b506001600160a01b0387166000908152602081815260409091208551610aa692600390920191870190610c27565b506001600160a01b0387166000908152602081815260409091208351610ad492600490920191850190610c27565b506001600160a01b0387166000908152602081815260409091208451610b0292600590920191860190610c27565b506001600160a01b0387166000908152602081815260409091208651610b3092600690920191880190610c27565b506001600160a01b0387166000908152602081815260409091208251610b5e92600790920191840190610c27565b5060028054600090815260016020526040812080546001600160a01b0319166001600160a01b038b1617905581549190610b978361116b565b919050555050505050505050565b6001600160a01b038216600090815260208181526040918290209151610bd19260070191849101610f2b565b60408051601f198184030181529181526001600160a01b038416600090815260208181529190208251610c0d9360079092019290910190610c27565b5060028054906000610c1e8361116b565b91905055505050565b828054610c3390611130565b90600052602060002090601f016020900481019282610c555760008555610c9b565b82601f10610c6e57805160ff1916838001178555610c9b565b82800160010185558215610c9b579182015b82811115610c9b578251825591602001919060010190610c80565b50610ca7929150610cab565b5090565b5b80821115610ca75760008155600101610cac565b80356001600160a01b03811681146102ba57600080fd5b600082601f830112610ce7578081fd5b813567ffffffffffffffff80821115610d0257610d02611192565b604051601f8301601f19908116603f01168101908282118183101715610d2a57610d2a611192565b81604052838152866020858801011115610d42578485fd5b8360208701602083013792830160200193909352509392505050565b600060208284031215610d6f578081fd5b610d7882610cc0565b9392505050565b60008060408385031215610d91578081fd5b610d9a83610cc0565b9150602083013567ffffffffffffffff811115610db5578182fd5b610dc185828601610cd7565b9150509250929050565b600080600080600080600060e0888a031215610de5578283fd5b610dee88610cc0565b9650602088013567ffffffffffffffff80821115610e0a578485fd5b610e168b838c01610cd7565b975060408a0135915080821115610e2b578485fd5b610e378b838c01610cd7565b965060608a0135915080821115610e4c578485fd5b610e588b838c01610cd7565b955060808a0135915080821115610e6d578485fd5b610e798b838c01610cd7565b945060a08a0135915080821115610e8e578384fd5b610e9a8b838c01610cd7565b935060c08a0135915080821115610eaf578283fd5b50610ebc8a828b01610cd7565b91505092959891949750929550565b600060208284031215610edc578081fd5b5035919050565b60008151808452610efb816020860160208601611100565b601f01601f19169290920160200192915050565b60008151610f21818560208601611100565b9290920192915050565b8254600090819060028104600180831680610f4757607f831692505b6020808410821415610f6757634e487b7160e01b87526022600452602487fd5b818015610f7b5760018114610f8c57610fb8565b60ff19861689528489019650610fb8565b60008b815260209020885b86811015610fb05781548b820152908501908301610f97565b505084890196505b505050505050610fd9610fd382611f1f60f21b815260020190565b85610f0f565b95945050505050565b600060c08252610ff560c0830189610ee3565b82810360208401526110078189610ee3565b9050828103604084015261101b8188610ee3565b9050828103606084015261102f8187610ee3565b905082810360808401526110438186610ee3565b905082810360a08401526110578185610ee3565b9998505050505050505050565b60006101008a835280602084015261107e8184018b610ee3565b6001600160a01b038a166040850152838103606085015290506110a18189610ee3565b905082810360808401526110b58188610ee3565b905082810360a08401526110c98187610ee3565b905082810360c08401526110dd8186610ee3565b905082810360e08401526110f18185610ee3565b9b9a5050505050505050505050565b60005b8381101561111b578181015183820152602001611103565b8381111561112a576000848401525b50505050565b60028104600182168061114457607f821691505b6020821081141561116557634e487b7160e01b600052602260045260246000fd5b50919050565b600060001982141561118b57634e487b7160e01b81526011600452602481fd5b5060010190565b634e487b7160e01b600052604160045260246000fdfea2646970667358221220a63c3acc48df04bb97bd9b111d1f9429d2f98b428b63a25f2eceab12f214b7f364736f6c63430008020033";
        public DoctorContractDeploymentBase() : base(BYTECODE) { }
        public DoctorContractDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddPatientFunction : AddPatientFunctionBase { }

    [Function("addPatient")]
    public class AddPatientFunctionBase : FunctionMessage
    {
        [Parameter("address", "doctorAdd", 1)]
        public virtual string DoctorAdd { get; set; }
        [Parameter("string", "patientKey", 2)]
        public virtual string PatientKey { get; set; }
    }

    public partial class AddressMapFunction : AddressMapFunctionBase { }

    [Function("addressMap", "address")]
    public class AddressMapFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CreateFunction : CreateFunctionBase { }

    [Function("create")]
    public class CreateFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "password", 3)]
        public virtual string Password { get; set; }
        [Parameter("string", "hospital", 4)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "contactNumber", 5)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "specialty", 6)]
        public virtual string Specialty { get; set; }
        [Parameter("string", "keys", 7)]
        public virtual string Keys { get; set; }
    }

    public partial class FindFunction : FindFunctionBase { }

    [Function("find", "address")]
    public class FindFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
    }

    public partial class NextIdFunction : NextIdFunctionBase { }

    [Function("nextId", "uint256")]
    public class NextIdFunctionBase : FunctionMessage
    {

    }

    public partial class ReadFunction : ReadFunctionBase { }

    [Function("read", typeof(ReadOutputDTO))]
    public class ReadFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
    }

    public partial class RecordsFunction : RecordsFunctionBase { }

    [Function("records", typeof(RecordsOutputDTO))]
    public class RecordsFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class UpdateFunction : UpdateFunctionBase { }

    [Function("update")]
    public class UpdateFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("string", "hospital", 3)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "specialty", 4)]
        public virtual string Specialty { get; set; }
        [Parameter("string", "contactNumber", 5)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "password", 6)]
        public virtual string Password { get; set; }
        [Parameter("string", "keys", 7)]
        public virtual string Keys { get; set; }
    }



    public partial class AddressMapOutputDTO : AddressMapOutputDTOBase { }

    [FunctionOutput]
    public class AddressMapOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class FindOutputDTO : FindOutputDTOBase { }

    [FunctionOutput]
    public class FindOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class NextIdOutputDTO : NextIdOutputDTOBase { }

    [FunctionOutput]
    public class NextIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ReadOutputDTO : ReadOutputDTOBase { }

    [FunctionOutput]
    public class ReadOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "_hospital", 2)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "_specialty", 3)]
        public virtual string Specialty { get; set; }
        [Parameter("string", "_contactNumber", 4)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "_password", 5)]
        public virtual string Password { get; set; }
        [Parameter("string", "_keys", 6)]
        public virtual string Keys { get; set; }
    }

    public partial class RecordsOutputDTO : RecordsOutputDTOBase { }

    [FunctionOutput]
    public class RecordsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "id", 1)]
        public virtual BigInteger Id { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
        [Parameter("address", "add", 3)]
        public virtual string Add { get; set; }
        [Parameter("string", "hospital", 4)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "specialty", 5)]
        public virtual string Specialty { get; set; }
        [Parameter("string", "contactNumber", 6)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "password", 7)]
        public virtual string Password { get; set; }
        [Parameter("string", "keys", 8)]
        public virtual string Keys { get; set; }
    }


}
