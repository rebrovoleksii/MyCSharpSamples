﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace People.Library.WcfServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WcfServiceClient.IPeopleService")]
    public interface IPeopleService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeopleService/GetPeople", ReplyAction="http://tempuri.org/IPeopleService/GetPeopleResponse")]
        string[] GetPeople();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPeopleService/GetPeople", ReplyAction="http://tempuri.org/IPeopleService/GetPeopleResponse")]
        System.Threading.Tasks.Task<string[]> GetPeopleAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPeopleServiceChannel : People.Library.WcfServiceClient.IPeopleService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PeopleServiceClient : System.ServiceModel.ClientBase<People.Library.WcfServiceClient.IPeopleService>, People.Library.WcfServiceClient.IPeopleService {
        
        public PeopleServiceClient() {
        }
        
        public PeopleServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PeopleServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PeopleServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PeopleServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetPeople() {
            return base.Channel.GetPeople();
        }
        
        public System.Threading.Tasks.Task<string[]> GetPeopleAsync() {
            return base.Channel.GetPeopleAsync();
        }
    }
}