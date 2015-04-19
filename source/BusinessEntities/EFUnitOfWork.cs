// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EFUnitOfWork.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   EFUnitOfWork
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System;
	using System.Data.Entity;

    /// <summary>
    /// EFUnitOfWork
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        #region Constants and Fields

        /// <summary>
        /// The _object context.
        /// </summary>
        private readonly IObjectContext _objectContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFUnitOfWork"/> class.
        /// </summary>
        /// <param name="objectContext">
        /// The object context.
        /// </param>
        public EFUnitOfWork(IObjectContext objectContext)
        {
            this._objectContext = objectContext;
        }

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._objectContext != null)
            {
                this._objectContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        #endregion

        #region IUnitOfWork

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            this._objectContext.SaveChanges();
        }

        #endregion

        #endregion
    }
}
