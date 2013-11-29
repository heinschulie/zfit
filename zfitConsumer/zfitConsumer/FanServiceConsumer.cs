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
    public class FanServiceConsumer
    {

        #region Role Service Calls

        /// <summary>
        ///   Gets a specified <see cref="Role"/> by key.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aFanToken">A user token.</param>
        public static void GetRole(FanToken aFanToken, Role aRole)
        {
            FanCallHandler.ServiceCall<Role>(aFanToken, "GetRole", aRole);
        }

        /// <summary>
        ///   Gets a specified <see cref="RoleCollection"/>.
        /// </summary>
        /// <param name="aRoleCollection"><see cref="Role"/>Collection object.</param>
        /// <param name="aFanToken">A user token.</param>
        public static void GetRoleCollection(FanToken aFanToken, RoleCollection aRoleCollection)
        {
            FanCallHandler.ServiceCall<RoleCollection>(aFanToken, "GetRoleCollection", aRoleCollection);
        }

        /// <summary>
        ///   Add a <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aFanToken">A user token.</param>
        public static void AddRole(FanToken aFanToken, Role aRole)
        {
            FanCallHandler.ServiceCall<Role>(aFanToken, "AddRole", aRole);
        }

        /// <summary>
        ///   Edit a specified <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aFanToken">A user token.</param>
        public static void EditRole(FanToken aFanToken, Role aRole)
        {
            FanCallHandler.ServiceCall<Role>(aFanToken, "EditRole", aRole);
        }

        /// <summary>
        ///   Delete a specified <see cref="Role"/>.
        /// </summary>
        /// <param name="aRole"><see cref="Role"/> object.</param>
        /// <param name="aFanToken">A user token.</param>
        public static void DeleteRole(FanToken aFanToken, Role aRole)
        {
            FanCallHandler.ServiceCall<Role>(aFanToken, "DeleteRole", aRole);
        }

        #endregion

        #region RoleFunctionEditor Service Calls

        /// <summary>
        ///   Get a specified <see cref="RoleFunctionEditor"/>.
        /// </summary>
        /// <param name="aRoleFunctionEditor">A <see cref="RoleFunctionEditor"/> object.</param>
        /// <param name="aFanToken">A user token.</param>
        //public static void GetRoleFunctionEditor(FanToken aFanToken, RoleFunctionEditor aRoleFunctionEditor)
        //{
        //    FanCallHandler.ServiceCall<RoleFunctionEditor>(aFanToken, "GetRoleFunctionEditor", aRoleFunctionEditor);
        //}

        /// <summary>
        ///   Put a specified <see cref="RoleFunctionEditor"/>.
        /// </summary>
        /// <param name="aRoleFunctionEditor">A <see cref="RoleFunctionEditor"/> object.</param>
        /// <param name="aFanToken">A user token.</param>
        //public static void PutRoleFunctionEditor(FanToken aFanToken, RoleFunctionEditor aRoleFunctionEditor)
        //{
        //    FanCallHandler.ServiceCall<RoleFunctionEditor>(aFanToken, "PutRoleFunctionEditor", aRoleFunctionEditor);
        //}

        #endregion

        #region Fan Service Calls
        
        /// <summary>
        /// Call the WebService with a request to return a Fan with a specified FanID
        /// </summary>
        /// <param name="aFan">The Fan object to return</param>
        /// <param name="aFanToken">A user token.</param>
        public static void GetFanByID(FanToken aFanToken, Fan aFan)
        {
            FanCallHandler.ServiceCall<Fan>(aFanToken, "GetFanByID", aFan);
        }

        /// <summary>
        /// Call the WebService with a request to return a Fan with a specified FanKey
        /// </summary>
        /// <param name="aFan">The Fan object to return</param>
        /// <param name="aFanToken">A user token.</param>
        public static void GetFan(FanToken aFanToken, Fan aFan)
        {
            FanCallHandler.ServiceCall<Fan>(aFanToken, "GetFan", aFan);
        }

        /// <summary>
        /// Gets a FanCollection
        /// </summary>
        /// <param name="aFanToken">A user token.</param>
        /// <param name="aFanCollection">A user collection.</param>
        public static void GetFanCollection(FanToken aFanToken, FanCollection aFanCollection)
        {
            FanCallHandler.ServiceCall<FanCollection>(aFanToken, "GetFanCollection", aFanCollection);
        }

        /// <summary>
        /// Call the WebService with a request to Add a Fan
        /// </summary>
        /// <param name="aFan">The Fan object to Add</param>
        /// <param name="aFanToken">A user token.</param>
        public static void AddFan(FanToken aFanToken, Fan aFan)
        {
            FanCallHandler.ServiceCall<Fan>(aFanToken, "AddFan", aFan);
        }

        /// <summary>
        /// Call the WebService with a request to Edit a Fan
        /// </summary>
        /// <param name="aFan">The Fan object to Edit</param>
        /// <param name="aFanToken">A user token.</param>
        public static void EditFan(FanToken aFanToken, Fan aFan)
        {
            FanCallHandler.ServiceCall<Fan>(aFanToken, "EditFan", aFan);
        }

        /// <summary>
        /// Call the WebService with a request to Delete a Fan
        /// </summary>
        /// <param name="aFan">The Fan object to Delete</param>
        /// <param name="aFanToken">A user token.</param>
        public static void DeleteFan(FanToken aFanToken, Fan aFan)
        {
            FanCallHandler.ServiceCall<Fan>(aFanToken, "DeleteFan", aFan);
        }
        #endregion

        #region FanFunctionAccess Service Calls
        /// <summary>
        /// Get a specific <see cref="FanFunctionAccess"/>.
        /// </summary>
        /// <param name="aFanToken">A user token.</param>
        /// <param name="aFanFunctionAccess">The FanFunctionAccess to return</param>
        public static void GetFanFunctionAccessCollection(FanToken aFanToken, FanFunctionAccess aFanFunctionAccess)
        {
            FanCallHandler.ServiceCall<FanFunctionAccess>(aFanToken, "GetFanFunctionAccess", aFanFunctionAccess);
        }

        /// <summary>
        /// Get a Collection of <see cref="FanFunctionAccess"/>.
        /// </summary>
        /// <param name="aFanToken">A user token.</param>
        /// <param name="aFanFunctionAccessCollection">The FanFunctionAccessCollection containing the List to return</param>
        public static void GetFanFunctionAccessCollection(FanToken aFanToken, FanFunctionAccessCollection aFanFunctionAccessCollection)
        {
            FanCallHandler.ServiceCall<FanFunctionAccessCollection>(aFanToken, "GetFanFunctionAccessCollection", aFanFunctionAccessCollection);
        }
        #endregion

        #region FanRoleEditor Service Calls

        /// <summary>
        /// Gets a <see cref="FanRoleEditor"/> from the Ruci SOAP Service
        /// </summary>
        /// <param name="aFanToken">A user token.</param>
        /// <param name="aFanRoleEditor">A user role editor.</param>
        //public static void GetFanRoleEditor(FanToken aFanToken, FanRoleEditor aFanRoleEditor)
        //{
        //    FanCallHandler.ServiceCall<FanRoleEditor>(aFanToken, "GetFanRoleEditor", aFanRoleEditor);
        //}

        /// <summary>
        /// Puts a <see cref="FanRoleEditor"/> via the Ruci SOAP Service
        /// </summary>
        /// <param name="aFanToken">A user token.</param>
        /// <param name="aFanRoleEditor">A user role editor.</param>
        //public static void PutFanRoleEditor(FanToken aFanToken, FanRoleEditor aFanRoleEditor)
        //{
        //    FanCallHandler.ServiceCall<FanRoleEditor>(aFanToken, "PutFanRoleEditor", aFanRoleEditor);
        //}

        #endregion


        #region Fan Service Calls        

        /// <summary>
        /// Call the WebService with a request to return a Fan with a specified FanKey
        /// </summary>
        /// <param name="aCell">The Fan object to return</param>
        /// <param name="aCellToken">A user token.</param>
        public static void GetCell(FanToken aCellToken, Cell aCell)
        {
            FanCallHandler.ServiceCall<Cell>(aCellToken, "GetCell", aCell);
        }

        /// <summary>
        /// Gets a FanCollection
        /// </summary>
        /// <param name="aCellToken">A user token.</param>
        /// <param name="aCellCollection">A user collection.</param>
        public static void GetCellCollection(FanToken aCellToken, FanCollection aCellCollection)
        {
            FanCallHandler.ServiceCall<CellCollection>(aCellToken, "GetCellCollection", aCellCollection);
        }

        /// <summary>
        /// Call the WebService with a request to Add a Fan
        /// </summary>
        /// <param name="aCell">The Fan object to Add</param>
        /// <param name="aCellToken">A user token.</param>
        public static void AddFan(FanToken aCellToken, Cell aCell)
        {
            FanCallHandler.ServiceCall<Cell>(aCellToken, "AddFan", aCell);
        }

        /// <summary>
        /// Call the WebService with a request to Edit a Fan
        /// </summary>
        /// <param name="aCell">The Fan object to Edit</param>
        /// <param name="aCellToken">A user token.</param>
        public static void EditCell(FanToken aCellToken, Cell aCell)
        {
            FanCallHandler.ServiceCall<Cell>(aCellToken, "EditCell", aCell);
        }

        /// <summary>
        /// Call the WebService with a request to Delete a Fan
        /// </summary>
        /// <param name="aCell">The Fan object to Delete</param>
        /// <param name="aCellToken">A user token.</param>
        public static void DeleteCell(FanToken aCellToken, Cell aCell)
        {
            FanCallHandler.ServiceCall<Cell>(aCellToken, "DeleteCell", aCell);
        }
        #endregion

    }
}
