using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Data.SqlClient; 
using Zephry;

namespace zfit
{
    /// <summary>
    ///   ServiceCallHandler static class.
    /// </summary>
    /// <remarks>
    ///   namespace Z2Z.
    /// </remarks> 
    public static class FanCallHandler
    {
        /// <summary>
        /// The ServiceCall method of the ServiceCallHandler class is the generic handler for all calls to the
        /// Smart web service. It serializes a FanToken as XML Argument 1, a Smart Object as XML Argument 2 and
        /// invokes a remote member (Z2ZCall) located at a remote host (WebService).
        /// </summary>
        /// <typeparam name="T">The Type of the aObject that is passed as the second parameter to this method.</typeparam>
        /// <param name="aFanToken">A user token.</param>
        /// <param name="aMethod">The name of the WebMethod that must be called.</param>
        /// <param name="aObject">The business object that must be serialized and passed as an XML argument to the WebMethod.</param>
        /// 
        public static void ServiceCall<T>(FanToken aFanToken, string aMethod, Zephob aObject)
        {
            var vTransactionStatus = new TransactionStatus();
            var vXDocument = new XDocument();
            try
            {
                // Serialize the FanToken singleton instance to XML
                aFanToken.Method = aMethod;
                string vXmlFanToken = XmlUtils.Serialize<FanToken>(aFanToken, false);
                // Serialize the Zephob instance aObject (of type <T>) to XML
                string vXmlArgument = XmlUtils.Serialize<T>(aObject, false);

                // Invoke the ServiceHost (WebService) method "Z2ZCall"
                var vRemoteHost = new ServiceHost(aFanToken.Url);
                System.Net.ServicePointManager.Expect100Continue = false;
                string vXml = vRemoteHost.WebService.zfitFanCall(vXmlFanToken, vXmlArgument);

                // Convert (Deserialize) the "TransactionStatus" XML tag and subordinate tags to an object instance of type TransactionStatus
                vXDocument = XDocument.Parse(vXml);
                vTransactionStatus = XmlUtils.Deserialize<TransactionStatus>(String.Join(null, vXDocument.Descendants("TransactionStatus").ToList()));
                //vTransactionStatus.TransactionResult = TransactionResult.OK;
            }
            catch (ZpAccessException ax)
            {
                vTransactionStatus.TransactionResult = TransactionResult.AccessException;
                vTransactionStatus.SourceAssembly = SourceAssembly.Business;
                vTransactionStatus.Message = ax.Message;
            }
            catch (Exception ex)
            {
                vTransactionStatus.TransactionResult = TransactionResult.GeneralException;
                vTransactionStatus.SourceAssembly = SourceAssembly.Consumers;
                vTransactionStatus.Message = ex.Message;
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine(ex.StackTrace);
                if (ex.InnerException != null)
                {
                    vStringBuilder.AppendLine("");
                    vStringBuilder.AppendLine("+++++++ Inner Exception +++++++");
                    vStringBuilder.AppendLine(ex.InnerException.Message);
                    vStringBuilder.AppendLine(ex.InnerException.StackTrace);
                }
                vTransactionStatus.InnerMessage = vStringBuilder.ToString();
            }
            finally
            {
                if (vTransactionStatus.TransactionResult == TransactionResult.OK)
                {
                    var vObjectXml = String.Join(null, vXDocument.Descendants(typeof(T).Name).ToList());
                    aObject.AssignFromSource(XmlUtils.Deserialize<T>(vObjectXml));
                }
                else
                {
                    throw new TransactionStatusException(vTransactionStatus);
                }
            }
        }
    }
}
