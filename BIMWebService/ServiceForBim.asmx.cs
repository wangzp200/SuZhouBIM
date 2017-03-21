using System;
using System.ComponentModel;
using System.Reflection;
using System.Web.Services;
using System.Web.Services.Protocols;
using BIMWebService.Job;
using BIMWebService.Mode.Sys;
using Newtonsoft.Json;

namespace BIMWebService
{
    /// <summary>
    ///     ServiceForBusinessOne 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class ServiceForBusinessOne : WebService
    {
        private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
        public SecurityHeader CurrentUser { get; set; }

        [WebMethod, SoapHeader("CurrentUser")]
        public string SapInterface(BusienssOneParamter busienssOneParamter)
        {
            //if (CurrentUser.IsValid())
            //{
            DingDingResultMessage dingDingResultMessage = null;

            foreach (var type in Assembly.GetTypes())
            {
                var bsType = type.BaseType;
                if (type.Name == busienssOneParamter.SchemaCode + "Job" && bsType != null)
                {
                    if (bsType.FullName.StartsWith(typeof (BaseJob<>).FullName))
                    {
                        var method = type.GetMethod(busienssOneParamter.Method.ToString(), BindingFlags.Public
                                                                                           | BindingFlags.NonPublic
                                                                                           | BindingFlags.Instance);
                        if (method != null)
                        {
                            var result = method.Invoke(Activator.CreateInstance(type, true),
                                new[]
                                {
                                    JsonConvert.DeserializeObject(busienssOneParamter.ObjData,
                                        bsType.GenericTypeArguments[0])
                                });
                            return result.ToString();
                        }
                        dingDingResultMessage = new DingDingResultMessage
                        {
                            isSuccess = false,
                            msg = "[" + busienssOneParamter.SchemaCode + "]不存在方法[" + busienssOneParamter.Method + "]"
                        };
                        return JsonConvert.SerializeObject(dingDingResultMessage);
                    }
                }
            }

            dingDingResultMessage = new DingDingResultMessage
            {
                isSuccess = false,
                msg = "不存在[" + busienssOneParamter.Method + "]类"
            };
            return JsonConvert.SerializeObject(dingDingResultMessage);
            //}
            return "";
        }

        [WebMethod]
        public EntryInfo GetEntryInfo()
        {
            return new EntryInfo();
        }
    }
}