﻿using System;
using System.Collections.Generic;
using System.Linq;
using Zephry;

namespace zfit
{
    /// <summary>
    /// A collection of static methods, each directly associated with a remote WebMethod. Each static method takes two arguments,
    /// the requesting user and the object that must be operated upon, and calls the specialized ServiceCall method with both arguments
    /// and the name of the corresponding web method.
    /// </summary>
    public class UserServiceConsumer
    {

        #region Role Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Role"/> by key.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "GetRole", aRole);
        }

        /// <summary>
        ///   Gets a specified <see cref="RoleCollection"/>.
        /// </summary>
        /// <param name="aRoleCollection"><see cref="Role"/>Collection object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetRoleCollection(UserToken aUserToken, RoleCollection aRoleCollection)
        {
            UserCallHandler.ServiceCall<RoleCollection>(aUserToken, "GetRoleCollection", aRoleCollection);
        }

        /// <summary>
        ///   Add a <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void AddRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "AddRole", aRole);
        }

        /// <summary>
        ///   Edit a specified <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void EditRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "EditRole", aRole);
        }

        /// <summary>
        ///   Delete a specified <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        public static void DeleteRole(UserToken aUserToken, Role aRole)
        {
            UserCallHandler.ServiceCall<Role>(aUserToken, "DeleteRole", aRole);
        }

        #endregion

        #region RoleFunctionEditor Service Calls

        /// <summary>
        ///   Get a specified <see cref="RoleFunctionEditor"/>.
        /// </summary>
        /// <param name="aRoleFunctionEditor">A <see cref="RoleFunctionEditor"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        //public static void GetRoleFunctionEditor(UserToken aUserToken, RoleFunctionEditor aRoleFunctionEditor)
        //{
        //    UserCallHandler.ServiceCall<RoleFunctionEditor>(aUserToken, "GetRoleFunctionEditor", aRoleFunctionEditor);
        //}

        /// <summary>
        ///   Put a specified <see cref="RoleFunctionEditor"/>.
        /// </summary>
        /// <param name="aRoleFunctionEditor">A <see cref="RoleFunctionEditor"/> object.</param>
        /// <param name="aUserToken">A user token.</param>
        //public static void PutRoleFunctionEditor(UserToken aUserToken, RoleFunctionEditor aRoleFunctionEditor)
        //{
        //    UserCallHandler.ServiceCall<RoleFunctionEditor>(aUserToken, "PutRoleFunctionEditor", aRoleFunctionEditor);
        //}

        #endregion

        #region User Service Calls
        
        /// <summary>
        /// Call the WebService with a request to return a User with a specified UserID
        /// </summary>
        /// <param name="aUser">The User object to return</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetUserByID(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "GetUserByID", aUser);
        }

        /// <summary>
        /// Call the WebService with a request to return a User with a specified UserKey
        /// </summary>
        /// <param name="aUser">The User object to return</param>
        /// <param name="aUserToken">A user token.</param>
        public static void GetUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "GetUser", aUser);
        }

        /// <summary>
        /// Gets a UserCollection
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserCollection">A user collection.</param>
        public static void GetUserCollection(UserToken aUserToken, UserCollection aUserCollection)
        {
            UserCallHandler.ServiceCall<UserCollection>(aUserToken, "GetUserCollection", aUserCollection);
        }

        /// <summary>
        /// Call the WebService with a request to Add a User
        /// </summary>
        /// <param name="aUser">The User object to Add</param>
        /// <param name="aUserToken">A user token.</param>
        public static void AddUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "AddUser", aUser);
        }

        /// <summary>
        /// Call the WebService with a request to Edit a User
        /// </summary>
        /// <param name="aUser">The User object to Edit</param>
        /// <param name="aUserToken">A user token.</param>
        public static void EditUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "EditUser", aUser);
        }

        /// <summary>
        /// Call the WebService with a request to Delete a User
        /// </summary>
        /// <param name="aUser">The User object to Delete</param>
        /// <param name="aUserToken">A user token.</param>
        public static void DeleteUser(UserToken aUserToken, User aUser)
        {
            UserCallHandler.ServiceCall<User>(aUserToken, "DeleteUser", aUser);
        }
        #endregion

        #region UserFunctionAccess Service Calls
        /// <summary>
        /// Get a specific <see cref="UserFunctionAccess"/>.
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserFunctionAccess">The UserFunctionAccess to return</param>
        public static void GetUserFunctionAccessCollection(UserToken aUserToken, UserFunctionAccess aUserFunctionAccess)
        {
            UserCallHandler.ServiceCall<UserFunctionAccess>(aUserToken, "GetUserFunctionAccess", aUserFunctionAccess);
        }

        /// <summary>
        /// Get a Collection of <see cref="UserFunctionAccess"/>.
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserFunctionAccessCollection">The UserFunctionAccessCollection containing the List to return</param>
        public static void GetUserFunctionAccessCollection(UserToken aUserToken, UserFunctionAccessCollection aUserFunctionAccessCollection)
        {
            UserCallHandler.ServiceCall<UserFunctionAccessCollection>(aUserToken, "GetUserFunctionAccessCollection", aUserFunctionAccessCollection);
        }
        #endregion

        #region UserRoleEditor Service Calls

        /// <summary>
        /// Gets a <see cref="UserRoleEditor"/> from the Ruci SOAP Service
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserRoleEditor">A user role editor.</param>
        //public static void GetUserRoleEditor(UserToken aUserToken, UserRoleEditor aUserRoleEditor)
        //{
        //    UserCallHandler.ServiceCall<UserRoleEditor>(aUserToken, "GetUserRoleEditor", aUserRoleEditor);
        //}

        /// <summary>
        /// Puts a <see cref="UserRoleEditor"/> via the Ruci SOAP Service
        /// </summary>
        /// <param name="aUserToken">A user token.</param>
        /// <param name="aUserRoleEditor">A user role editor.</param>
        //public static void PutUserRoleEditor(UserToken aUserToken, UserRoleEditor aUserRoleEditor)
        //{
        //    UserCallHandler.ServiceCall<UserRoleEditor>(aUserToken, "PutUserRoleEditor", aUserRoleEditor);
        //}

        #endregion
        
    }
}
