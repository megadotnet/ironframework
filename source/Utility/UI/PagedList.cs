// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedList.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The paged list.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.UI
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// The paged list.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
     [Serializable]
     [CollectionDataContract]
    public class PagedList<T> : List<T>, IPagedList
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        public PagedList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        public PagedList(IQueryable<T> source, int index, int pageSize, int count)
            : this(source, index, pageSize)
        {
            this.TotalCount = count;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public PagedList(List<T> source, int index, int pageSize)
        {
            this.PageSize = pageSize;
            this.PageIndex = index;
            this.AddRange(source);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether IsNextPage.
        /// </summary>
        public bool IsNextPage
        {
            get
            {
                return (this.PageIndex * this.PageSize) <= this.TotalCount;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsPreviousPage.
        /// </summary>
        public bool IsPreviousPage
        {
            get
            {
                return this.PageIndex > 0;
            }
        }

        /// <summary>
        /// Gets or sets PageIndex.
        /// </summary>
        [DataMember]
        public int PageIndex { get; set; }

        /// <summary>
        /// Gets or sets PageSize.
        /// </summary>
        [DataMember]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets TotalCount.
        /// </summary>
        [DataMember]
        public int TotalCount { get; set; }

        #endregion
    }
}