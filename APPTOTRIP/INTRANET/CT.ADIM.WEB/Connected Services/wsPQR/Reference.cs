﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CT.ADIM.WEB.wsPQR {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wsPQR.wsPQRSoap")]
    public interface wsPQRSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/crearPQRPr", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string crearPQRPr(string id, string origen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/crearPQRPr", ReplyAction="*")]
        System.Threading.Tasks.Task<string> crearPQRPrAsync(string id, string origen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/crearPQR", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string crearPQR(string id, string origen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/crearPQR", ReplyAction="*")]
        System.Threading.Tasks.Task<string> crearPQRAsync(string id, string origen);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface wsPQRSoapChannel : CT.ADIM.WEB.wsPQR.wsPQRSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class wsPQRSoapClient : System.ServiceModel.ClientBase<CT.ADIM.WEB.wsPQR.wsPQRSoap>, CT.ADIM.WEB.wsPQR.wsPQRSoap {
        
        public wsPQRSoapClient() {
        }
        
        public wsPQRSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public wsPQRSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsPQRSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public wsPQRSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string crearPQRPr(string id, string origen) {
            return base.Channel.crearPQRPr(id, origen);
        }
        
        public System.Threading.Tasks.Task<string> crearPQRPrAsync(string id, string origen) {
            return base.Channel.crearPQRPrAsync(id, origen);
        }
        
        public string crearPQR(string id, string origen) {
            return base.Channel.crearPQR(id, origen);
        }
        
        public System.Threading.Tasks.Task<string> crearPQRAsync(string id, string origen) {
            return base.Channel.crearPQRAsync(id, origen);
        }
    }
}
