﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFKOISYSTEM.MVCWEBAPP.SERVICE {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SERVICE.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTravels", ReplyAction="http://tempuri.org/IService1/GetTravelsResponse")]
        WCFKOISTSTEM.SERVICE.Travel[] GetTravels();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTravels", ReplyAction="http://tempuri.org/IService1/GetTravelsResponse")]
        System.Threading.Tasks.Task<WCFKOISTSTEM.SERVICE.Travel[]> GetTravelsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateOrUpdateTravel", ReplyAction="http://tempuri.org/IService1/CreateOrUpdateTravelResponse")]
        bool CreateOrUpdateTravel(WCFKOISTSTEM.SERVICE.Travel travel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateOrUpdateTravel", ReplyAction="http://tempuri.org/IService1/CreateOrUpdateTravelResponse")]
        System.Threading.Tasks.Task<bool> CreateOrUpdateTravelAsync(WCFKOISTSTEM.SERVICE.Travel travel);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteTravel", ReplyAction="http://tempuri.org/IService1/DeleteTravelResponse")]
        bool DeleteTravel(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DeleteTravel", ReplyAction="http://tempuri.org/IService1/DeleteTravelResponse")]
        System.Threading.Tasks.Task<bool> DeleteTravelAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTravelById", ReplyAction="http://tempuri.org/IService1/GetTravelByIdResponse")]
        WCFKOISTSTEM.SERVICE.Travel GetTravelById(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetTravelById", ReplyAction="http://tempuri.org/IService1/GetTravelByIdResponse")]
        System.Threading.Tasks.Task<WCFKOISTSTEM.SERVICE.Travel> GetTravelByIdAsync(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WCFKOISYSTEM.MVCWEBAPP.SERVICE.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WCFKOISYSTEM.MVCWEBAPP.SERVICE.IService1>, WCFKOISYSTEM.MVCWEBAPP.SERVICE.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCFKOISTSTEM.SERVICE.Travel[] GetTravels() {
            return base.Channel.GetTravels();
        }
        
        public System.Threading.Tasks.Task<WCFKOISTSTEM.SERVICE.Travel[]> GetTravelsAsync() {
            return base.Channel.GetTravelsAsync();
        }
        
        public bool CreateOrUpdateTravel(WCFKOISTSTEM.SERVICE.Travel travel) {
            return base.Channel.CreateOrUpdateTravel(travel);
        }
        
        public System.Threading.Tasks.Task<bool> CreateOrUpdateTravelAsync(WCFKOISTSTEM.SERVICE.Travel travel) {
            return base.Channel.CreateOrUpdateTravelAsync(travel);
        }
        
        public bool DeleteTravel(string id) {
            return base.Channel.DeleteTravel(id);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteTravelAsync(string id) {
            return base.Channel.DeleteTravelAsync(id);
        }
        
        public WCFKOISTSTEM.SERVICE.Travel GetTravelById(string id) {
            return base.Channel.GetTravelById(id);
        }
        
        public System.Threading.Tasks.Task<WCFKOISTSTEM.SERVICE.Travel> GetTravelByIdAsync(string id) {
            return base.Channel.GetTravelByIdAsync(id);
        }
    }
}
