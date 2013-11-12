using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace Zephry
{
    /// <summary>
    /// A set of static methods that serialize objects to JSON and deserialize JSON to objects.
    /// </summary>
    public static class JsonUtils
    {
        /// <summary>
        /// Object Extension Method returns a string in JSON format.
        /// </summary>
        /// <param name="aObject">An object.</param>
        /// <returns>A Json representation of aObject as a string</returns>
        public static string SerializeToJson(this object aObject)
        {
            JavaScriptSerializer vJavaScriptSerializer = new JavaScriptSerializer();
            return vJavaScriptSerializer.Serialize(aObject);
        }

        /// <summary>
        /// String in JSON format Extension Method returns an Object.
        /// </summary>
        /// <typeparam name="T">The type of the object to be deserialized</typeparam>
        /// <param name="aArgument">a String in JSON format</param>
        /// <returns>An object of type T</returns>
        public static T DeserializeFromJson<T>(this string aArgument) where T : class
        {
            T vObjectResult = null;
            byte[] vByteArray = Encoding.UTF8.GetBytes(aArgument);
            DataContractJsonSerializer vDataContractJsonSerializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream vMemoryStream = new MemoryStream(vByteArray))
            {
                vObjectResult = (T)vDataContractJsonSerializer.ReadObject(vMemoryStream);
            }
            return vObjectResult;
        }
    }    
}
