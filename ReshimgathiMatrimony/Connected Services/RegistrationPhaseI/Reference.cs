﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReshimgathiMatrimony.RegistrationPhaseI {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RegistrationPhaseI.IRegistrationPhaseI")]
    public interface IRegistrationPhaseI {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationPhaseI/IsRegistrationEnabledToday", ReplyAction="http://tempuri.org/IRegistrationPhaseI/IsRegistrationEnabledTodayResponse")]
        bool IsRegistrationEnabledToday();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRegistrationPhaseI/IsRegistrationEnabledToday", ReplyAction="http://tempuri.org/IRegistrationPhaseI/IsRegistrationEnabledTodayResponse")]
        System.Threading.Tasks.Task<bool> IsRegistrationEnabledTodayAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegistrationPhaseIChannel : ReshimgathiMatrimony.RegistrationPhaseI.IRegistrationPhaseI, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegistrationPhaseIClient : System.ServiceModel.ClientBase<ReshimgathiMatrimony.RegistrationPhaseI.IRegistrationPhaseI>, ReshimgathiMatrimony.RegistrationPhaseI.IRegistrationPhaseI {
        
        public RegistrationPhaseIClient() {
        }
        
        public RegistrationPhaseIClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RegistrationPhaseIClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrationPhaseIClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RegistrationPhaseIClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsRegistrationEnabledToday() {
            return base.Channel.IsRegistrationEnabledToday();
        }
        
        public System.Threading.Tasks.Task<bool> IsRegistrationEnabledTodayAsync() {
            return base.Channel.IsRegistrationEnabledTodayAsync();
        }
    }
}
