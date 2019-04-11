﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Net.Sockets;
using System.ServiceModel;
using System.Windows;

namespace Chat.ChatServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatServer.IServer", SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IServer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/CheckUser", ReplyAction="http://tempuri.org/IServer/CheckUserResponse")]
        bool CheckUser(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/CheckUser", ReplyAction="http://tempuri.org/IServer/CheckUserResponse")]
        System.Threading.Tasks.Task<bool> CheckUserAsync(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerChannel : Chat.ChatServer.IServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerClient : System.ServiceModel.ClientBase<Chat.ChatServer.IServer>, Chat.ChatServer.IServer {
        
        public ServerClient() {
        }
        
        public ServerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CheckUser(string username, string password) {          
            return base.Channel.CheckUser(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> CheckUserAsync(string username, string password) {
            return base.Channel.CheckUserAsync(username, password);
        }
    }
}
