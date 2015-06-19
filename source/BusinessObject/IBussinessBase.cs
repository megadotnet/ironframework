

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Megadonet">
//   Copyright (c) 2010-2014 Peter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   a interface of business object repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
	using System.Threading.Tasks;

    using IronFramework.Utility.UI;
    using DataTransferObject.Model;

    /// <summary>
    /// a interface of data acccess repository.
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    public interface IBusniessLogicObject<T>
    {
        #region Public Methods

        /// <summary>
        /// The find enties.
        /// </summary>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="PagedList"/>.
        /// </returns>
        PagedList<T> FindEnties(int? pageIndex, int pageSize);

		/// <summary>
        /// The find enties.
        /// </summary>
        /// <param name="pageIndex">
        /// The page index.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <returns>
        /// The <see cref="PagedList"/>.
        /// </returns>
		Task<PagedList<T>> FindEntiesAsync(int? pageIndex, int pageSize);

        /// <summary>
        /// Finds the enties.
        /// </summary>
        /// <param name="tDTo">The Pagedlist of dto.</param>
        /// <returns></returns>
        EasyuiDatagridData<T> FindEnties(PagedList<T> tDTo);

        /// <summary>
        /// Finds the enties with search
        /// </summary>
        /// <param name="tDTo">The Pagedlist of dto</param>
        /// <returns></returns>
        EasyuiDatagridData<T> FindAll(PagedList<T> tDTo);

        /// <summary>
        /// The create entiy.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CreateEntiy(T t);

        /// <summary>
        /// Creates the entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        Task<int> CreateEntiyAsync(T tDTo);

        /// <summary>
        /// The get entiy.
        /// </summary>
        /// <param name="_id">
        /// The _id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
         T GetEntiyByPK(T _id);

        /// <summary>
        /// The del entiy.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool DeleteEntiy(T t);

        /// <summary>
        /// The del entiy.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool DeleteWithAttachEntiy(T t);


        /// <summary>
        /// Deletes the with attach entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        Task<int> DeleteWithAttachEntiyAsync(T tDTo);


        /// <summary>
        /// The del entiy.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>
        /// The <see cref="bool" />.
        /// </returns>
        bool DeleteWithAttachEntiy(T[] entities);

        /// <summary>
        /// The update entiy.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool UpdateEntiy(T t);

        /// <summary>
        /// The update entiy.
        /// </summary>
        /// <param name="t">
        /// The t.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
         bool UpdateWithAttachEntiy(T t);


        /// <summary>
        /// Updates the entiy with get.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</return>
        bool UpdateEntiyWithGet(T entity);

        /// <summary>
        /// Updates the with attach entiy asynchronous.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        Task<int> UpdateWithAttachEntiyAsync(T tDTo);

        /// <summary>
        /// Updates the entiy with get asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<int> UpdateEntiyWithGetAsync(T entity);

        #endregion
    }
}

