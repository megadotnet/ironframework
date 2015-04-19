// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RepositoryIQueryableExtensions.cs" company="Megdotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The repository i queryable extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Linq;

    using IronFramework.Utility.UI;

    /// <summary>
    /// The repository i queryable extensions.
    /// </summary>
    public static class RepositoryIQueryableExtensions
    {
        #region Public Methods

        /// <summary>
        /// The include.
        /// </summary>
        /// <param name="source">
        /// The source.
        /// </param>
        /// <param name="path">
        /// The path.
        /// </param>
        /// <typeparam name="T">entities
        /// </typeparam>
        /// <returns>
        ///  as queryable entities
        /// </returns>
        public static IQueryable<T> Include<T>(this IQueryable<T> source, string path)
        {
            var objectQuery = source as ObjectQuery<T>;
            if (objectQuery != null)
            {
                return objectQuery.Include(path);
            }

            return source;
        }

        /// <summary>
        /// The to paged list.
        /// </summary>
        /// <param name="allItems">
        /// The all items.
        /// </param>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <typeparam name="T">entities
        /// </typeparam>
        /// <returns>
        /// Paged list of entities
        /// </returns>
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int? pageIndex, int pageSize)
        {
            int truePageIndex = pageIndex ?? 0;
            int itemIndex = (truePageIndex - 1) * pageSize;
            IQueryable<T> pageOfItems = allItems.Skip(itemIndex).Take(pageSize);
            return new PagedList<T>(pageOfItems, truePageIndex, pageSize, allItems.Count());
        }

        #endregion
    }
}