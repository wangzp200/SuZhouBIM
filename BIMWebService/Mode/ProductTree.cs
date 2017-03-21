using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using BIMWebService.Mode.Sys;
using BIMWebService.Util;
using DingDingWebService.Mode;

namespace BIMWebService.Mode
{
    [Serializable]
    [ClassDescribe(Table = "OITT", Key = "Code", MOdbcType = MOdbcType.NVarChar)]
    public class ProductTree : BaseEntry
    {
        public string DistributionRule { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public BoYesNoEnum HideBomComponentsInPrintout { get; set; }
        public double PlanAvgProdSize { get; set; }
        public long PriceList { get; set; }
        public string Project { get; set; }
        public double Quantity { get; set; }
        public string TreeCode { get; set; }
        public BoItemTreeTypes TreeType { get; set; }
        public string Warehouse { get; set; }
        public ProductTreeLine[] ProductTreeLines { get; set; }

        protected new List<object> GetValue(object key)
        {
            var classAttribute =
                (ClassDescribeAttribute)
                    Attribute.GetCustomAttribute(typeof (ProductTree), typeof (ClassDescribeAttribute));
            var sql = string.Format("SELECT * FROM {0} WHERE {1}=?", classAttribute.Table, classAttribute.Key);

            var odbcParameters = new List<MOdbcParameter>();
            var odbcParameter = new MOdbcParameter
            {
                Name = classAttribute.Key,
                OType = classAttribute.MOdbcType,
                Value = key
            };
            odbcParameters.Add(odbcParameter);

            var dataTable = CommonHelper.GetDataTable(sql, odbcParameters);

            var productTrees = new List<object>();

            foreach (DataRow row in dataTable.Rows)
            {
                var productTree = new ProductTree();
                foreach (var info in typeof (ProductTree).GetProperties())
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
                            info.SetValue(productTree, row[columnName], null);
                        }
                        else
                        {
                            var assembly = Assembly.GetExecutingAssembly();
                            foreach (var type in assembly.GetTypes())
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
    }

    [Serializable]
    [ClassDescribe(Table = "OITT", Key = "Code", MOdbcType = MOdbcType.NVarChar)]
    public class ProductTreeLine : BaseEntry
    {
        public double AdditionalQuantity { get; set; }
        public string Comment { get; set; }
        public string Currency { get; set; }
        public string DistributionRule { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public string InventoryUom { get; set; }
        public BoIssueMethod IssueMethod { get; set; }
        public string ItemCode { get; set; }
        public ProductionItemType ItemType { get; set; }
        public string LineText { get; set; }
        public string ParentItem { get; set; }
        public double Price { get; set; }
        public long PriceList { get; set; }
        public string Project { get; set; }
        public double Quantity { get; set; }
        public string Warehouse { get; set; }
        public string WipAccount { get; set; }
    }
}