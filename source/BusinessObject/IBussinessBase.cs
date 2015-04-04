

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
        /// Finds the enties.
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        EasyuiDatagridData<T> FindEnties(T tDTo);

        /// <summary>
        /// Finds the enties with search
        /// </summary>
        /// <param name="tDTo">The t d to.</param>
        /// <returns></returns>
        EasyuiDatagridData<T> FindAll(T tDTo);

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
        /// The get entiy.
        /// </summary>
        /// <param name="_id">
        /// The _id.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetEntiyByPK(int _id);

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
        #endregion
    }
}

