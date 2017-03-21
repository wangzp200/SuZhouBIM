using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Protocols;
using BIMWebService.Util;

namespace BIMWebService.Mode.Sys
{
    public class SecurityHeader : SoapHeader
    {
        private bool _hasLogin;
        public string CompanyDb { set; get; }
        public string UserName { set; get; }
        public string UserPass { set; get; }

        public bool IsValid()
        {
            if (!_hasLogin)
            {
                var connectionString = CommonHelper.GetSqlConnect(CompanyDb);
                var sql = "SELECT * FROM \"OUSR\" WHERE \"USER_CODE\"=? AND \"U_passWord\"=?";
                var sqlParameters = new List<SqlParameter>();
                var sqlParameter = new SqlParameter("code", SqlDbType.NVarChar) {SqlValue = UserName};
                sqlParameters.Add(sqlParameter);
                sqlParameter = new SqlParameter("passWord", SqlDbType.NVarChar) {SqlValue = UserPass};
                sqlParameters.Add(sqlParameter);
                var scalar =
                    (long) SqlHelper.ExecuteScalar(connectionString, CommandType.Text, sql, sqlParameters.ToArray());
                if (scalar > 0)
                {
                    _hasLogin = true;
                }
            }
            return _hasLogin;
        }
    }
}