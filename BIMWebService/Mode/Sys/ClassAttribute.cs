using System;

namespace BIMWebService.Mode.Sys
{
    public class ClassDescribeAttribute : Attribute
    {
        public string Key { get; set; }
        public MOdbcType MOdbcType { get; set; }
        public string Table { get; set; }
    }
}