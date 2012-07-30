// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITreeNode.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   ITreeNode
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.UI
{
    using System.Collections.Generic;

    /// <summary>
    /// ITreeNode
    /// </summary>
    /// <typeparam name="TNode">
    /// The type of the node.
    /// </typeparam>
    /// <typeparam name="TValue">
    /// The type of the value.
    /// </typeparam>
    public interface ITreeNode<TNode, TValue>
        where TNode : ITreeNode<TNode, TValue>
    {
        #region Properties

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <value>The children.</value>
        IEnumerable<TNode> Children { get; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        TNode Parent { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        TValue Value { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds the specified node.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <returns>
        /// The add.
        /// </returns>
        bool Add(TNode node);

        /// <summary>
        /// Removes the specified node.
        /// </summary>
        /// <param name="node">
        /// The node.
        /// </param>
        /// <returns>
        /// The remove.
        /// </returns>
        bool Remove(TNode node);

        #endregion
    }
}