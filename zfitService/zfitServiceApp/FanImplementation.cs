﻿using System;
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

        #region Friend Methods

        /// <summary>
        ///   Gets the <see cref="Friend"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Friend as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFriend(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFriend");
            }
            Friend vFriend = new Friend();
            vFriend = XmlUtils.Deserialize<Friend>(aXmlArgument);
            FriendBusiness.Load(aFanKey, vFriend);
            return XmlUtils.Serialize<Friend>(vFriend, true);
        }

        /// <summary>
        ///   The <c>GetFriendCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FriendCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FriendBusiness"/> with the newly deserialized <see cref="FriendCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FriendCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFriendCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFriendCollection");
            }
            FriendCollection vFriendCollection = new FriendCollection();
            vFriendCollection = XmlUtils.Deserialize<FriendCollection>(aXmlArgument);
            FriendBusiness.Load(aFanKey, vFriendCollection);
            return XmlUtils.Serialize<FriendCollection>(vFriendCollection, true);
        }

        /// <summary>
        /// Saves the provider suburb.
        /// </summary>
        /// <param name="aFanKey">A user key.</param>
        /// <param name="aXmlArgument">A XML argument.</param>
        /// <returns>A string of XML representing a FriendCollection</returns>
        /// <exception cref="System.ArgumentNullException">aXmlArgument of SaveFriend</exception>
        public static string SaveFriend(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of SaveFriend");
            }
            FriendCollection vFriendCollection = new FriendCollection();
            vFriendCollection = XmlUtils.Deserialize<FriendCollection>(aXmlArgument);
            FriendBusiness.Save(aFanKey, vFriendCollection);
            return XmlUtils.Serialize<FriendCollection>(vFriendCollection, true);
        }

        #endregion

        #region Exercise Methods

        /// <summary>
        ///   Gets the <see cref="Exercise"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Exercise as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetExercise(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetExercise");
            }
            Exercise vExercise = new Exercise();
            vExercise = XmlUtils.Deserialize<Exercise>(aXmlArgument);
            ExerciseBusiness.Load(aFanKey, vExercise);
            return XmlUtils.Serialize<Exercise>(vExercise, true);
        }

        /// <summary>
        ///   The <c>GetExerciseCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ExerciseCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ExerciseBusiness"/> with the newly deserialized <see cref="ExerciseCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ExerciseCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetExerciseCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetExerciseCollection");
            }
            ExerciseCollection vExerciseCollection = new ExerciseCollection();
            vExerciseCollection = XmlUtils.Deserialize<ExerciseCollection>(aXmlArgument);
            ExerciseBusiness.Load(aFanKey, vExerciseCollection);
            return XmlUtils.Serialize<ExerciseCollection>(vExerciseCollection, true);
        }

        /// <summary>
        ///   The <c>AddExercise</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Exercise"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ExerciseBusiness"/> with the newly deserialized <see cref="Exercise"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Exercise Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Exercise"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddExercise(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddExercise");
            }
            Exercise vExercise = new Exercise();
            vExercise = XmlUtils.Deserialize<Exercise>(aXmlArgument);
            ExerciseBusiness.Insert(aFanKey, vExercise);
            return XmlUtils.Serialize<Exercise>(vExercise, true);
        }

        /// <summary>
        ///   The <c>EditExercise</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Exercise"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="ExerciseBusiness"/> with the newly deserialized <see cref="Exercise"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Exercise"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditExercise(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditExercise");
            }
            Exercise vExercise = new Exercise();
            vExercise = XmlUtils.Deserialize<Exercise>(aXmlArgument);
            ExerciseBusiness.Update(aFanKey, vExercise);
            return XmlUtils.Serialize<Exercise>(vExercise, true);
        }

        /// <summary>
        ///   The <c>DeleteExercise</c> implementation method deserializes an incoming XML Argument as a new <see cref="Exercise"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="ExerciseBusiness"/> with the newly deserialized <see cref="Exercise"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Exercise"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteExercise(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteExercise");
            }
            Exercise vExercise = new Exercise();
            vExercise = XmlUtils.Deserialize<Exercise>(aXmlArgument);
            ExerciseBusiness.Delete(aFanKey, vExercise);
            return XmlUtils.Serialize<Exercise>(vExercise, true);
        }

        #endregion   
        
        #region Workout Methods

        /// <summary>
        ///   Gets the <see cref="Workout"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Workout as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetWorkout(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetWorkout");
            }
            Workout vWorkout = new Workout();
            vWorkout = XmlUtils.Deserialize<Workout>(aXmlArgument);
            WorkoutBusiness.Load(aFanKey, vWorkout);
            return XmlUtils.Serialize<Workout>(vWorkout, true);
        }

        /// <summary>
        ///   The <c>GetWorkoutCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="WorkoutCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="WorkoutBusiness"/> with the newly deserialized <see cref="WorkoutCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="WorkoutCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetWorkoutCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetWorkoutCollection");
            }
            WorkoutCollection vWorkoutCollection = new WorkoutCollection();
            vWorkoutCollection = XmlUtils.Deserialize<WorkoutCollection>(aXmlArgument);
            WorkoutBusiness.Load(aFanKey, vWorkoutCollection);
            return XmlUtils.Serialize<WorkoutCollection>(vWorkoutCollection, true);
        }

        /// <summary>
        ///   The <c>AddWorkout</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Workout"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="WorkoutBusiness"/> with the newly deserialized <see cref="Workout"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Workout Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Workout"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddWorkout(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddWorkout");
            }
            Workout vWorkout = new Workout();
            vWorkout = XmlUtils.Deserialize<Workout>(aXmlArgument);
            WorkoutBusiness.Insert(aFanKey, vWorkout);
            return XmlUtils.Serialize<Workout>(vWorkout, true);
        }

        /// <summary>
        ///   The <c>EditWorkout</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Workout"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="WorkoutBusiness"/> with the newly deserialized <see cref="Workout"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Workout"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditWorkout(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditWorkout");
            }
            Workout vWorkout = new Workout();
            vWorkout = XmlUtils.Deserialize<Workout>(aXmlArgument);
            WorkoutBusiness.Update(aFanKey, vWorkout);
            return XmlUtils.Serialize<Workout>(vWorkout, true);
        }

        /// <summary>
        ///   The <c>DeleteWorkout</c> implementation method deserializes an incoming XML Argument as a new <see cref="Workout"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="WorkoutBusiness"/> with the newly deserialized <see cref="Workout"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Workout"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteWorkout(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteWorkout");
            }
            Workout vWorkout = new Workout();
            vWorkout = XmlUtils.Deserialize<Workout>(aXmlArgument);
            WorkoutBusiness.Delete(aFanKey, vWorkout);
            return XmlUtils.Serialize<Workout>(vWorkout, true);
        }

        #endregion   
      
        #region Activity Methods

        /// <summary>
        ///   Gets the <see cref="Activity"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Activity as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetActivity(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetActivity");
            }
            Activity vActivity = new Activity();
            vActivity = XmlUtils.Deserialize<Activity>(aXmlArgument);
            ActivityBusiness.Load(aFanKey, vActivity);
            return XmlUtils.Serialize<Activity>(vActivity, true);
        }

        /// <summary>
        ///   The <c>GetActivityCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="ActivityCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ActivityBusiness"/> with the newly deserialized <see cref="ActivityCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="ActivityCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetActivityCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetActivityCollection");
            }
            ActivityCollection vActivityCollection = new ActivityCollection();
            vActivityCollection = XmlUtils.Deserialize<ActivityCollection>(aXmlArgument);
            ActivityBusiness.Load(aFanKey, vActivityCollection);
            return XmlUtils.Serialize<ActivityCollection>(vActivityCollection, true);
        }

        /// <summary>
        ///   The <c>AddActivity</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Activity"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="ActivityBusiness"/> with the newly deserialized <see cref="Activity"/> object.
        ///   Finally, it returns the inserted object (now with an assigned Activity Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Activity"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddActivity(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddActivity");
            }
            Activity vActivity = new Activity();
            vActivity = XmlUtils.Deserialize<Activity>(aXmlArgument);
            ActivityBusiness.Insert(aFanKey, vActivity);
            return XmlUtils.Serialize<Activity>(vActivity, true);
        }

        /// <summary>
        ///   The <c>EditActivity</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="Activity"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="ActivityBusiness"/> with the newly deserialized <see cref="Activity"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Activity"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditActivity(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditActivity");
            }
            Activity vActivity = new Activity();
            vActivity = XmlUtils.Deserialize<Activity>(aXmlArgument);
            ActivityBusiness.Update(aFanKey, vActivity);
            return XmlUtils.Serialize<Activity>(vActivity, true);
        }

        /// <summary>
        ///   The <c>DeleteActivity</c> implementation method deserializes an incoming XML Argument as a new <see cref="Activity"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="ActivityBusiness"/> with the newly deserialized <see cref="Activity"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="Activity"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteActivity(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteActivity");
            }
            Activity vActivity = new Activity();
            vActivity = XmlUtils.Deserialize<Activity>(aXmlArgument);
            ActivityBusiness.Delete(aFanKey, vActivity);
            return XmlUtils.Serialize<Activity>(vActivity, true);
        }

        #endregion   
      
        #region FanWorkout Methods

        /// <summary>
        ///   Gets the <see cref="FanWorkout"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>FanWorkout as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanWorkout(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanWorkout");
            }
            FanWorkout vFanWorkout = new FanWorkout();
            vFanWorkout = XmlUtils.Deserialize<FanWorkout>(aXmlArgument);
            FanWorkoutBusiness.Load(aFanKey, vFanWorkout);
            return XmlUtils.Serialize<FanWorkout>(vFanWorkout, true);
        }

        /// <summary>
        ///   The <c>GetFanWorkoutCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanWorkoutCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanWorkoutBusiness"/> with the newly deserialized <see cref="FanWorkoutCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanWorkoutCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanWorkoutCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanWorkoutCollection");
            }
            FanWorkoutCollection vFanWorkoutCollection = new FanWorkoutCollection();
            vFanWorkoutCollection = XmlUtils.Deserialize<FanWorkoutCollection>(aXmlArgument);
            FanWorkoutBusiness.Load(aFanKey, vFanWorkoutCollection);
            return XmlUtils.Serialize<FanWorkoutCollection>(vFanWorkoutCollection, true);
        }

        /// <summary>
        /// Saves the provider suburb.
        /// </summary>
        /// <param name="aFanKey">A user key.</param>
        /// <param name="aXmlArgument">A XML argument.</param>
        /// <returns>A string of XML representing a FanWorkoutCollection</returns>
        /// <exception cref="System.ArgumentNullException">aXmlArgument of SaveFanWorkout</exception>
        public static string SaveFanWorkout(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of SaveFanWorkout");
            }
            FanWorkoutCollection vFanWorkoutCollection = new FanWorkoutCollection();
            vFanWorkoutCollection = XmlUtils.Deserialize<FanWorkoutCollection>(aXmlArgument);
            FanWorkoutBusiness.Save(aFanKey, vFanWorkoutCollection);
            return XmlUtils.Serialize<FanWorkoutCollection>(vFanWorkoutCollection, true);
        }

        #endregion

        #region FanSession Methods

        /// <summary>
        ///   Gets the <see cref="FanSession"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>FanSession as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanSession(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanSession");
            }
            FanSession vFanSession = new FanSession();
            vFanSession = XmlUtils.Deserialize<FanSession>(aXmlArgument);
            FanSessionBusiness.Load(aFanKey, vFanSession);
            return XmlUtils.Serialize<FanSession>(vFanSession, true);
        }

        /// <summary>
        ///   The <c>GetFanSessionCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanSessionCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanSessionBusiness"/> with the newly deserialized <see cref="FanSessionCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanSessionCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanSessionCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanSessionCollection");
            }
            FanSessionCollection vFanSessionCollection = new FanSessionCollection();
            vFanSessionCollection = XmlUtils.Deserialize<FanSessionCollection>(aXmlArgument);
            FanSessionBusiness.Load(aFanKey, vFanSessionCollection);
            return XmlUtils.Serialize<FanSessionCollection>(vFanSessionCollection, true);
        }

        /// <summary>
        ///   The <c>AddFanSession</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanSession"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanSessionBusiness"/> with the newly deserialized <see cref="FanSession"/> object.
        ///   Finally, it returns the inserted object (now with an assigned FanSession Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanSession"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddFanSession(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddFanSession");
            }
            FanSession vFanSession = new FanSession();
            vFanSession = XmlUtils.Deserialize<FanSession>(aXmlArgument);
            FanSessionBusiness.Insert(aFanKey, vFanSession);
            return XmlUtils.Serialize<FanSession>(vFanSession, true);
        }

        /// <summary>
        ///   The <c>EditFanSession</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanSession"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="FanSessionBusiness"/> with the newly deserialized <see cref="FanSession"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanSession"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditFanSession(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditFanSession");
            }
            FanSession vFanSession = new FanSession();
            vFanSession = XmlUtils.Deserialize<FanSession>(aXmlArgument);
            FanSessionBusiness.Update(aFanKey, vFanSession);
            return XmlUtils.Serialize<FanSession>(vFanSession, true);
        }

        /// <summary>
        ///   The <c>DeleteFanSession</c> implementation method deserializes an incoming XML Argument as a new <see cref="FanSession"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="FanSessionBusiness"/> with the newly deserialized <see cref="FanSession"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanSession"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteFanSession(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteFanSession");
            }
            FanSession vFanSession = new FanSession();
            vFanSession = XmlUtils.Deserialize<FanSession>(aXmlArgument);
            FanSessionBusiness.Delete(aFanKey, vFanSession);
            return XmlUtils.Serialize<FanSession>(vFanSession, true);
        }

        /// <summary>
        /// Saves the provider suburb.
        /// </summary>
        /// <param name="aFanKey">A user key.</param>
        /// <param name="aXmlArgument">A XML argument.</param>
        /// <returns>A string of XML representing a FanSessionCollection</returns>
        /// <exception cref="System.ArgumentNullException">aXmlArgument of SaveFanSession</exception>
        public static string SaveFanSession(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of SaveFanSession");
            }
            FanSessionCollection vFanSessionCollection = new FanSessionCollection();
            vFanSessionCollection = XmlUtils.Deserialize<FanSessionCollection>(aXmlArgument);
            FanSessionBusiness.Save(aFanKey, vFanSessionCollection);
            return XmlUtils.Serialize<FanSessionCollection>(vFanSessionCollection, true);
        }

        #endregion

        #region FanSessionActivity Methods

        /// <summary>
        ///   Gets the <see cref="FanSessionActivity"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>FanSessionActivity as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanSessionActivity(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanSessionActivity");
            }
            FanSessionActivity vFanSessionActivity = new FanSessionActivity();
            vFanSessionActivity = XmlUtils.Deserialize<FanSessionActivity>(aXmlArgument);
            FanSessionActivityBusiness.Load(aFanKey, vFanSessionActivity);
            return XmlUtils.Serialize<FanSessionActivity>(vFanSessionActivity, true);
        }

        /// <summary>
        ///   The <c>GetFanSessionActivityCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="FanSessionActivityCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="FanSessionActivityBusiness"/> with the newly deserialized <see cref="FanSessionActivityCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="FanSessionActivityCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFanSessionActivityCollection(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFanSessionActivityCollection");
            }
            FanSessionActivityCollection vFanSessionActivityCollection = new FanSessionActivityCollection();
            vFanSessionActivityCollection = XmlUtils.Deserialize<FanSessionActivityCollection>(aXmlArgument);
            FanSessionActivityBusiness.Load(aFanKey, vFanSessionActivityCollection);
            return XmlUtils.Serialize<FanSessionActivityCollection>(vFanSessionActivityCollection, true);
        }

        /// <summary>
        /// Saves the provider suburb.
        /// </summary>
        /// <param name="aFanKey">A user key.</param>
        /// <param name="aXmlArgument">A XML argument.</param>
        /// <returns>A string of XML representing a FanSessionActivityCollection</returns>
        /// <exception cref="System.ArgumentNullException">aXmlArgument of SaveFanSessionActivity</exception>
        public static string SaveFanSessionActivity(FanKey aFanKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of SaveFanSessionActivity");
            }
            FanSessionActivityCollection vFanSessionActivityCollection = new FanSessionActivityCollection();
            vFanSessionActivityCollection = XmlUtils.Deserialize<FanSessionActivityCollection>(aXmlArgument);
            FanSessionActivityBusiness.Save(aFanKey, vFanSessionActivityCollection);
            return XmlUtils.Serialize<FanSessionActivityCollection>(vFanSessionActivityCollection, true);
        }

        #endregion
    }
}