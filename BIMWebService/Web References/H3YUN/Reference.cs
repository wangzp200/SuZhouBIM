﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

#pragma warning disable 1591

namespace BIMWebService.Web_References.H3YUN {
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [WebServiceBinding(Name="BizObjectServiceSoap", Namespace="http://tempuri.org/")]
    public partial class BizObjectService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private Authentication authenticationValueField;
        
        private System.Threading.SendOrPostCallback CreatesOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateBizObjectOperationCompleted;
        
        private System.Threading.SendOrPostCallback LoadBizObjectOperationCompleted;
        
        private System.Threading.SendOrPostCallback RemoveBizObjectOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BizObjectService() {
            this.Url = global::BIMWebService.Properties.Settings.Default.DingDingWebService_com_h3yun_www_BizObjectService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public Authentication AuthenticationValue {
            get {
                return this.authenticationValueField;
            }
            set {
                this.authenticationValueField = value;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event CreatesCompletedEventHandler CreatesCompleted;
        
        /// <remarks/>
        public event CreateCompletedEventHandler CreateCompleted;
        
        /// <remarks/>
        public event UpdateBizObjectCompletedEventHandler UpdateBizObjectCompleted;
        
        /// <remarks/>
        public event LoadBizObjectCompletedEventHandler LoadBizObjectCompleted;
        
        /// <remarks/>
        public event RemoveBizObjectCompletedEventHandler RemoveBizObjectCompleted;
        
        /// <remarks/>
        [SoapHeader("AuthenticationValue")]
        [SoapDocumentMethod("http://tempuri.org/Creates", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Creates(string schemaCode, string[] datas, bool submit) {
            object[] results = this.Invoke("Creates", new object[] {
                        schemaCode,
                        datas,
                        submit});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CreatesAsync(string schemaCode, string[] datas, bool submit) {
            this.CreatesAsync(schemaCode, datas, submit, null);
        }
        
        /// <remarks/>
        public void CreatesAsync(string schemaCode, string[] datas, bool submit, object userState) {
            if ((this.CreatesOperationCompleted == null)) {
                this.CreatesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreatesOperationCompleted);
            }
            this.InvokeAsync("Creates", new object[] {
                        schemaCode,
                        datas,
                        submit}, this.CreatesOperationCompleted, userState);
        }
        
        private void OnCreatesOperationCompleted(object arg) {
            if ((this.CreatesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreatesCompleted(this, new CreatesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [SoapHeader("AuthenticationValue")]
        [SoapDocumentMethod("http://tempuri.org/Create", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Create(string schemaCode, string data, bool submit) {
            object[] results = this.Invoke("Create", new object[] {
                        schemaCode,
                        data,
                        submit});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CreateAsync(string schemaCode, string data, bool submit) {
            this.CreateAsync(schemaCode, data, submit, null);
        }
        
        /// <remarks/>
        public void CreateAsync(string schemaCode, string data, bool submit, object userState) {
            if ((this.CreateOperationCompleted == null)) {
                this.CreateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateOperationCompleted);
            }
            this.InvokeAsync("Create", new object[] {
                        schemaCode,
                        data,
                        submit}, this.CreateOperationCompleted, userState);
        }
        
        private void OnCreateOperationCompleted(object arg) {
            if ((this.CreateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateCompleted(this, new CreateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [SoapHeader("AuthenticationValue")]
        [SoapDocumentMethod("http://tempuri.org/UpdateBizObject", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string UpdateBizObject(string schemaCode, string objectId, string data) {
            object[] results = this.Invoke("UpdateBizObject", new object[] {
                        schemaCode,
                        objectId,
                        data});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateBizObjectAsync(string schemaCode, string objectId, string data) {
            this.UpdateBizObjectAsync(schemaCode, objectId, data, null);
        }
        
        /// <remarks/>
        public void UpdateBizObjectAsync(string schemaCode, string objectId, string data, object userState) {
            if ((this.UpdateBizObjectOperationCompleted == null)) {
                this.UpdateBizObjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateBizObjectOperationCompleted);
            }
            this.InvokeAsync("UpdateBizObject", new object[] {
                        schemaCode,
                        objectId,
                        data}, this.UpdateBizObjectOperationCompleted, userState);
        }
        
        private void OnUpdateBizObjectOperationCompleted(object arg) {
            if ((this.UpdateBizObjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateBizObjectCompleted(this, new UpdateBizObjectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [SoapHeader("AuthenticationValue")]
        [SoapDocumentMethod("http://tempuri.org/LoadBizObject", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string LoadBizObject(string schemaCode, string objectId) {
            object[] results = this.Invoke("LoadBizObject", new object[] {
                        schemaCode,
                        objectId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LoadBizObjectAsync(string schemaCode, string objectId) {
            this.LoadBizObjectAsync(schemaCode, objectId, null);
        }
        
        /// <remarks/>
        public void LoadBizObjectAsync(string schemaCode, string objectId, object userState) {
            if ((this.LoadBizObjectOperationCompleted == null)) {
                this.LoadBizObjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLoadBizObjectOperationCompleted);
            }
            this.InvokeAsync("LoadBizObject", new object[] {
                        schemaCode,
                        objectId}, this.LoadBizObjectOperationCompleted, userState);
        }
        
        private void OnLoadBizObjectOperationCompleted(object arg) {
            if ((this.LoadBizObjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LoadBizObjectCompleted(this, new LoadBizObjectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [SoapHeader("AuthenticationValue")]
        [SoapDocumentMethod("http://tempuri.org/RemoveBizObject", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RemoveBizObject(string schemaCode, string objectId) {
            object[] results = this.Invoke("RemoveBizObject", new object[] {
                        schemaCode,
                        objectId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RemoveBizObjectAsync(string schemaCode, string objectId) {
            this.RemoveBizObjectAsync(schemaCode, objectId, null);
        }
        
        /// <remarks/>
        public void RemoveBizObjectAsync(string schemaCode, string objectId, object userState) {
            if ((this.RemoveBizObjectOperationCompleted == null)) {
                this.RemoveBizObjectOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRemoveBizObjectOperationCompleted);
            }
            this.InvokeAsync("RemoveBizObject", new object[] {
                        schemaCode,
                        objectId}, this.RemoveBizObjectOperationCompleted, userState);
        }
        
        private void OnRemoveBizObjectOperationCompleted(object arg) {
            if ((this.RemoveBizObjectCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RemoveBizObjectCompleted(this, new RemoveBizObjectCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1586.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace="http://tempuri.org/")]
    [XmlRoot(Namespace="http://tempuri.org/", IsNullable=false)]
    public partial class Authentication : System.Web.Services.Protocols.SoapHeader {
        
        private string engineCodeField;
        
        private string corpIdField;
        
        private string secretField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        public string EngineCode {
            get {
                return this.engineCodeField;
            }
            set {
                this.engineCodeField = value;
            }
        }
        
        /// <remarks/>
        public string CorpId {
            get {
                return this.corpIdField;
            }
            set {
                this.corpIdField = value;
            }
        }
        
        /// <remarks/>
        public string Secret {
            get {
                return this.secretField;
            }
            set {
                this.secretField = value;
            }
        }
        
        /// <remarks/>
        [XmlAnyAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr {
            get {
                return this.anyAttrField;
            }
            set {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CreatesCompletedEventHandler(object sender, CreatesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class CreatesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreatesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void CreateCompletedEventHandler(object sender, CreateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class CreateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void UpdateBizObjectCompletedEventHandler(object sender, UpdateBizObjectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class UpdateBizObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateBizObjectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void LoadBizObjectCompletedEventHandler(object sender, LoadBizObjectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class LoadBizObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LoadBizObjectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    public delegate void RemoveBizObjectCompletedEventHandler(object sender, RemoveBizObjectCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1586.0")]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class RemoveBizObjectCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RemoveBizObjectCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591