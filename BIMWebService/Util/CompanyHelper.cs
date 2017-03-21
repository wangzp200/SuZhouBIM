using System;
using System.Collections.Generic;
using BIMWebService.Common;
using SAPbobsCOM;

namespace BIMWebService.Util
{
    public static class CompanyHelper
    {
        private static readonly SortedList<string, Company> CompanyCache = new SortedList<string, Company>();

        public static List<string> GetCompanies()
        {
            var companys = new List<string>();
            for (var i = 0; i < Globle.Conf.CompanysCollection.Count; i++)
            {
                companys.Add(Globle.Conf.CompanysCollection[i].CompanyDb);
            }
            return companys;
        }

        public static Company GetCompany(string companyName)
        {
            Company localcompany = null;
            if (CompanyCache.ContainsKey(companyName))
            {
                localcompany = CompanyCache[companyName];
            }
            else
            {
                for (var i = 0; i < Globle.Conf.CompanysCollection.Count; i++)
                {
                    var company = Globle.Conf.CompanysCollection[i];
                    if (company.CompanyDb == companyName)
                    {
                        localcompany = new Company
                        {
                            Server = Globle.Conf.Server,
                            language = Globle.Conf.Language,
                            CompanyDB = company.CompanyDb,
                            UseTrusted = Globle.Conf.UseTrusted,
                            UserName = company.UserName,
                            Password = company.PassWord,
                            DbUserName = Globle.Conf.DbUserName,
                            DbPassword = Globle.Conf.DbPassword,
                            DbServerType = Globle.Conf.DbServerType,
                            LicenseServer = Globle.Conf.LicenseServer
                        };
                        if (localcompany.Connect() != 0)
                        {
                            int errCode;
                            string errMsg;
                            localcompany.GetLastError(out errCode, out errMsg);
                            throw new Exception(errCode + "-" + errMsg);
                        }
                        CompanyCache.Add(companyName, localcompany);
                    }
                }
            }
            return localcompany;
        }

        public static void DiscountAllCompanies()
        {
            foreach (var company in CompanyCache)
            {
                if (company.Value.Connected)
                {
                    company.Value.Disconnect();
                    CompanyCache.Remove(company.Key);
                }
            }
        }
    }
}