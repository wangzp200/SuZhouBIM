using System.Configuration;
using BIMWebService.Mode.Sys;
using BIMWebService.Util;
using SAPbobsCOM;

namespace BIMWebService.Common
{
    public static class Globle
    {
        public static readonly SapSetting Conf = ConfigurationManager.GetSection("SapSetting") as
            SapSetting;
        public static readonly Company DiCompany = CompanyHelper.GetCompany("BENEMAE");
    }
}