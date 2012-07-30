// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestTreeItem.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The test tree item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest.TestUtility
{
    using System;

    using IronFramework.Utility.UI;
    using Xunit;

    /// <summary>
    /// The test tree item.
    /// </summary>
    public class TestTreeItem
    {
        #region Public Methods

        /// <summary>
        /// The test data contract json serializer.
        /// How to: Serialize and Deserialize JSON Data
        ///http://msdn.microsoft.com/en-us/library/bb412179.aspx
        ///http://msdn.microsoft.com/en-us/library/system.runtime.serialization.json.datacontractjsonserializer(v=VS.100).aspx
        ///http://stackoverflow.com/questions/4367022/working-with-json-on-the-server-side-in-asp-net-and-c
        ///http://weblogs.asp.net/gunnarpeipman/archive/2010/12/28/asp-net-serializing-and-deserializing-json-objects.aspx
        ///http://weblogs.asp.net/gunnarpeipman/archive/2010/12/28/asp-net-serializing-and-deserializing-json-objects.aspx
        /// </summary>
        [Fact]
        public void TestDataContractJsonSerializer()
        {
            var treeitem = new TreeItem<string>();
            treeitem.Id = "1";
            treeitem.Text = "Root";
            treeitem.Value = "3223";
            treeitem.Isexpand = true;
            treeitem.Showcheck = true;
            treeitem.Add(
                new TreeItem<string>
                    {
                       Id = "2", Text = "Node2", Value = "9982", Showcheck = true, Isexpand = true, Checkstate = 1 
                    });

            string mstr = treeitem.ToJsonString2();

            Console.WriteLine(mstr);

            string tstr = treeitem.ToJsonString();
            Console.WriteLine(tstr);

            Assert.Equal(tstr.Length, mstr.Length);
        }

        #endregion
    }
}