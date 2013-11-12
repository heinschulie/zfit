using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zephry;

namespace zfit
{
    public class UserImplementation
    {
        #region Function Methods

        /// <summary>
        ///   Gets the <see cref="Function"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>Function as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Load(aUserKey, vFunction);
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
        public static string GetFunctionCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetFunctionCollection");
            }
            FunctionCollection vFunctionCollection = new FunctionCollection();
            vFunctionCollection = XmlUtils.Deserialize<FunctionCollection>(aXmlArgument);
            FunctionBusiness.Load(aUserKey, vFunctionCollection);
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
        public static string AddFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Insert(aUserKey, vFunction);
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
        public static string EditFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Update(aUserKey, vFunction);
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
        public static string DeleteFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteFunction");
            }
            Function vFunction = new Function();
            vFunction = XmlUtils.Deserialize<Function>(aXmlArgument);
            FunctionBusiness.Delete(aUserKey, vFunction);
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
        public static string GetRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Load(aUserKey, vRoleFunction);
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
        public static string GetRoleFunctionCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleFunctionCollection");
            }
            RoleFunctionCollection vRoleFunctionCollection = new RoleFunctionCollection();
            vRoleFunctionCollection = XmlUtils.Deserialize<RoleFunctionCollection>(aXmlArgument);
            RoleFunctionBusiness.Load(aUserKey, vRoleFunctionCollection);
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
        public static string AddRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Insert(aUserKey, vRoleFunction);
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
        public static string EditRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Update(aUserKey, vRoleFunction);
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
        public static string DeleteRoleFunction(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteRoleFunction");
            }
            RoleFunction vRoleFunction = new RoleFunction();
            vRoleFunction = XmlUtils.Deserialize<RoleFunction>(aXmlArgument);
            RoleFunctionBusiness.Delete(aUserKey, vRoleFunction);
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
        public static string GetRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Load(aUserKey, vRole);
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
        public static string GetRoleCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetRoleCollection");
            }
            RoleCollection vRoleCollection = new RoleCollection();
            vRoleCollection = XmlUtils.Deserialize<RoleCollection>(aXmlArgument);
            RoleBusiness.Load(aUserKey, vRoleCollection);
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
        public static string AddRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Insert(aUserKey, vRole);
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
        public static string EditRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Update(aUserKey, vRole);
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
        public static string DeleteRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteRole");
            }
            Role vRole = new Role();
            vRole = XmlUtils.Deserialize<Role>(aXmlArgument);
            RoleBusiness.Delete(aUserKey, vRole);
            return XmlUtils.Serialize<Role>(vRole, true);
        }

        #endregion

        #region UserRole Methods

        /// <summary>
        ///   Gets the <see cref="UserRole"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>UserRole as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Load(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        /// <summary>
        ///   The <c>GetUserRoleCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserRoleCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRoleCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRoleCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserRoleCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserRoleCollection");
            }
            UserRoleCollection vUserRoleCollection = new UserRoleCollection();
            vUserRoleCollection = XmlUtils.Deserialize<UserRoleCollection>(aXmlArgument);
            UserRoleBusiness.Load(aUserKey, vUserRoleCollection);
            return XmlUtils.Serialize<UserRoleCollection>(vUserRoleCollection, true);
        }

        /// <summary>
        ///   The <c>AddUserRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserRole"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRole"/> object.
        ///   Finally, it returns the inserted object (now with an assigned UserRole Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Insert(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        /// <summary>
        ///   The <c>EditUserRole</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserRole"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRole"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Update(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        /// <summary>
        ///   The <c>DeleteUserRole</c> implementation method deserializes an incoming XML Argument as a new <see cref="UserRole"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="UserRoleBusiness"/> with the newly deserialized <see cref="UserRole"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserRole"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteUserRole(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteUserRole");
            }
            UserRole vUserRole = new UserRole();
            vUserRole = XmlUtils.Deserialize<UserRole>(aXmlArgument);
            UserRoleBusiness.Delete(aUserKey, vUserRole);
            return XmlUtils.Serialize<UserRole>(vUserRole, true);
        }

        #endregion

        #region User Methods

        /// <summary>
        ///   Gets the <see cref="User"/> by UserID.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>User as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserByID(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserByID");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.LoadByID(vUser, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   Gets the <see cref="User"/> by Key.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns>User as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Load(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   The <c>GetUserCollection</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="UserCollection"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="UserCollection"/> object.
        ///   Finally, it returns the collection object as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="UserCollection"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string GetUserCollection(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of GetUserCollection");
            }
            UserCollection vUserCollection = new UserCollection();
            vUserCollection = XmlUtils.Deserialize<UserCollection>(aXmlArgument);
            UserBusiness.Load(aUserKey, vUserCollection);
            return XmlUtils.Serialize<UserCollection>(vUserCollection, true);
        }

        /// <summary>
        ///   The <c>AddUser</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="User"/> object.
        ///   It invokes the <c>Insert</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="User"/> object.
        ///   Finally, it returns the inserted object (now with an assigned User Key) as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="User"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string AddUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of AddUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Insert(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   The <c>EditUser</c> implementation method deserializes an incoming XML Argument <see cref="string"/> as a new <see cref="User"/> object.
        ///   It invokes the <c>Update</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="User"/> object.
        ///   Finally, it returns the updated object unchanged as a serialized <see cref="string"/> of XML.
        /// </summary>
        /// <param name="aXmlArgument">XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="User"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string EditUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of EditUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Update(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        /// <summary>
        ///   The <c>DeleteUser</c> implementation method deserializes an incoming XML Argument as a new <see cref="User"/> object.
        ///   It invokes the <c>Delete</c> method of <see cref="UserBusiness"/> with the newly deserialized <see cref="User"/> object.
        ///   Finally, it returns the Deleted object unchanged as a serialized <c>string</c> of XML.
        /// </summary>
        /// <param name="aXmlArgument">A XML Argument <see cref="string"/>.</param>
        /// <returns><see cref="User"/> as XML <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">If <c>aXmlArgument</c> is <c>null</c>.</exception>
        public static string DeleteUser(UserKey aUserKey, string aXmlArgument)
        {
            if (aXmlArgument == null)
            {
                throw new ArgumentNullException("aXmlArgument of DeleteUser");
            }
            User vUser = new User();
            vUser = XmlUtils.Deserialize<User>(aXmlArgument);
            UserBusiness.Delete(aUserKey, vUser);
            return XmlUtils.Serialize<User>(vUser, true);
        }

        #endregion   

    }
}