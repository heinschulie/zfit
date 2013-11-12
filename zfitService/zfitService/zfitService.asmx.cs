using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace zfit
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://www.z2z.co.za/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class zfitWebMethods : WebService
    {
        //[WebMethod]
        //public string zfitUserCall(string aXmlCredentials, string aXmlArgument)
        //{
        //    return UserInterface.Invoke(aXmlCredentials, aXmlArgument);
        //}

        [WebMethod]
        public string zfitFanCall(string aXmlCredentials, string aXmlArgument)
        {
            return FanInterface.Invoke(aXmlCredentials, aXmlArgument);
        }
    }
}
