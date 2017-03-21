using System.Configuration;
using SAPbobsCOM;

namespace BIMWebService.Mode.Sys
{
    public class SapSetting : ConfigurationSection
    {
        [ConfigurationProperty("CompanyCollection", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof (CompanyCollection),
            CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
        public CompanyCollection CompanysCollection
        {
            get { return (CompanyCollection) base["CompanyCollection"]; }
            set { base["CompanyCollection"] = value; }
        }

        [ConfigurationProperty("DbPassword")]
        public string DbPassword
        {
            get { return (string) base["DbPassword"]; }
            set { base["DbPassword"] = value; }
        }

        [ConfigurationProperty("DbServerType")]
        public BoDataServerTypes DbServerType
        {
            get { return (BoDataServerTypes) base["DbServerType"]; }
            set { base["DbServerType"] = value; }
        }

        [ConfigurationProperty("DbUserName")]
        public string DbUserName
        {
            get { return (string) base["DbServerType"]; }
            set { base["DbServerType"] = value; }
        }

        [ConfigurationProperty("Language")]
        public BoSuppLangs Language
        {
            get { return (BoSuppLangs) base["Language"]; }
            set { base["DbServerType"] = value; }
        }

        [ConfigurationProperty("LicenseServer")]
        public string LicenseServer
        {
            get { return (string) base["Language"]; }
            set { base["DbServerType"] = value; }
        }

        [ConfigurationProperty("Server")]
        public string Server
        {
            get { return (string) base["Server"]; }
            set { base["Server"] = value; }
        }

        [ConfigurationProperty("DataSource")]
        public string DataSource
        {
            get { return (string) base["DataSource"]; }
            set { base["DataSource"] = value; }
        }

        [ConfigurationProperty("UseTrusted")]
        public bool UseTrusted
        {
            get { return (bool) base["UseTrusted"]; }
            set { base["UseTrusted"] = value; }
        }

        [ConfigurationProperty("CorpId")]
        public string CorpId
        {
            get { return (string) base["UseTrusted"]; }
            set { base["UseTrusted"] = value; }
        }

        [ConfigurationProperty("Secret")]
        public string Secret
        {
            get { return (string) base["Secret"]; }
            set { base["Secret"] = value; }
        }

        [ConfigurationProperty("EngineCode")]
        public string EngineCode
        {
            get { return (string) base["EngineCode"]; }
            set { base["EngineCode"] = value; }
        }

        [ConfigurationProperty("Url")]
        public string Url
        {
            get { return (string) base["Url"]; }
            set { base["Url"] = value; }
        }

        [ConfigurationProperty("LossQrAccount")]
        public string LossQrAccount
        {
            get { return (string) base["LossQrAccount"]; }
            set { base["LossQrAccount"] = value; }
        }

        [ConfigurationProperty("OverageQrAccount")]
        public string OverageQrAccount
        {
            get { return (string) base["OverageQrAccount"]; }
            set { base["OverageQrAccount"] = value; }
        }

        [ConfigurationProperty("UserCode")]
        public string UserCode
        {
            get { return (string) base["UserCode"]; }
            set { base["UserCode"] = value; }
        }
    }

    public class CompanyCollection : ConfigurationElementCollection
    {
        public CompanyInfo this[int i]
        {
            get { return (CompanyInfo) BaseGet(i); }
        }

        public CompanyInfo this[string key]
        {
            get { return (CompanyInfo) BaseGet(key); }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CompanyInfo) element).CompanyDb;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CompanyInfo();
        }
    }

    public class CompanyInfo : ConfigurationElement
    {
        [ConfigurationProperty("CompanyDb", IsRequired = true)]
        public string CompanyDb
        {
            get { return (string) base["CompanyDb"]; }
            set { base["CompanyDb"] = value; }
        }

        [ConfigurationProperty("PassWord", IsRequired = true)]
        public string PassWord
        {
            get { return (string) base["PassWord"]; }
            set { base["PassWord"] = value; }
        }

        [ConfigurationProperty("UserName", IsRequired = true)]
        public string UserName
        {
            get { return (string) base["UserName"]; }
            set { base["UserName"] = value; }
        }
    }
}