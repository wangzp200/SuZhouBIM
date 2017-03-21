using System;

namespace BIMWebService.Mode.Sys
{
    [Serializable]
    public class MOdbcParameter
    {
        public MOdbcType OType;
        public string Name;
        public object Value;
    }
}