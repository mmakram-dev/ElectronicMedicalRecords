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

namespace EthereumSmartContracts.Contracts.PatientContract.ContractDefinition
{


    public partial class PatientContractDeployment : PatientContractDeploymentBase
    {
        public PatientContractDeployment() : base(BYTECODE) { }
        public PatientContractDeployment(string byteCode) : base(byteCode) { }
    }

    public class PatientContractDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052600160055534801561001557600080fd5b50612ae6806100256000396000f3fe608060405234801561001057600080fd5b506004361061010b5760003560e01c806361b8ce8c116100a2578063a087a87e11610071578063a087a87e14610249578063b0de92c61461025c578063d266b0241461026f578063da41f7d714610282578063ec7ec8ab146102955761010b565b806361b8ce8c146101f95780637e0230f9146102105780638980b981146102235780639e763e3a146102365761010b565b8063365b98b2116100de578063365b98b214610187578063469e9067146101ac5780634e22da4a146101bf5780635b8a0aae146101d25761010b565b806314d688e3146101105780631ead61b0146101255780632620dce1146101525780632ecb973b14610174575b600080fd5b61012361011e3660046125d6565b6102a8565b005b610138610133366004612520565b6103a5565b60405161014995949392919061291c565b60405180910390f35b610165610160366004612520565b610708565b604051610149939291906128d9565b6101236101823660046125d6565b61090a565b61019a6101953660046127f9565b6109f2565b6040516101499695949392919061285c565b61019a6101ba366004612520565b610cf5565b6101656101cd366004612520565b610d10565b6101e56101e0366004612520565b610eca565b604051610149989796959493929190612989565b61020260055481565b604051908152602001610149565b6101e561021e366004612520565b61134a565b610123610231366004612541565b6118b7565b6101236102443660046126b1565b611947565b610138610257366004612520565b611acc565b61012361026a3660046125d6565b611da6565b61012361027d3660046126b1565b611e8f565b610138610290366004612520565b612029565b6101236102a33660046125d6565b6122ff565b6001600160a01b03861660009081526020818152604090912086516102cf928801906123e4565b506001600160a01b03861660009081526020818152604090912084516102fd926003909201918601906123e4565b506001600160a01b038616600090815260208181526040909120835161032b926004909201918501906123e4565b506001600160a01b0386166000908152602081815260409091208551610359926001909201918701906123e4565b506001600160a01b0386166000908152602081815260409091208251610387926005909201918401906123e4565b506005805490600061039883612a73565b9190505550505050505050565b6001600160a01b038116600090815260026020526040902080546060918291829182918291906103d490612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461040090612a38565b801561044d5780601f106104225761010080835404028352916020019161044d565b820191906000526020600020905b81548152906001019060200180831161043057829003601f168201915b505050506001600160a01b038816600090815260026020526040902060010180549297509161047c9150612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546104a890612a38565b80156104f55780601f106104ca576101008083540402835291602001916104f5565b820191906000526020600020905b8154815290600101906020018083116104d857829003601f168201915b5050505050935060026000876001600160a01b03166001600160a01b03168152602001908152602001600020600201805461052f90612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461055b90612a38565b80156105a85780601f1061057d576101008083540402835291602001916105a8565b820191906000526020600020905b81548152906001019060200180831161058b57829003601f168201915b505050506001600160a01b03881660009081526002602052604090206003018054929550916105d79150612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461060390612a38565b80156106505780601f1061062557610100808354040283529160200191610650565b820191906000526020600020905b81548152906001019060200180831161063357829003601f168201915b505050506001600160a01b038816600090815260026020526040902060040180549294509161067f9150612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546106ab90612a38565b80156106f85780601f106106cd576101008083540402835291602001916106f8565b820191906000526020600020905b8154815290600101906020018083116106db57829003601f168201915b5050505050905091939590929450565b6001600160a01b03811660009081526003602052604090208054606091829182919061073390612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461075f90612a38565b80156107ac5780601f10610781576101008083540402835291602001916107ac565b820191906000526020600020905b81548152906001019060200180831161078f57829003601f168201915b505050506001600160a01b03861660009081526003602052604090206001018054929550916107db9150612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461080790612a38565b80156108545780601f1061082957610100808354040283529160200191610854565b820191906000526020600020905b81548152906001019060200180831161083757829003601f168201915b505050506001600160a01b03861660009081526003602052604090206002018054929450916108839150612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546108af90612a38565b80156108fc5780601f106108d1576101008083540402835291602001916108fc565b820191906000526020600020905b8154815290600101906020018083116108df57829003601f168201915b505050505090509193909250565b6001600160a01b0386166000908152602081815260409091208651610931928801906123e4565b506001600160a01b038616600090815260208181526040909120845161095f926003909201918601906123e4565b506001600160a01b038616600090815260208181526040909120835161098d926004909201918501906123e4565b506001600160a01b03861660009081526020818152604090912085516109bb926001909201918701906123e4565b506001600160a01b03861660009081526020818152604090912082516109e9926005909201918401906123e4565b50505050505050565b60048181548110610a0257600080fd5b9060005260206000209060060201600091509050806000018054610a2590612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610a5190612a38565b8015610a9e5780601f10610a7357610100808354040283529160200191610a9e565b820191906000526020600020905b815481529060010190602001808311610a8157829003601f168201915b505050505090806001018054610ab390612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610adf90612a38565b8015610b2c5780601f10610b0157610100808354040283529160200191610b2c565b820191906000526020600020905b815481529060010190602001808311610b0f57829003601f168201915b505050600284015460038501805494956001600160a01b03909216949193509150610b5690612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610b8290612a38565b8015610bcf5780601f10610ba457610100808354040283529160200191610bcf565b820191906000526020600020905b815481529060010190602001808311610bb257829003601f168201915b505050505090806004018054610be490612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610c1090612a38565b8015610c5d5780601f10610c3257610100808354040283529160200191610c5d565b820191906000526020600020905b815481529060010190602001808311610c4057829003601f168201915b505050505090806005018054610c7290612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610c9e90612a38565b8015610ceb5780601f10610cc057610100808354040283529160200191610ceb565b820191906000526020600020905b815481529060010190602001808311610cce57829003601f168201915b5050505050905086565b600060208190529081526040902080548190610a2590612a38565b600360205260009081526040902080548190610d2b90612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610d5790612a38565b8015610da45780601f10610d7957610100808354040283529160200191610da4565b820191906000526020600020905b815481529060010190602001808311610d8757829003601f168201915b505050505090806001018054610db990612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610de590612a38565b8015610e325780601f10610e0757610100808354040283529160200191610e32565b820191906000526020600020905b815481529060010190602001808311610e1557829003601f168201915b505050505090806002018054610e4790612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610e7390612a38565b8015610ec05780601f10610e9557610100808354040283529160200191610ec0565b820191906000526020600020905b815481529060010190602001808311610ea357829003601f168201915b5050505050905083565b600160205260009081526040902080548190610ee590612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610f1190612a38565b8015610f5e5780601f10610f3357610100808354040283529160200191610f5e565b820191906000526020600020905b815481529060010190602001808311610f4157829003601f168201915b505050505090806001018054610f7390612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054610f9f90612a38565b8015610fec5780601f10610fc157610100808354040283529160200191610fec565b820191906000526020600020905b815481529060010190602001808311610fcf57829003601f168201915b50505050509080600201805461100190612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461102d90612a38565b801561107a5780601f1061104f5761010080835404028352916020019161107a565b820191906000526020600020905b81548152906001019060200180831161105d57829003601f168201915b50505050509080600301805461108f90612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546110bb90612a38565b80156111085780601f106110dd57610100808354040283529160200191611108565b820191906000526020600020905b8154815290600101906020018083116110eb57829003601f168201915b50505050509080600401805461111d90612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461114990612a38565b80156111965780601f1061116b57610100808354040283529160200191611196565b820191906000526020600020905b81548152906001019060200180831161117957829003601f168201915b5050505050908060050180546111ab90612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546111d790612a38565b80156112245780601f106111f957610100808354040283529160200191611224565b820191906000526020600020905b81548152906001019060200180831161120757829003601f168201915b50505050509080600601805461123990612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461126590612a38565b80156112b25780601f10611287576101008083540402835291602001916112b2565b820191906000526020600020905b81548152906001019060200180831161129557829003601f168201915b5050505050908060070180546112c790612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546112f390612a38565b80156113405780601f1061131557610100808354040283529160200191611340565b820191906000526020600020905b81548152906001019060200180831161132357829003601f168201915b5050505050905088565b606080606080606080606080600160008a6001600160a01b03166001600160a01b03168152602001908152602001600020600001805461138990612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546113b590612a38565b80156114025780601f106113d757610100808354040283529160200191611402565b820191906000526020600020905b8154815290600101906020018083116113e557829003601f168201915b505050506001600160a01b038b1660009081526001602052604090206003018054929a50916114319150612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461145d90612a38565b80156114aa5780601f1061147f576101008083540402835291602001916114aa565b820191906000526020600020905b81548152906001019060200180831161148d57829003601f168201915b50505050509450600160008a6001600160a01b03166001600160a01b0316815260200190815260200160002060010180546114e490612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461151090612a38565b801561155d5780601f106115325761010080835404028352916020019161155d565b820191906000526020600020905b81548152906001019060200180831161154057829003601f168201915b505050506001600160a01b038b16600090815260016020526040902060020180549299509161158c9150612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546115b890612a38565b80156116055780601f106115da57610100808354040283529160200191611605565b820191906000526020600020905b8154815290600101906020018083116115e857829003601f168201915b505050506001600160a01b038b1660009081526001602052604090206004018054929850916116349150612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461166090612a38565b80156116ad5780601f10611682576101008083540402835291602001916116ad565b820191906000526020600020905b81548152906001019060200180831161169057829003601f168201915b505050506001600160a01b038b1660009081526001602052604090206005018054929650916116dc9150612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461170890612a38565b80156117555780601f1061172a57610100808354040283529160200191611755565b820191906000526020600020905b81548152906001019060200180831161173857829003601f168201915b505050506001600160a01b038b1660009081526001602052604090206006018054929550916117849150612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546117b090612a38565b80156117fd5780601f106117d2576101008083540402835291602001916117fd565b820191906000526020600020905b8154815290600101906020018083116117e057829003601f168201915b505050506001600160a01b038b16600090815260016020526040902060070180549294509161182c9150612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461185890612a38565b80156118a55780601f1061187a576101008083540402835291602001916118a5565b820191906000526020600020905b81548152906001019060200180831161188857829003601f168201915b50505050509050919395975091939597565b6001600160a01b038416600090815260036020908152604090912084516118e0928601906123e4565b506001600160a01b03841660009081526003602090815260409091208351611910926001909201918501906123e4565b506001600160a01b03841660009081526003602090815260409091208251611940926002909201918401906123e4565b5050505050565b6001600160a01b03891660009081526001602090815260409091208951611970928b01906123e4565b506001600160a01b038916600090815260016020818152604090922089516119a0939190920191908a01906123e4565b506001600160a01b038916600090815260016020908152604090912087516119d0926002909201918901906123e4565b506001600160a01b03891660009081526001602090815260409091208651611a00926003909201918801906123e4565b506001600160a01b03891660009081526001602090815260409091208551611a30926004909201918701906123e4565b506001600160a01b03891660009081526001602090815260409091208451611a60926005909201918601906123e4565b506001600160a01b03891660009081526001602090815260409091208351611a90926006909201918501906123e4565b506001600160a01b03891660009081526001602090815260409091208251611ac0926007909201918401906123e4565b50505050505050505050565b6060806060806060600080876001600160a01b03166001600160a01b031681526020019081526020016000206000018054611b0690612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054611b3290612a38565b8015611b7f5780601f10611b5457610100808354040283529160200191611b7f565b820191906000526020600020905b815481529060010190602001808311611b6257829003601f168201915b505050506001600160a01b0388166000908152602081905260409020600101805492975091611bae9150612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054611bda90612a38565b8015611c275780601f10611bfc57610100808354040283529160200191611c27565b820191906000526020600020905b815481529060010190602001808311611c0a57829003601f168201915b505050506001600160a01b0388166000908152602081905260409020600301805492965091611c569150612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054611c8290612a38565b8015611ccf5780601f10611ca457610100808354040283529160200191611ccf565b820191906000526020600020905b815481529060010190602001808311611cb257829003601f168201915b505050506001600160a01b0388166000908152602081905260409020600401805492955091611cfe9150612a38565b80601f0160208091040260200160405190810160405280929190818152602001828054611d2a90612a38565b8015611d775780601f10611d4c57610100808354040283529160200191611d77565b820191906000526020600020905b815481529060010190602001808311611d5a57829003601f168201915b505050506001600160a01b038816600090815260208190526040902060050180549294509161067f9150612a38565b6001600160a01b03861660009081526002602090815260409091208651611dcf928801906123e4565b506001600160a01b03861660009081526002602090815260409091208551611dff926001909201918701906123e4565b506001600160a01b03861660009081526002602081815260409092208551611e2f939190920191908601906123e4565b506001600160a01b03861660009081526002602090815260409091208351611e5f926003909201918501906123e4565b506001600160a01b038616600090815260026020908152604090912082516109e9926004909201918401906123e4565b6001600160a01b03891660009081526001602090815260409091208951611eb8928b01906123e4565b506001600160a01b03891660009081526001602081815260409092208951611ee8939190920191908a01906123e4565b506001600160a01b03891660009081526001602090815260409091208751611f18926002909201918901906123e4565b506001600160a01b03891660009081526001602090815260409091208651611f48926003909201918801906123e4565b506001600160a01b03891660009081526001602090815260409091208551611f78926004909201918701906123e4565b506001600160a01b03891660009081526001602090815260409091208451611fa8926005909201918601906123e4565b506001600160a01b03891660009081526001602090815260409091208351611fd8926006909201918501906123e4565b506001600160a01b03891660009081526001602090815260409091208251612008926007909201918401906123e4565b506005805490600061201983612a73565b9190505550505050505050505050565b60026020526000908152604090208054819061204490612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461207090612a38565b80156120bd5780601f10612092576101008083540402835291602001916120bd565b820191906000526020600020905b8154815290600101906020018083116120a057829003601f168201915b5050505050908060010180546120d290612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546120fe90612a38565b801561214b5780601f106121205761010080835404028352916020019161214b565b820191906000526020600020905b81548152906001019060200180831161212e57829003601f168201915b50505050509080600201805461216090612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461218c90612a38565b80156121d95780601f106121ae576101008083540402835291602001916121d9565b820191906000526020600020905b8154815290600101906020018083116121bc57829003601f168201915b5050505050908060030180546121ee90612a38565b80601f016020809104026020016040519081016040528092919081815260200182805461221a90612a38565b80156122675780601f1061223c57610100808354040283529160200191612267565b820191906000526020600020905b81548152906001019060200180831161224a57829003601f168201915b50505050509080600401805461227c90612a38565b80601f01602080910402602001604051908101604052809291908181526020018280546122a890612a38565b80156122f55780601f106122ca576101008083540402835291602001916122f5565b820191906000526020600020905b8154815290600101906020018083116122d857829003601f168201915b5050505050905085565b6001600160a01b03861660009081526002602090815260409091208651612328928801906123e4565b506001600160a01b03861660009081526002602090815260409091208551612358926001909201918701906123e4565b506001600160a01b03861660009081526002602081815260409092208551612388939190920191908601906123e4565b506001600160a01b038616600090815260026020908152604090912083516123b8926003909201918501906123e4565b506001600160a01b03861660009081526002602090815260409091208251610387926004909201918401905b8280546123f090612a38565b90600052602060002090601f0160209004810192826124125760008555612458565b82601f1061242b57805160ff1916838001178555612458565b82800160010185558215612458579182015b8281111561245857825182559160200191906001019061243d565b50612464929150612468565b5090565b5b808211156124645760008155600101612469565b80356001600160a01b038116811461249457600080fd5b919050565b600082601f8301126124a9578081fd5b813567ffffffffffffffff808211156124c4576124c4612a9a565b604051601f8301601f19908116603f011681019082821181831017156124ec576124ec612a9a565b81604052838152866020858801011115612504578485fd5b8360208701602083013792830160200193909352509392505050565b600060208284031215612531578081fd5b61253a8261247d565b9392505050565b60008060008060808587031215612556578283fd5b61255f8561247d565b9350602085013567ffffffffffffffff8082111561257b578485fd5b61258788838901612499565b9450604087013591508082111561259c578384fd5b6125a888838901612499565b935060608701359150808211156125bd578283fd5b506125ca87828801612499565b91505092959194509250565b60008060008060008060c087890312156125ee578182fd5b6125f78761247d565b9550602087013567ffffffffffffffff80821115612613578384fd5b61261f8a838b01612499565b96506040890135915080821115612634578384fd5b6126408a838b01612499565b95506060890135915080821115612655578384fd5b6126618a838b01612499565b94506080890135915080821115612676578384fd5b6126828a838b01612499565b935060a0890135915080821115612697578283fd5b506126a489828a01612499565b9150509295509295509295565b60008060008060008060008060006101208a8c0312156126cf578283fd5b6126d88a61247d565b985060208a013567ffffffffffffffff808211156126f4578485fd5b6127008d838e01612499565b995060408c0135915080821115612715578485fd5b6127218d838e01612499565b985060608c0135915080821115612736578485fd5b6127428d838e01612499565b975060808c0135915080821115612757578485fd5b6127638d838e01612499565b965060a08c0135915080821115612778578485fd5b6127848d838e01612499565b955060c08c0135915080821115612799578485fd5b6127a58d838e01612499565b945060e08c01359150808211156127ba578384fd5b6127c68d838e01612499565b93506101008c01359150808211156127dc578283fd5b506127e98c828d01612499565b9150509295985092959850929598565b60006020828403121561280a578081fd5b5035919050565b60008151808452815b818110156128365760208185018101518683018201520161281a565b818111156128475782602083870101525b50601f01601f19169290920160200192915050565b600060c0825261286f60c0830189612811565b82810360208401526128818189612811565b6001600160a01b0388166040850152838103606085015290506128a48187612811565b905082810360808401526128b88186612811565b905082810360a08401526128cc8185612811565b9998505050505050505050565b6000606082526128ec6060830186612811565b82810360208401526128fe8186612811565b905082810360408401526129128185612811565b9695505050505050565b600060a0825261292f60a0830188612811565b82810360208401526129418188612811565b905082810360408401526129558187612811565b905082810360608401526129698186612811565b9050828103608084015261297d8185612811565b98975050505050505050565b600061010080835261299d8184018c612811565b905082810360208401526129b1818b612811565b905082810360408401526129c5818a612811565b905082810360608401526129d98189612811565b905082810360808401526129ed8188612811565b905082810360a0840152612a018187612811565b905082810360c0840152612a158186612811565b905082810360e0840152612a298185612811565b9b9a5050505050505050505050565b600281046001821680612a4c57607f821691505b60208210811415612a6d57634e487b7160e01b600052602260045260246000fd5b50919050565b6000600019821415612a9357634e487b7160e01b81526011600452602481fd5b5060010190565b634e487b7160e01b600052604160045260246000fdfea264697066735822122084326192780af2eed93be300cf3f2705a262a2a6a142395f61ece01b0b7c36b664736f6c63430008020033";
        public PatientContractDeploymentBase() : base(BYTECODE) { }
        public PatientContractDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddCommentFunction : AddCommentFunctionBase { }

    [Function("addComment")]
    public class AddCommentFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
        [Parameter("string", "doctorName", 2)]
        public virtual string DoctorName { get; set; }
        [Parameter("string", "date", 3)]
        public virtual string Date { get; set; }
        [Parameter("string", "text", 4)]
        public virtual string Text { get; set; }
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
        [Parameter("string", "visitReason", 5)]
        public virtual string VisitReason { get; set; }
        [Parameter("string", "medicalCondition", 6)]
        public virtual string MedicalCondition { get; set; }
    }

    public partial class CreateInfoFunction : CreateInfoFunctionBase { }

    [Function("createInfo")]
    public class CreateInfoFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
        [Parameter("string", "residentialAddress", 2)]
        public virtual string ResidentialAddress { get; set; }
        [Parameter("string", "postalCode", 3)]
        public virtual string PostalCode { get; set; }
        [Parameter("string", "contactNumber", 4)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "age", 5)]
        public virtual string Age { get; set; }
        [Parameter("string", "gender", 6)]
        public virtual string Gender { get; set; }
        [Parameter("string", "employer", 7)]
        public virtual string Employer { get; set; }
        [Parameter("string", "eduction", 8)]
        public virtual string Eduction { get; set; }
        [Parameter("string", "insurance", 9)]
        public virtual string Insurance { get; set; }
    }

    public partial class CreateMedicsFunction : CreateMedicsFunctionBase { }

    [Function("createMedics")]
    public class CreateMedicsFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
        [Parameter("string", "pastProblems", 2)]
        public virtual string PastProblems { get; set; }
        [Parameter("string", "familyHistory", 3)]
        public virtual string FamilyHistory { get; set; }
        [Parameter("string", "currentProblems", 4)]
        public virtual string CurrentProblems { get; set; }
        [Parameter("string", "medications", 5)]
        public virtual string Medications { get; set; }
        [Parameter("string", "allergies", 6)]
        public virtual string Allergies { get; set; }
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

    public partial class ReadCommentsFunction : ReadCommentsFunctionBase { }

    [Function("readComments", typeof(ReadCommentsOutputDTO))]
    public class ReadCommentsFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
    }

    public partial class ReadInfoFunction : ReadInfoFunctionBase { }

    [Function("readInfo", typeof(ReadInfoOutputDTO))]
    public class ReadInfoFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
    }

    public partial class ReadMedicsFunction : ReadMedicsFunctionBase { }

    [Function("readMedics", typeof(ReadMedicsOutputDTO))]
    public class ReadMedicsFunctionBase : FunctionMessage
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

    public partial class RecordsInfoFunction : RecordsInfoFunctionBase { }

    [Function("recordsInfo", typeof(RecordsInfoOutputDTO))]
    public class RecordsInfoFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class RecordsMedInfoFunction : RecordsMedInfoFunctionBase { }

    [Function("recordsMedInfo", typeof(RecordsMedInfoOutputDTO))]
    public class RecordsMedInfoFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class RecordsReportsFunction : RecordsReportsFunctionBase { }

    [Function("recordsReports", typeof(RecordsReportsOutputDTO))]
    public class RecordsReportsFunctionBase : FunctionMessage
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
        [Parameter("string", "password", 3)]
        public virtual string Password { get; set; }
        [Parameter("string", "hospital", 4)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "visitReason", 5)]
        public virtual string VisitReason { get; set; }
        [Parameter("string", "medicalCondition", 6)]
        public virtual string MedicalCondition { get; set; }
    }

    public partial class UpdateInfoFunction : UpdateInfoFunctionBase { }

    [Function("updateInfo")]
    public class UpdateInfoFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
        [Parameter("string", "residentialAddress", 2)]
        public virtual string ResidentialAddress { get; set; }
        [Parameter("string", "postalCode", 3)]
        public virtual string PostalCode { get; set; }
        [Parameter("string", "contactNumber", 4)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "age", 5)]
        public virtual string Age { get; set; }
        [Parameter("string", "gender", 6)]
        public virtual string Gender { get; set; }
        [Parameter("string", "employer", 7)]
        public virtual string Employer { get; set; }
        [Parameter("string", "eduction", 8)]
        public virtual string Eduction { get; set; }
        [Parameter("string", "insurance", 9)]
        public virtual string Insurance { get; set; }
    }

    public partial class UpdateMedicsFunction : UpdateMedicsFunctionBase { }

    [Function("updateMedics")]
    public class UpdateMedicsFunctionBase : FunctionMessage
    {
        [Parameter("address", "add", 1)]
        public virtual string Add { get; set; }
        [Parameter("string", "pastProblems", 2)]
        public virtual string PastProblems { get; set; }
        [Parameter("string", "familyHistory", 3)]
        public virtual string FamilyHistory { get; set; }
        [Parameter("string", "currentProblems", 4)]
        public virtual string CurrentProblems { get; set; }
        [Parameter("string", "medications", 5)]
        public virtual string Medications { get; set; }
        [Parameter("string", "allergies", 6)]
        public virtual string Allergies { get; set; }
    }

    public partial class UsersFunction : UsersFunctionBase { }

    [Function("users", typeof(UsersOutputDTO))]
    public class UsersFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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
        [Parameter("string", "_password", 2)]
        public virtual string Password { get; set; }
        [Parameter("string", "_hospital", 3)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "_visitReason", 4)]
        public virtual string VisitReason { get; set; }
        [Parameter("string", "_medicalCondition", 5)]
        public virtual string MedicalCondition { get; set; }
    }

    public partial class ReadCommentsOutputDTO : ReadCommentsOutputDTOBase { }

    [FunctionOutput]
    public class ReadCommentsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "_doctorName", 1)]
        public virtual string DoctorName { get; set; }
        [Parameter("string", "_date", 2)]
        public virtual string Date { get; set; }
        [Parameter("string", "_text", 3)]
        public virtual string Text { get; set; }
    }

    public partial class ReadInfoOutputDTO : ReadInfoOutputDTOBase { }

    [FunctionOutput]
    public class ReadInfoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "_residentialAddress", 1)]
        public virtual string ResidentialAddress { get; set; }
        [Parameter("string", "_postalCode", 2)]
        public virtual string PostalCode { get; set; }
        [Parameter("string", "_contactNumber", 3)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "_age", 4)]
        public virtual string Age { get; set; }
        [Parameter("string", "_gender", 5)]
        public virtual string Gender { get; set; }
        [Parameter("string", "_employer", 6)]
        public virtual string Employer { get; set; }
        [Parameter("string", "_eduction", 7)]
        public virtual string Eduction { get; set; }
        [Parameter("string", "_insurance", 8)]
        public virtual string Insurance { get; set; }
    }

    public partial class ReadMedicsOutputDTO : ReadMedicsOutputDTOBase { }

    [FunctionOutput]
    public class ReadMedicsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "_pastProblems", 1)]
        public virtual string PastProblems { get; set; }
        [Parameter("string", "_familyHistory", 2)]
        public virtual string FamilyHistory { get; set; }
        [Parameter("string", "_currentProblems", 3)]
        public virtual string CurrentProblems { get; set; }
        [Parameter("string", "_medications", 4)]
        public virtual string Medications { get; set; }
        [Parameter("string", "_allergies", 5)]
        public virtual string Allergies { get; set; }
    }

    public partial class RecordsOutputDTO : RecordsOutputDTOBase { }

    [FunctionOutput]
    public class RecordsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "password", 2)]
        public virtual string Password { get; set; }
        [Parameter("address", "add", 3)]
        public virtual string Add { get; set; }
        [Parameter("string", "hospital", 4)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "visitReason", 5)]
        public virtual string VisitReason { get; set; }
        [Parameter("string", "medicalCondition", 6)]
        public virtual string MedicalCondition { get; set; }
    }

    public partial class RecordsInfoOutputDTO : RecordsInfoOutputDTOBase { }

    [FunctionOutput]
    public class RecordsInfoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "residentialAddress", 1)]
        public virtual string ResidentialAddress { get; set; }
        [Parameter("string", "postalCode", 2)]
        public virtual string PostalCode { get; set; }
        [Parameter("string", "contactNumber", 3)]
        public virtual string ContactNumber { get; set; }
        [Parameter("string", "age", 4)]
        public virtual string Age { get; set; }
        [Parameter("string", "gender", 5)]
        public virtual string Gender { get; set; }
        [Parameter("string", "employer", 6)]
        public virtual string Employer { get; set; }
        [Parameter("string", "eduction", 7)]
        public virtual string Eduction { get; set; }
        [Parameter("string", "insurance", 8)]
        public virtual string Insurance { get; set; }
    }

    public partial class RecordsMedInfoOutputDTO : RecordsMedInfoOutputDTOBase { }

    [FunctionOutput]
    public class RecordsMedInfoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "pastProblems", 1)]
        public virtual string PastProblems { get; set; }
        [Parameter("string", "familyHistory", 2)]
        public virtual string FamilyHistory { get; set; }
        [Parameter("string", "currentProblems", 3)]
        public virtual string CurrentProblems { get; set; }
        [Parameter("string", "medications", 4)]
        public virtual string Medications { get; set; }
        [Parameter("string", "allergies", 5)]
        public virtual string Allergies { get; set; }
    }

    public partial class RecordsReportsOutputDTO : RecordsReportsOutputDTOBase { }

    [FunctionOutput]
    public class RecordsReportsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "doctorName", 1)]
        public virtual string DoctorName { get; set; }
        [Parameter("string", "date", 2)]
        public virtual string Date { get; set; }
        [Parameter("string", "text", 3)]
        public virtual string Text { get; set; }
    }







    public partial class UsersOutputDTO : UsersOutputDTOBase { }

    [FunctionOutput]
    public class UsersOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "password", 2)]
        public virtual string Password { get; set; }
        [Parameter("address", "add", 3)]
        public virtual string Add { get; set; }
        [Parameter("string", "hospital", 4)]
        public virtual string Hospital { get; set; }
        [Parameter("string", "visitReason", 5)]
        public virtual string VisitReason { get; set; }
        [Parameter("string", "medicalCondition", 6)]
        public virtual string MedicalCondition { get; set; }
    }
}
