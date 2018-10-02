﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReshimgathiMatrimony.LoginServices {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDetails", Namespace="http://schemas.datacontract.org/2004/07/ReshimgathiMatrimony")]
    [System.SerializableAttribute()]
    public partial class UserDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> CreateDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> IsVerifiedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> UpdatedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<bool> UserTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> CreateDate {
            get {
                return this.CreateDateField;
            }
            set {
                if ((this.CreateDateField.Equals(value) != true)) {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> IsVerified {
            get {
                return this.IsVerifiedField;
            }
            set {
                if ((this.IsVerifiedField.Equals(value) != true)) {
                    this.IsVerifiedField = value;
                    this.RaisePropertyChanged("IsVerified");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> UpdatedDate {
            get {
                return this.UpdatedDateField;
            }
            set {
                if ((this.UpdatedDateField.Equals(value) != true)) {
                    this.UpdatedDateField = value;
                    this.RaisePropertyChanged("UpdatedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<bool> UserType {
            get {
                return this.UserTypeField;
            }
            set {
                if ((this.UserTypeField.Equals(value) != true)) {
                    this.UserTypeField = value;
                    this.RaisePropertyChanged("UserType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserType", Namespace="http://schemas.datacontract.org/2004/07/ReshimgathiMatrimony")]
    public enum UserType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        User = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Admin = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="LoginServices.ILoginService")]
    public interface ILoginService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/IsLoggedUserPresent", ReplyAction="http://tempuri.org/ILoginService/IsLoggedUserPresentResponse")]
        bool IsLoggedUserPresent(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/IsLoggedUserPresent", ReplyAction="http://tempuri.org/ILoginService/IsLoggedUserPresentResponse")]
        System.Threading.Tasks.Task<bool> IsLoggedUserPresentAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/IsLogInUserVerified", ReplyAction="http://tempuri.org/ILoginService/IsLogInUserVerifiedResponse")]
        bool IsLogInUserVerified(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/IsLogInUserVerified", ReplyAction="http://tempuri.org/ILoginService/IsLogInUserVerifiedResponse")]
        System.Threading.Tasks.Task<bool> IsLogInUserVerifiedAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/GetUserDetails", ReplyAction="http://tempuri.org/ILoginService/GetUserDetailsResponse")]
        ReshimgathiMatrimony.LoginServices.UserDetails GetUserDetails(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/GetUserDetails", ReplyAction="http://tempuri.org/ILoginService/GetUserDetailsResponse")]
        System.Threading.Tasks.Task<ReshimgathiMatrimony.LoginServices.UserDetails> GetUserDetailsAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/LoggedUserType", ReplyAction="http://tempuri.org/ILoginService/LoggedUserTypeResponse")]
        ReshimgathiMatrimony.LoginServices.UserType LoggedUserType(string userName, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILoginService/LoggedUserType", ReplyAction="http://tempuri.org/ILoginService/LoggedUserTypeResponse")]
        System.Threading.Tasks.Task<ReshimgathiMatrimony.LoginServices.UserType> LoggedUserTypeAsync(string userName, string Password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoginServiceChannel : ReshimgathiMatrimony.LoginServices.ILoginService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginServiceClient : System.ServiceModel.ClientBase<ReshimgathiMatrimony.LoginServices.ILoginService>, ReshimgathiMatrimony.LoginServices.ILoginService {
        
        public LoginServiceClient() {
        }
        
        public LoginServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsLoggedUserPresent(string username, string password) {
            return base.Channel.IsLoggedUserPresent(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsLoggedUserPresentAsync(string username, string password) {
            return base.Channel.IsLoggedUserPresentAsync(username, password);
        }
        
        public bool IsLogInUserVerified(string userName, string password) {
            return base.Channel.IsLogInUserVerified(userName, password);
        }
        
        public System.Threading.Tasks.Task<bool> IsLogInUserVerifiedAsync(string userName, string password) {
            return base.Channel.IsLogInUserVerifiedAsync(userName, password);
        }
        
        public ReshimgathiMatrimony.LoginServices.UserDetails GetUserDetails(string userName, string password) {
            return base.Channel.GetUserDetails(userName, password);
        }
        
        public System.Threading.Tasks.Task<ReshimgathiMatrimony.LoginServices.UserDetails> GetUserDetailsAsync(string userName, string password) {
            return base.Channel.GetUserDetailsAsync(userName, password);
        }
        
        public ReshimgathiMatrimony.LoginServices.UserType LoggedUserType(string userName, string Password) {
            return base.Channel.LoggedUserType(userName, Password);
        }
        
        public System.Threading.Tasks.Task<ReshimgathiMatrimony.LoginServices.UserType> LoggedUserTypeAsync(string userName, string Password) {
            return base.Channel.LoggedUserTypeAsync(userName, Password);
        }
    }
}
