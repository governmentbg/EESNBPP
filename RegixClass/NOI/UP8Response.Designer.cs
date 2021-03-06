// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code++. Version 4.4.0.7
//    <NameSpace>NBPPRegixClient.RegixClass.NOI</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><GenerateCloneMethod>False</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><DataMemberNameArg>OnlyIfDifferent</DataMemberNameArg><DataMemberOnXmlIgnore>False</DataMemberOnXmlIgnore><CodeBaseTag>Net45</CodeBaseTag><InitializeFields>All</InitializeFields><GenerateUnusedComplexTypes>False</GenerateUnusedComplexTypes><GenerateUnusedSimpleTypes>False</GenerateUnusedSimpleTypes><GenerateXMLAttributes>True</GenerateXMLAttributes><OrderXMLAttrib>False</OrderXMLAttrib><EnableLazyLoading>False</EnableLazyLoading><VirtualProp>False</VirtualProp><PascalCase>False</PascalCase><AutomaticProperties>False</AutomaticProperties><PropNameSpecified>None</PropNameSpecified><PrivateFieldName>StartWithUnderscore</PrivateFieldName><PrivateFieldNamePrefix></PrivateFieldNamePrefix><EnableRestriction>False</EnableRestriction><RestrictionMaxLenght>False</RestrictionMaxLenght><RestrictionRegEx>False</RestrictionRegEx><RestrictionRange>False</RestrictionRange><ValidateProperty>False</ValidateProperty><ClassNamePrefix></ClassNamePrefix><ClassLevel>Public</ClassLevel><PartialClass>True</PartialClass><ClassesInSeparateFiles>False</ClassesInSeparateFiles><ClassesInSeparateFilesDir></ClassesInSeparateFilesDir><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>False</EnableSummaryComment><EnableAppInfoSettings>False</EnableAppInfoSettings><EnableExternalSchemasCache>False</EnableExternalSchemasCache><EnableDebug>False</EnableDebug><EnableWarn>False</EnableWarn><ExcludeImportedTypes>True</ExcludeImportedTypes><ExpandNesteadAttributeGroup>False</ExpandNesteadAttributeGroup><CleanupCode>False</CleanupCode><EnableXmlSerialization>False</EnableXmlSerialization><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><EnableEncoding>False</EnableEncoding><EnableXMLIndent>False</EnableXMLIndent><IndentChar>Indent2Space</IndentChar><NewLineAttr>False</NewLineAttr><OmitXML>False</OmitXML><Encoder>UTF8</Encoder><Serializer>XmlSerializer</Serializer><sspNullable>False</sspNullable><sspString>False</sspString><sspCollection>False</sspCollection><sspComplexType>False</sspComplexType><sspSimpleType>False</sspSimpleType><sspEnumType>False</sspEnumType><XmlSerializerEvent>False</XmlSerializerEvent><BaseClassName>EntityBase</BaseClassName><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><CustomUsings></CustomUsings><AttributesToExlude></AttributesToExlude>
//  </auto-generated>
// ------------------------------------------------------------------------------
#pragma warning disable
namespace NBPPRegixClient.RegixClass.NOI
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Xml;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://egov.bg/RegiX/NOI/RP/UP8Response")]
    [System.Xml.Serialization.XmlRootAttribute("UP8Response", Namespace="http://egov.bg/RegiX/NOI/RP/UP8Response", IsNullable=false)]
    public partial class UP8ResponseType
    {
        
        #region Private fields
        private string _title;
        
        private System.DateTime _forDate;
        
        private string _territorialDivisionNOI;
        
        private string _identifier;
        
        private PersonNames _names;
        
        private string _pensionerStatus;
        
        private System.DateTime _dateOfDeath;
        
        private string _contentText;
        
        private List<PensionPaymentType> _pensionPayments;
        #endregion
        
        public UP8ResponseType()
        {
            this._pensionPayments = new List<PensionPaymentType>();
            this._names = new PersonNames();
        }
        
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
        public System.DateTime ForDate
        {
            get
            {
                return this._forDate;
            }
            set
            {
                this._forDate = value;
            }
        }
        
        public string TerritorialDivisionNOI
        {
            get
            {
                return this._territorialDivisionNOI;
            }
            set
            {
                this._territorialDivisionNOI = value;
            }
        }
        
        public string Identifier
        {
            get
            {
                return this._identifier;
            }
            set
            {
                this._identifier = value;
            }
        }
        
        public PersonNames Names
        {
            get
            {
                return this._names;
            }
            set
            {
                this._names = value;
            }
        }
        
        public string PensionerStatus
        {
            get
            {
                return this._pensionerStatus;
            }
            set
            {
                this._pensionerStatus = value;
            }
        }
        
        public System.DateTime DateOfDeath
        {
            get
            {
                return this._dateOfDeath;
            }
            set
            {
                this._dateOfDeath = value;
            }
        }
        
        public string ContentText
        {
            get
            {
                return this._contentText;
            }
            set
            {
                this._contentText = value;
            }
        }
        
        [System.Xml.Serialization.XmlArrayItemAttribute("PensionPayment", Namespace="http://egov.bg/RegiX/NOI/RP", IsNullable=false)]
        public List<PensionPaymentType> PensionPayments
        {
            get
            {
                return this._pensionPayments;
            }
            set
            {
                this._pensionPayments = value;
            }
        }
    }
}
#pragma warning restore
