﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebStore.WebUi.AuthenticationService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticationService.IAuthenticationService")]
    public interface IAuthenticationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/CheckUser", ReplyAction="http://tempuri.org/IAuthenticationService/CheckUserResponse")]
        bool CheckUser(string userName, string userPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/CheckUser", ReplyAction="http://tempuri.org/IAuthenticationService/CheckUserResponse")]
        System.Threading.Tasks.Task<bool> CheckUserAsync(string userName, string userPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/RegisterUser", ReplyAction="http://tempuri.org/IAuthenticationService/RegisterUserResponse")]
        bool RegisterUser(string userName, string userPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticationService/RegisterUser", ReplyAction="http://tempuri.org/IAuthenticationService/RegisterUserResponse")]
        System.Threading.Tasks.Task<bool> RegisterUserAsync(string userName, string userPassword);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationServiceChannel : WebStore.WebUi.AuthenticationService.IAuthenticationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationServiceClient : System.ServiceModel.ClientBase<WebStore.WebUi.AuthenticationService.IAuthenticationService>, WebStore.WebUi.AuthenticationService.IAuthenticationService {
        
        public AuthenticationServiceClient() {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CheckUser(string userName, string userPassword) {
            return base.Channel.CheckUser(userName, userPassword);
        }
        
        public System.Threading.Tasks.Task<bool> CheckUserAsync(string userName, string userPassword) {
            return base.Channel.CheckUserAsync(userName, userPassword);
        }
        
        public bool RegisterUser(string userName, string userPassword) {
            return base.Channel.RegisterUser(userName, userPassword);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterUserAsync(string userName, string userPassword) {
            return base.Channel.RegisterUserAsync(userName, userPassword);
        }
    }
}