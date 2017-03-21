using System;

namespace BIMWebService.Mode.Sys
{
    [Serializable]
    public class ResultMessage
    {
        public string Content;
        public StatusCodeEnum Status;
    }
}