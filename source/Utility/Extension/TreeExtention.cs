// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeExtention.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   TreeExtention
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.UI
{
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Json;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// TreeExtention
    /// </summary>
    public static class TreeExtention
    {
        #region Public Methods

        /// <summary>
        /// Selects the item.
        /// </summary>
        /// <typeparam name="TValue">
        /// </typeparam>
        /// <param name="ti">
        /// The ti.
        /// </param>
        /// <param name="arrId">
        /// The arr id.
        /// </param>
        /// <returns>
        /// </returns>
        public static TreeItem<TValue> SelectItem<TValue>(this TreeItem<TValue> ti, TValue[] arrId)
        {
            return SelectImte(ti, arrId);
        }

        /// <summary>
        /// The to format json string.
        /// </summary>
        /// <param name="treeItem">
        /// The tree item.
        /// </param>
        /// <typeparam name="TValue">
        /// </typeparam>
        /// <returns>
        /// The to format json string.
        /// </returns>
        public static string ToFormatJsonString<TValue>(this TreeItem<TValue> treeItem)
        {
            string sJson = JsonConvert.SerializeObject(
                treeItem, 
                Formatting.Indented, 
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            return "var treedata=[" + sJson + "];";
        }

        /// <summary>
        /// Toes the json string.
        /// </summary>
        /// <typeparam name="TValue">
        /// The type of the value.
        /// </typeparam>
        /// <param name="treeItem">
        /// The tree item.
        /// </param>
        /// <returns>
        /// The to json string.
        /// </returns>
        public static string ToJsonString<TValue>(this TreeItem<TValue> treeItem)
        {
            string sJson = JsonConvert.SerializeObject(treeItem);
            return "var treedata=[" + sJson + "];";
        }

        /// <summary>
        /// The to json string 2.
        /// </summary>
        /// <param name="treeItem">
        /// The tree item.
        /// </param>
        /// <typeparam name="TValue">
        /// </typeparam>
        /// <returns>
        /// The to json string 2.
        /// </returns>
        public static string ToJsonString2<TValue>(this TreeItem<TValue> treeItem)
        {
            string mstr = string.Empty;
            using (var stream1 = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(TreeItem<string>));
                ser.WriteObject(stream1, treeItem);
                stream1.Position = 0;
                var sr = new StreamReader(stream1);

                return mstr = "var treedata=[" + sr.ReadToEnd() + "];";
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Selects the imte.
        /// </summary>
        /// <typeparam name="TValue">
        /// The type of the value.
        /// </typeparam>
        /// <param name="ti">
        /// The ti.
        /// </param>
        /// <param name="checkstatevalue">
        /// The checkstatevalue.
        /// </param>
        /// <returns>
        /// </returns>
        private static TreeItem<TValue> SelectImte<TValue>(TreeItem<TValue> ti, int checkstatevalue)
        {
            ti.Checkstate = 1;
            if (ti.HasChildren)
            {
                for (int i = 0; i < ti.Children.Count(); i++)
                {
                    SelectImte(ti.Children.ToList()[i], 1);
                }
            }

            return ti;
        }

        /// <summary>
        /// Selects the imte.
        /// </summary>
        /// <typeparam name="TValue">
        /// The type of the value.
        /// </typeparam>
        /// <param name="ti">
        /// The ti.
        /// </param>
        /// <param name="arrId">
        /// The arr id.
        /// </param>
        /// <returns>
        /// </returns>
        private static TreeItem<TValue> SelectImte<TValue>(TreeItem<TValue> ti, TValue[] arrId)
        {
            if (arrId.Any(p => p.Equals(ti.Value)))
            {
                ti.Checkstate = 1;

                if (ti.HasChildren)
                {
                    for (int i = 0; i < ti.Children.Count(); i++)
                    {
                        SelectImte(ti.Children.ToList()[i], 1);
                    }
                }
            }
            else
            {
                if (ti.HasChildren)
                {
                    for (int i = 0; i < ti.Children.Count(); i++)
                    {
                        SelectImte(ti.Children.ToList()[i], arrId);
                    }

                    int nCount = ti.Children.Count(p => p.Checkstate == 1);
                    if (nCount == 0)
                    {
                        ti.Checkstate = 0;
                    }
                    else if (ti.Children.Count() == nCount)
                    {
                        ti.Checkstate = 1;
                    }
                    else
                    {
                        ti.Checkstate = 2;
                    }
                }
            }

            return ti;
        }

        #endregion
    }
}