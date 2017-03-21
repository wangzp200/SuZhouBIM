using System;

namespace DingDingWebService.Mode
{
    public class PropertyAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public Type DataType { get; set; }
        public string ColumnName { get; set; }
    }
}