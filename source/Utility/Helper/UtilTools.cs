// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilTools.cs" company="Megadotnet">
// Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  UtilTools
// </summary>
// --------------------------------------------------------------------------------------------------------------------	
namespace IronFramework.Utility.Helper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Web;

    /// <summary>
    /// UtilTools
    /// </summary>
    public class UtilTools
    {
        /// <summary>
        /// Get guest IP address
        /// </summary>
        /// <returns>string</returns>
        public static string GetGuestIP()
        {
            string guestIP = string.Empty;
            var currentContext = HttpContext.Current;
            if (currentContext != null)
            {
                guestIP = currentContext.Request.UserHostAddress;
            }
            return guestIP;
        }


        /// <summary>
        /// Gets the current ip address.
        /// </summary>
        /// <value>
        /// The current ip address.
        /// </value>
        public static string OwnIPAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
        }


        /// <summary>
        /// MergeSetsAndDoAction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uIPrivilegeIds">The u i privilege ids.</param>
        /// <param name="dbPrivilegeIDs">The database privilege i ds.</param>
        /// <param name="delAction">The delete action.</param>
        /// <param name="createAction">The create action.</param>
        /// <example><code>
        /// [Fact]
        ///public void MergePrivilegeIdsTests()
        ///{
        ///    var dbPrivilegeIDs = new int[] { 23, 1, 2, 3, 5, 6 };
        ///    var uIPrivilegeIDs = new int[] { 1, 2, 3, 5, 6 };
        ///    UtilTools.MergeSetsAndDoAction<int>(uIPrivilegeIDs, dbPrivilegeIDs, delSets =>
        ///    {
        ///        delSets.ToList().ForEach(dd => Console.WriteLine("for delete {0}", dd));
        ///    }
        ///     , createSets =>
        ///     {
        ///         createSets.ToList().ForEach(dd => Console.WriteLine("for add {0}", dd));
        ///     });
        ///}
        /// [Fact]
        ///public void TestToWithSameList()
        ///{
        ///    var dbPrivilegeIDs = new int[] { 23, 1, 2, 3, 5, 6 };
        ///    var uIPrivilegeIDs = new int[] { 23, 1, 2, 3, 5, 6 };
        ///    var DifferencesList = dbPrivilegeIDs.Where(x => !uIPrivilegeIDs.Any(x1 => x1 == x))
        ///                .Union(uIPrivilegeIDs.Where(x => !dbPrivilegeIDs.Any(x1 => x1 == x)));
        ///    Assert.True(DifferencesList.Count() == 0);
        ///}
        ///}
        /// </code></example>
        public static bool MergeSetsAndDoAction<T>(T[] uIPrivilegeIds, T[] dbPrivilegeIDs, Action<HashSet<T>> delAction, Action<HashSet<T>> createAction)
        {
            bool flag = false;
            var uIPrivilegeSets = new HashSet<T>(uIPrivilegeIds);
            var dbPrivilegeSets = new HashSet<T>(dbPrivilegeIDs);

            uIPrivilegeSets.SymmetricExceptWith(dbPrivilegeSets);
            //uIPrivilegeIDs.ToList().ForEach(dd => Console.WriteLine(dd));

            dbPrivilegeSets.IntersectWith(uIPrivilegeSets);
            // dbPrivilegeIDs.ToList().ForEach(dd => Console.WriteLine("for delete {0}", dd));
            using (var tsCope = new System.Transactions.TransactionScope())
            {
                //delete action 
                if (dbPrivilegeSets.Count != 0)
                {
                    delAction(dbPrivilegeSets);

                    uIPrivilegeSets.ExceptWith(dbPrivilegeSets);

                }

                //add action
                if (uIPrivilegeSets.Count != 0)
                {
                    createAction(uIPrivilegeSets);
                }
                tsCope.Complete();
            }
            flag = true;
            return flag;

        }
    }
}