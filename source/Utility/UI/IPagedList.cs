// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedList.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The i paged list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.UI
{
    /// <summary>
    /// The i paged list.
    /// </summary>
    public interface IPagedList
    {
        #region Properties

        /// <summary>
        /// Gets a value indicating whether IsNextPage.
        /// </summary>
        bool IsNextPage { get; }

        /// <summary>
        /// Gets a value indicating whether IsPreviousPage.
        /// </summary>
        bool IsPreviousPage { get; }

        /// <summary>
        /// Gets or sets PageIndex.
        /// </summary>
        int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets PageSize.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        /// Gets or sets TotalCount.
        /// </summary>
        int TotalCount { get; set; }

        #endregion
    }
}