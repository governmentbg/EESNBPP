﻿namespace NBPPRegixClient
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "NBPPRegixClient.IRegiXEntryPoint")]
    public interface IRegiXEntryPoint
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRegiXEntryPoint/Execute", ReplyAction = "http://tempuri.org/IRegiXEntryPoint/ExecuteResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AccessMatrixType))]
        ServiceExecuteResult Execute(ServiceRequestData request);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRegiXEntryPoint/CheckResult", ReplyAction = "http://tempuri.org/IRegiXEntryPoint/CheckResultResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AccessMatrixType))]
        ServiceResultData CheckResult(ServiceCheckResultArgument argument);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IRegiXEntryPoint/ExecuteSynchronous", ReplyAction = "http://tempuri.org/IRegiXEntryPoint/ExecuteSynchronousResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AccessMatrixType))]
        ServiceResultData ExecuteSynchronous(ServiceRequestData request);
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class ServiceRequestData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string operationField;

        private System.Xml.XmlElement argumentField;

        private string eIDTokenField;

        private CallContext callContextField;

        private string callbackURLField;

        private string employeeEGNField;

        private string citizenEGNField;

        private bool signResultField;

        private bool returnAccessMatrixField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string Operation
        {
            get
            {
                return this.operationField;
            }
            set
            {
                this.operationField = value;
                this.RaisePropertyChanged("Operation");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public System.Xml.XmlElement Argument
        {
            get
            {
                return this.argumentField;
            }
            set
            {
                this.argumentField = value;
                this.RaisePropertyChanged("Argument");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string EIDToken
        {
            get
            {
                return this.eIDTokenField;
            }
            set
            {
                this.eIDTokenField = value;
                this.RaisePropertyChanged("EIDToken");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public CallContext CallContext
        {
            get
            {
                return this.callContextField;
            }
            set
            {
                this.callContextField = value;
                this.RaisePropertyChanged("CallContext");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string CallbackURL
        {
            get
            {
                return this.callbackURLField;
            }
            set
            {
                this.callbackURLField = value;
                this.RaisePropertyChanged("CallbackURL");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string EmployeeEGN
        {
            get
            {
                return this.employeeEGNField;
            }
            set
            {
                this.employeeEGNField = value;
                this.RaisePropertyChanged("EmployeeEGN");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string CitizenEGN
        {
            get
            {
                return this.citizenEGNField;
            }
            set
            {
                this.citizenEGNField = value;
                this.RaisePropertyChanged("CitizenEGN");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        public bool SignResult
        {
            get
            {
                return this.signResultField;
            }
            set
            {
                this.signResultField = value;
                this.RaisePropertyChanged("SignResult");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        public bool ReturnAccessMatrix
        {
            get
            {
                return this.returnAccessMatrixField;
            }
            set
            {
                this.returnAccessMatrixField = value;
                this.RaisePropertyChanged("ReturnAccessMatrix");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class CallContext : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string serviceURIField;

        private string serviceTypeField;

        private string employeeIdentifierField;

        private string employeeNamesField;

        private string employeeAditionalIdentifierField;

        private string employeePositionField;

        private string administrationOIdField;

        private string administrationNameField;

        private string responsiblePersonIdentifierField;

        private string lawReasonField;

        private string remarkField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public string ServiceURI
        {
            get
            {
                return this.serviceURIField;
            }
            set
            {
                this.serviceURIField = value;
                this.RaisePropertyChanged("ServiceURI");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string ServiceType
        {
            get
            {
                return this.serviceTypeField;
            }
            set
            {
                this.serviceTypeField = value;
                this.RaisePropertyChanged("ServiceType");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string EmployeeIdentifier
        {
            get
            {
                return this.employeeIdentifierField;
            }
            set
            {
                this.employeeIdentifierField = value;
                this.RaisePropertyChanged("EmployeeIdentifier");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 3)]
        public string EmployeeNames
        {
            get
            {
                return this.employeeNamesField;
            }
            set
            {
                this.employeeNamesField = value;
                this.RaisePropertyChanged("EmployeeNames");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string EmployeeAditionalIdentifier
        {
            get
            {
                return this.employeeAditionalIdentifierField;
            }
            set
            {
                this.employeeAditionalIdentifierField = value;
                this.RaisePropertyChanged("EmployeeAditionalIdentifier");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 5)]
        public string EmployeePosition
        {
            get
            {
                return this.employeePositionField;
            }
            set
            {
                this.employeePositionField = value;
                this.RaisePropertyChanged("EmployeePosition");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 6)]
        public string AdministrationOId
        {
            get
            {
                return this.administrationOIdField;
            }
            set
            {
                this.administrationOIdField = value;
                this.RaisePropertyChanged("AdministrationOId");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 7)]
        public string AdministrationName
        {
            get
            {
                return this.administrationNameField;
            }
            set
            {
                this.administrationNameField = value;
                this.RaisePropertyChanged("AdministrationName");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 8)]
        public string ResponsiblePersonIdentifier
        {
            get
            {
                return this.responsiblePersonIdentifierField;
            }
            set
            {
                this.responsiblePersonIdentifierField = value;
                this.RaisePropertyChanged("ResponsiblePersonIdentifier");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        public string LawReason
        {
            get
            {
                return this.lawReasonField;
            }
            set
            {
                this.lawReasonField = value;
                this.RaisePropertyChanged("LawReason");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 10)]
        public string Remark
        {
            get
            {
                return this.remarkField;
            }
            set
            {
                this.remarkField = value;
                this.RaisePropertyChanged("Remark");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class AMPropertyType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private bool hasAccessField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public bool HasAccess
        {
            get
            {
                return this.hasAccessField;
            }
            set
            {
                this.hasAccessField = value;
                this.RaisePropertyChanged("HasAccess");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class AccessMatrixType : object, System.ComponentModel.INotifyPropertyChanged
    {

        private bool hasAccessField;

        private string nameField;

        private AMPropertyType[] propertiesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public bool HasAccess
        {
            get
            {
                return this.hasAccessField;
            }
            set
            {
                this.hasAccessField = value;
                this.RaisePropertyChanged("HasAccess");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Property", IsNullable = false)]
        public AMPropertyType[] Properties
        {
            get
            {
                return this.propertiesField;
            }
            set
            {
                this.propertiesField = value;
                this.RaisePropertyChanged("Properties");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class ResponseContainer : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.Xml.XmlElement anyField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        public System.Xml.XmlElement Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
                this.RaisePropertyChanged("Any");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class RequestContainer : object, System.ComponentModel.INotifyPropertyChanged
    {

        private System.Xml.XmlElement anyField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 0)]
        public System.Xml.XmlElement Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
                this.RaisePropertyChanged("Any");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class DataContainer : object, System.ComponentModel.INotifyPropertyChanged
    {

        private RequestContainer requestField;

        private ResponseContainer responseField;

        private DataContainerMatrix matrixField;

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public RequestContainer Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
                this.RaisePropertyChanged("Request");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public ResponseContainer Response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
                this.RaisePropertyChanged("Response");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public DataContainerMatrix Matrix
        {
            get
            {
                return this.matrixField;
            }
            set
            {
                this.matrixField = value;
                this.RaisePropertyChanged("Matrix");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
    public partial class DataContainerMatrix : AccessMatrixType
    {

        private string idField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
                this.RaisePropertyChanged("id");
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class ServiceResultData : object, System.ComponentModel.INotifyPropertyChanged
    {

        private bool isReadyField;

        private DataContainer dataField;

        private System.Xml.XmlElement signatureField;

        private bool hasErrorField;

        private string errorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public bool IsReady
        {
            get
            {
                return this.isReadyField;
            }
            set
            {
                this.isReadyField = value;
                this.RaisePropertyChanged("IsReady");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 1)]
        public DataContainer Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
                this.RaisePropertyChanged("Data");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Name = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 2)]
        public System.Xml.XmlElement Signature
        {
            get
            {
                return this.signatureField;
            }
            set
            {
                this.signatureField = value;
                this.RaisePropertyChanged("Signature");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        public bool HasError
        {
            get
            {
                return this.hasErrorField;
            }
            set
            {
                this.hasErrorField = value;
                this.RaisePropertyChanged("HasError");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 4)]
        public string Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
                this.RaisePropertyChanged("Error");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class ServiceCheckResultArgument : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal serviceCallIDField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal ServiceCallID
        {
            get
            {
                return this.serviceCallIDField;
            }
            set
            {
                this.serviceCallIDField = value;
                this.RaisePropertyChanged("ServiceCallID");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://tempuri.org/")]
    public partial class ServiceExecuteResult : object, System.ComponentModel.INotifyPropertyChanged
    {

        private decimal serviceCallIDField;

        private bool hasErrorField;

        private string errorField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public decimal ServiceCallID
        {
            get
            {
                return this.serviceCallIDField;
            }
            set
            {
                this.serviceCallIDField = value;
                this.RaisePropertyChanged("ServiceCallID");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        public bool HasError
        {
            get
            {
                return this.hasErrorField;
            }
            set
            {
                this.hasErrorField = value;
                this.RaisePropertyChanged("HasError");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true, Order = 2)]
        public string Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
                this.RaisePropertyChanged("Error");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRegiXEntryPointChannel : IRegiXEntryPoint, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RegiXEntryPointClient : System.ServiceModel.ClientBase<IRegiXEntryPoint>, IRegiXEntryPoint
    {

        public RegiXEntryPointClient()
        {
        }

        public RegiXEntryPointClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public RegiXEntryPointClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public RegiXEntryPointClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public RegiXEntryPointClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        public ServiceExecuteResult Execute(ServiceRequestData request)
        {
            return base.Channel.Execute(request);
        }

        public ServiceResultData CheckResult(ServiceCheckResultArgument argument)
        {
            return base.Channel.CheckResult(argument);
        }

        public ServiceResultData ExecuteSynchronous(ServiceRequestData request)
        {
            return base.Channel.ExecuteSynchronous(request);
        }
    }
}