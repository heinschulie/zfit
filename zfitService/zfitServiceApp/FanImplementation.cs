using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zephry;

namespace zfit
{
    public class FanImplementation
    {    
        #region Function Methods

        /// <summary>
        ///   Gets the <see cref="Function"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Function as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Load(aFanKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        /// <summary>
        ///   The <c>GetFunctionCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FunctionCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="FunctionCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FunctionCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFunctionCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFunctionCollection");
            }
            FunctionCollection vFunctionCollection = new FunctionCollection();
            vFunctionCollection = XmlUtils.Deserialize<FunctionCollection>(aXmlArgument);
            FunctionBusiness.Load(aFanKey, vFunctionCollection);
            return XmlUtils.Serialize<FunctionCollection>(vFunctionCollection, true);
        }

        /// <summary>
        ///   The <c>AddFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Function"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="Function"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Function Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Function"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Insert(aFanKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        /// <summary>
        ///   The <c>EditFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Function"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="Function"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Function"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Update(aFanKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        /// <summary>
        ///   The <c>DeleteFunction</c> implementation method deserializes an incoming XML Argument as a new <see cref="Function"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="FunctionBusiness"/> with the newly deserialized <see cref="Function"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Function"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Delete(aFanKey, vFunction);
            return XmlUtils.Serialize<Function>(vFunction, true);
        }

        #endregion

        #region RoleFunction Methods

        /// <summary>
        ///   Gets the <see cref="RoleFunction"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>RoleFunction as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRoleFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Load(aFanKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        /// <summary>
        ///   The <c>GetRoleFunctionCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleFunctionCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunctionCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunctionCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRoleFunctionCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleFunctionCollection");
            }
            RoleFunctionCollection vRoleFunctionCollection = new RoleFunctionCollection();
            vRoleFunctionCollection = XmlUtils.Deserialize<RoleFunctionCollection>(aXmlArgument);
            RoleFunctionBusiness.Load(aFanKey, vRoleFunctionCollection);
            return XmlUtils.Serialize<RoleFunctionCollection>(vRoleFunctionCollection, true);
        }

        /// <summary>
        ///   The <c>AddRoleFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleFunction"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunction"/> object.
        ///   Finally, it returns the inserted object (now with an assigned RoleFunction Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunction"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddRoleFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Insert(aFanKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        /// <summary>
        ///   The <c>EditRoleFunction</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleFunction"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunction"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunction"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditRoleFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Update(aFanKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        /// <summary>
        ///   The <c>DeleteRoleFunction</c> implementation method deserializes an incoming XML Argument as a new <see cref="RoleFunction"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="RoleFunctionBusiness"/> with the newly deserialized <see cref="RoleFunction"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleFunction"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteRoleFunction(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Delete(aFanKey, vRoleFunction);
            return XmlUtils.Serialize<RoleFunction>(vRoleFunction, true);
        }

        #endregion

        #region Role Methods

        /// <summary>
        ///   Gets the <see cref="Role"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Role as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Load(aFanKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        /// <summary>
        ///   The <c>GetRoleCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="RoleCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="RoleCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="RoleCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetRoleCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleCollection");
            }
            RoleCollection vRoleCollection = new RoleCollection();
            vRoleCollection = XmlUtils.Deserialize<RoleCollection>(aXmlArgument);
            RoleBusiness.Load(aFanKey, vRoleCollection);
            return XmlUtils.Serialize<RoleCollection>(vRoleCollection, true);
        }

        /// <summary>
        ///   The <c>AddRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Role"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="Role"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Role Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Role"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Insert(aFanKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        /// <summary>
        ///   The <c>EditRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Role"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="Role"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Role"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Update(aFanKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        /// <summary>
        ///   The <c>DeleteRole</c> implementation method deserializes an incoming XML Argument as a new <see cref="Role"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="RoleBusiness"/> with the newly deserialized <see cref="Role"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Role"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Delete(aFanKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        #endregion

        #region FanRole Methods

        /// <summary>
        ///   Gets the <see cref="FanRole"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>FanRole as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanRole");
            }
            FanRole vFanRole = new FanRole();
            vFanRole = XmlUtils.Deserialize<FanRole>(aXmlArgument);
            FanRoleBusiness.Load(aFanKey, vFanRole);
            return XmlUtils.Serialize<FanRole>(vFanRole, true);
        }

        /// <summary>
        ///   The <c>GetFanRoleCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanRoleCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanRoleBusiness"/> with the newly deserialized <see cref="FanRoleCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanRoleCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanRoleCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanRoleCollection");
            }
            FanRoleCollection vFanRoleCollection = new FanRoleCollection();
            vFanRoleCollection = XmlUtils.Deserialize<FanRoleCollection>(aXmlArgument);
            FanRoleBusiness.Load(aFanKey, vFanRoleCollection);
            return XmlUtils.Serialize<FanRoleCollection>(vFanRoleCollection, true);
        }

        /// <summary>
        ///   The <c>AddFanRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanRole"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanRoleBusiness"/> with the newly deserialized <see cref="FanRole"/> object.
        ///   Finally, it returns the inserted object (now with an assigned FanRole Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddFanRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddFanRole");
            }
            FanRole vFanRole = new FanRole();
            vFanRole = XmlUtils.Deserialize<FanRole>(aXmlArgument);
            FanRoleBusiness.Insert(aFanKey, vFanRole);
            return XmlUtils.Serialize<FanRole>(vFanRole, true);
        }

        /// <summary>
        ///   The <c>EditFanRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanRole"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="FanRoleBusiness"/> with the newly deserialized <see cref="FanRole"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditFanRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditFanRole");
            }
            FanRole vFanRole = new FanRole();
            vFanRole = XmlUtils.Deserialize<FanRole>(aXmlArgument);
            FanRoleBusiness.Update(aFanKey, vFanRole);
            return XmlUtils.Serialize<FanRole>(vFanRole, true);
        }

        /// <summary>
        ///   The <c>DeleteFanRole</c> implementation method deserializes an incoming XML Argument as a new <see cref="FanRole"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="FanRoleBusiness"/> with the newly deserialized <see cref="FanRole"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteFanRole(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteFanRole");
            }
            FanRole vFanRole = new FanRole();
            vFanRole = XmlUtils.Deserialize<FanRole>(aXmlArgument);
            FanRoleBusiness.Delete(aFanKey, vFanRole);
            return XmlUtils.Serialize<FanRole>(vFanRole, true);
        }

        #endregion

        #region Fan Methods

        /// <summary>
        ///   Gets the <see cref="Fan"/> by FanID.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Fan as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanByID(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanByID");
            }
            Fan vFan = new Fan();
            vFan = XmlUtils.Deserialize<Fan>(aXmlArgument);
            FanBusiness.LoadByID(vFan, vFan);
            return XmlUtils.Serialize<Fan>(vFan, true);
        }

        /// <summary>
        ///   Gets the <see cref="Fan"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Fan as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFan(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFan");
            }
            Fan vFan = new Fan();
            vFan = XmlUtils.Deserialize<Fan>(aXmlArgument);
            FanBusiness.Load(aFanKey, vFan);
            return XmlUtils.Serialize<Fan>(vFan, true);
        }

        /// <summary>
        ///   The <c>GetFanCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanBusiness"/> with the newly deserialized <see cref="FanCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanCollection");
            }
            FanCollection vFanCollection = new FanCollection();
            vFanCollection = XmlUtils.Deserialize<FanCollection>(aXmlArgument);
            FanBusiness.Load(aFanKey, vFanCollection);
            return XmlUtils.Serialize<FanCollection>(vFanCollection, true);
        }

        /// <summary>
        ///   The <c>AddFan</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Fan"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanBusiness"/> with the newly deserialized <see cref="Fan"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Fan Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Fan"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddFan(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddFan");
            }
            Fan vFan = new Fan();
            vFan = XmlUtils.Deserialize<Fan>(aXmlArgument);
            FanBusiness.Insert(aFanKey, vFan);
            return XmlUtils.Serialize<Fan>(vFan, true);
        }

        /// <summary>
        ///   The <c>EditFan</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Fan"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="FanBusiness"/> with the newly deserialized <see cref="Fan"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Fan"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditFan(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditFan");
            }
            Fan vFan = new Fan();
            vFan = XmlUtils.Deserialize<Fan>(aXmlArgument);
            FanBusiness.Update(aFanKey, vFan);
            return XmlUtils.Serialize<Fan>(vFan, true);
        }

        /// <summary>
        ///   The <c>DeleteFan</c> implementation method deserializes an incoming XML Argument as a new <see cref="Fan"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="FanBusiness"/> with the newly deserialized <see cref="Fan"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Fan"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteFan(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteFan");
            }
            Fan vFan = new Fan();
            vFan = XmlUtils.Deserialize<Fan>(aXmlArgument);
            FanBusiness.Delete(aFanKey, vFan);
            return XmlUtils.Serialize<Fan>(vFan, true);
        }

        #endregion

        #region Cell Methods

        /// <summary>
        ///   Gets the <see cref="Cell"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Cell as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetCell(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetCell");
            }
            Cell vCell = new Cell();
            vCell = XmlUtils.Deserialize<Cell>(aXmlArgument);
            CellBusiness.Load(aFanKey, vCell);
            return XmlUtils.Serialize<Cell>(vCell, true);
        }

        /// <summary>
        ///   The <c>GetCellCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="CellCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="CellBusiness"/> with the newly deserialized <see cref="CellCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="CellCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetCellCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetCellCollection");
            }
            CellCollection vCellCollection = new CellCollection();
            vCellCollection = XmlUtils.Deserialize<CellCollection>(aXmlArgument);
            CellBusiness.Load(aFanKey, vCellCollection);
            return XmlUtils.Serialize<CellCollection>(vCellCollection, true);
        }

        /// <summary>
        ///   The <c>AddCell</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Cell"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="CellBusiness"/> with the newly deserialized <see cref="Cell"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Cell Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Cell"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddCell(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddCell");
            }
            Cell vCell = new Cell();
            vCell = XmlUtils.Deserialize<Cell>(aXmlArgument);
            CellBusiness.Insert(aFanKey, vCell);
            return XmlUtils.Serialize<Cell>(vCell, true);
        }

        /// <summary>
        ///   The <c>EditCell</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Cell"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="CellBusiness"/> with the newly deserialized <see cref="Cell"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Cell"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditCell(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditCell");
            }
            Cell vCell = new Cell();
            vCell = XmlUtils.Deserialize<Cell>(aXmlArgument);
            CellBusiness.Update(aFanKey, vCell);
            return XmlUtils.Serialize<Cell>(vCell, true);
        }

        /// <summary>
        ///   The <c>DeleteCell</c> implementation method deserializes an incoming XML Argument as a new <see cref="Cell"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="CellBusiness"/> with the newly deserialized <see cref="Cell"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Cell"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteCell(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteCell");
            }
            Cell vCell = new Cell();
            vCell = XmlUtils.Deserialize<Cell>(aXmlArgument);
            CellBusiness.Delete(aFanKey, vCell);
            return XmlUtils.Serialize<Cell>(vCell, true);
        }

        #endregion

        #region Fed Methods

        /// <summary>
        ///   Gets the <see cref="Fed"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Fed as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFed");
            }
            Fed vFed = new Fed();
            vFed = XmlUtils.Deserialize<Fed>(aXmlArgument);
            FedBusiness.Load(aFanKey, vFed);
            return XmlUtils.Serialize<Fed>(vFed, true);
        }

        /// <summary>
        ///   The <c>GetFedCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FedCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FedBusiness"/> with the newly deserialized <see cref="FedCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FedCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFedCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFedCollection");
            }
            FedCollection vFedCollection = new FedCollection();
            vFedCollection = XmlUtils.Deserialize<FedCollection>(aXmlArgument);
            FedBusiness.Load(aFanKey, vFedCollection);
            return XmlUtils.Serialize<FedCollection>(vFedCollection, true);
        }

        /// <summary>
        ///   The <c>AddFed</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Fed"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FedBusiness"/> with the newly deserialized <see cref="Fed"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Fed Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Fed"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddFed");
            }
            Fed vFed = new Fed();
            vFed = XmlUtils.Deserialize<Fed>(aXmlArgument);
            FedBusiness.Insert(aFanKey, vFed);
            return XmlUtils.Serialize<Fed>(vFed, true);
        }

        /// <summary>
        ///   The <c>EditFed</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Fed"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="FedBusiness"/> with the newly deserialized <see cref="Fed"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Fed"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditFed");
            }
            Fed vFed = new Fed();
            vFed = XmlUtils.Deserialize<Fed>(aXmlArgument);
            FedBusiness.Update(aFanKey, vFed);
            return XmlUtils.Serialize<Fed>(vFed, true);
        }

        /// <summary>
        ///   The <c>DeleteFed</c> implementation method deserializes an incoming XML Argument as a new <see cref="Fed"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="FedBusiness"/> with the newly deserialized <see cref="Fed"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Fed"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteFed");
            }
            Fed vFed = new Fed();
            vFed = XmlUtils.Deserialize<Fed>(aXmlArgument);
            FedBusiness.Delete(aFanKey, vFed);
            return XmlUtils.Serialize<Fed>(vFed, true);
        }

        #endregion   
     
        #region CellFan Methods

        /// <summary>
        ///   Gets the <see cref="CellFan"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>CellFan as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetCellFan(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetCellFan");
            }
            CellFan vCellFan = new CellFan();
            vCellFan = XmlUtils.Deserialize<CellFan>(aXmlArgument);
            CellFanBusiness.Load(aFanKey, vCellFan);
            return XmlUtils.Serialize<CellFan>(vCellFan, true);
        }

        /// <summary>
        ///   The <c>GetCellFanCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="CellFanCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="CellFanBusiness"/> with the newly deserialized <see cref="CellFanCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="CellFanCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetCellFanCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetCellFanCollection");
            }
            CellFanCollection vCellFanCollection = new CellFanCollection();
            vCellFanCollection = XmlUtils.Deserialize<CellFanCollection>(aXmlArgument);
            CellFanBusiness.Load(aFanKey, vCellFanCollection);
            return XmlUtils.Serialize<CellFanCollection>(vCellFanCollection, true);
        }

        /// <summary>
        /// Saves the provider suburb.
        /// </summary>
        /// <param name="aFanKey">A user key.</param>
        /// <param name="aXmlArgument">A XML argument.</param>
        /// <returns>A string of XML representing a CellFanCollection</returns>
        /// <exception cref="System.ArgumentNullException">aXmlArgument of SaveCellFan</exception>
        public static string SaveCellFan(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of SaveCellFan");
            }
            CellFanCollection vCellFanCollection = new CellFanCollection();
            vCellFanCollection = XmlUtils.Deserialize<CellFanCollection>(aXmlArgument);
            CellFanBusiness.Save(aFanKey, vCellFanCollection);
            return XmlUtils.Serialize<CellFanCollection>(vCellFanCollection, true);
        }

        #endregion

        #region CellFed Methods

        /// <summary>
        ///   Gets the <see cref="CellFed"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>CellFed as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetCellFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetCellFed");
            }
            CellFed vCellFed = new CellFed();
            vCellFed = XmlUtils.Deserialize<CellFed>(aXmlArgument);
            CellFedBusiness.Load(aFanKey, vCellFed);
            return XmlUtils.Serialize<CellFed>(vCellFed, true);
        }

        /// <summary>
        ///   The <c>GetCellFedCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="CellFedCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="CellFedBusiness"/> with the newly deserialized <see cref="CellFedCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="CellFedCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetCellFedCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetCellFedCollection");
            }
            CellFedCollection vCellFedCollection = new CellFedCollection();
            vCellFedCollection = XmlUtils.Deserialize<CellFedCollection>(aXmlArgument);
            CellFedBusiness.Load(aFanKey, vCellFedCollection);
            return XmlUtils.Serialize<CellFedCollection>(vCellFedCollection, true);
        }

        /// <summary>
        /// Saves the provider suburb.
        /// </summary>
        /// <param name="aFanKey">A user key.</param>
        /// <param name="aXmlArgument">A XML argument.</param>
        /// <returns>A string of XML representing a CellFedCollection</returns>
        /// <exception cref="System.ArgumentNullException">aXmlArgument of SaveCellFed</exception>
        public static string SaveCellFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of SaveCellFed");
            }
            CellFedCollection vCellFedCollection = new CellFedCollection();
            vCellFedCollection = XmlUtils.Deserialize<CellFedCollection>(aXmlArgument);
            CellFedBusiness.Save(aFanKey, vCellFedCollection);
            return XmlUtils.Serialize<CellFedCollection>(vCellFedCollection, true);
        }

        #endregion

        #region FanFed Methods

        /// <summary>
        ///   Gets the <see cref="FanFed"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>FanFed as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanFed");
            }
            FanFed vFanFed = new FanFed();
            vFanFed = XmlUtils.Deserialize<FanFed>(aXmlArgument);
            FanFedBusiness.Load(aFanKey, vFanFed);
            return XmlUtils.Serialize<FanFed>(vFanFed, true);
        }

        /// <summary>
        ///   The <c>GetFanFedCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanFedCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanFedBusiness"/> with the newly deserialized <see cref="FanFedCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanFedCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanFedCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanFedCollection");
            }
            FanFedCollection vFanFedCollection = new FanFedCollection();
            vFanFedCollection = XmlUtils.Deserialize<FanFedCollection>(aXmlArgument);
            FanFedBusiness.Load(aFanKey, vFanFedCollection);
            return XmlUtils.Serialize<FanFedCollection>(vFanFedCollection, true);
        }

        /// <summary>
        /// Saves the provider suburb.
        /// </summary>
        /// <param name="aFanKey">A user key.</param>
        /// <param name="aXmlArgument">A XML argument.</param>
        /// <returns>A string of XML representing a FanFedCollection</returns>
        /// <exception cref="System.ArgumentNullException">aXmlArgument of SaveFanFed</exception>
        public static string SaveFanFed(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of SaveFanFed");
            }
            FanFedCollection vFanFedCollection = new FanFedCollection();
            vFanFedCollection = XmlUtils.Deserialize<FanFedCollection>(aXmlArgument);
            FanFedBusiness.Save(aFanKey, vFanFedCollection);
            return XmlUtils.Serialize<FanFedCollection>(vFanFedCollection, true);
        }

        #endregion
    }
}