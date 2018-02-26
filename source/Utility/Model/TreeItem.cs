// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TreeItem.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   TreeItem represent UI JQuery tree object
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    /// <summary>
    /// TreeItem represent UI  tree object
    /// </summary>
    /// <typeparam name="TValue">
    /// The type of the value.
    /// </typeparam>
    [DataContract]
    public class TreeItem<TValue> : ITreeNode<TreeItem<TValue>, TValue>
    {
        #region Constants and Fields

        /// <summary>
        /// The children.
        /// </summary>
        private readonly List<TreeItem<TValue>> children = new List<TreeItem<TValue>>();

        /// <summary>
        /// The _haschild.
        /// </summary>
        private bool _haschild;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeItem{TValue}"/> class.
        /// </summary>
        public TreeItem()
        {
            this.Showcheck = true;
            this.Checkstate = 0;
            this.Complete = true;
            this.Isexpand = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the checkstate.
        /// </summary>
        /// <value>The checkstate.</value>
        [DataMember(Name = "checkstate")]
        public int Checkstate { get; set; }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        [JsonProperty("ChildNodes")]
        [DataMember(Name = "ChildNodes")]
        public IEnumerable<TreeItem<TValue>> Children
        {
            get
            {
                return this.children;
            }
        }

        /// <summary>
        ///  whether load complete（indicating whether async load data）
        ///  Suppose sync load data to node should be true
        /// </summary>
        /// <value><c>true</c> if complete; otherwise, <c>false</c>.</value>
        [DataMember(Name = "complete")]
        public bool Complete { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance has children.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has children; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "hasChildren")]
        public bool HasChildren
        {
            get
            {
                return this.Children != null && this.Children.Count() > 0;
            }

            set
            {
                this._haschild = value;
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        /// <remarks>type must be string,because Jquery tree will use it replace method on it</remarks>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TreeItem"/> is isexpand.
        /// </summary>
        /// <value><c>true</c> if isexpand; otherwise, <c>false</c>.</value>
        [DataMember(Name = "isexpand")]
        public bool Isexpand { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public TreeItem<TValue> Parent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TreeItem"/> is showcheck.
        /// </summary>
        /// <value><c>true</c> if showcheck; otherwise, <c>false</c>.</value>
        [DataMember(Name = "showcheck")]
        public bool Showcheck { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        [DataMember(Name = "value")]
        public TValue Value { get; set; }

        #endregion

        #region Implemented Interfaces

        #region ITreeNode<TreeItem<TValue>,TValue>

        /// <summary>
        /// Adds the specified node.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <returns>
        /// The add.
        /// </returns>
        public bool Add(TreeItem<TValue> node)
        {
            if (node != null)
            {
                this.children.Add(node);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the specified node.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <returns>
        /// The remove.
        /// </returns>
        public bool Remove(TreeItem<TValue> node)
        {
            if (node != null)
            {
                return this.children.Remove(node);
            }

            return false;
        }

        #endregion

        #endregion
    }
}