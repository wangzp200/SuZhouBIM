using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Reflection;
using BIMWebService.Common;
using BIMWebService.Mode;
using BIMWebService.Mode.Sys;
using DingDingWebService.Mode;

namespace BIMWebService.Util
{
    public static class CommonHelper
    {
        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

        public static string GetCompanySqlConnect()
        {
            return GetSqlConnect(Globle.Conf.CompanysCollection[0].CompanyDb);
        }

        public static List<BaseEntry> GetValue(object key, Type clazzType)
        {
            var classAttribute =
                (ClassDescribeAttribute)
                    Attribute.GetCustomAttribute(clazzType, typeof (ClassDescribeAttribute));
            var sql = string.Format("SELECT * FROM {0} WHERE {1}=?", classAttribute.Table, classAttribute.Key);
            var odbcParameters = new List<MOdbcParameter>();
            var odbcParameter = new MOdbcParameter
            {
                Name = classAttribute.Key,
                OType = classAttribute.MOdbcType,
                Value = key
            };
            odbcParameters.Add(odbcParameter);

            var dataTable = GetDataTable(sql, odbcParameters);

            var productTrees = new List<BaseEntry>();

            foreach (DataRow row in dataTable.Rows)
            {
                var productTree = Activator.CreateInstance(clazzType, true) as BaseEntry;
                foreach (var info in clazzType.GetProperties())
                {
                    var propertyAttribute =
                        info.GetCustomAttributes(typeof (PropertyAttribute), false)
                            .FirstOrDefault() as
                            PropertyAttribute;
                    if (propertyAttribute != null)
                    {
                        var columnName = "";
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            if (info.Name.Equals(column.ColumnName.Replace("U_", "")))
                            {
                                columnName = propertyAttribute.ColumnName;
                            }
                        }
                        if (!string.IsNullOrEmpty(columnName))
                        {
                            var obj = row[columnName];
                            if (dataTable.Columns[columnName].DataType == typeof (decimal))
                            {
                                obj = string.IsNullOrEmpty(obj.ToString()) ? 0.0 : double.Parse(obj.ToString());
                            }

                            info.SetValue(productTree, obj, null);
                        }
                        else
                        {
                            foreach (var type in Assembly.GetTypes())
                            {
                                if (type == propertyAttribute.DataType)
                                {
                                    var productTreeLine = Activator.CreateInstance(type, true) as BaseEntry;
                                    if (productTreeLine != null)
                                        info.SetValue(productTree, productTreeLine.GetValue(key).ToArray(), null);
                                    break;
                                }
                            }
                        }
                    }
                }
                productTrees.Add(productTree);
            }
            return productTrees;
        }

        public static string GetSqlConnect(string companyDb)
        {
            return string.Format(Globle.Conf.DataSource, "{HDBODBC32}", companyDb);
        }

        public static string GetString(int len, int num)
        {
            var result = num.ToString();
            for (var i = 0; i < len - num.ToString().Length; i++)
            {
                result = "0" + result;
            }
            return result;
        }

        public static DataTable GetDataTable(string sql, List<MOdbcParameter> pars)
        {
            OdbcParameter[] parameters = null;
            if (pars != null)
            {
                parameters = new OdbcParameter[pars.Count];
                for (var i = 0; i < pars.Count; i++)
                {
                    var par = pars[i];
                    parameters[i] = new OdbcParameter(par.Name,
                        (OdbcType) Enum.Parse(typeof (OdbcType), par.OType.ToString())) {Value = par.Value};
                }
            }
            var connectionString = GetCompanySqlConnect();
            var dataSet = OdbcHelper.ExecuteDataset(connectionString, CommandType.Text, sql, parameters);
            var data = dataSet.Tables[0];
            return data;
        }
    }
}