// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Megdotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   IUnitOfWork
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataAccessObject
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;

    /// <summary>
    /// IUnitOfWork interface
    /// </summary>
    public interface IUnitOfWork
    {
        #region Public Methods

        /// <summary>
        /// The save.
        /// </summary>
        void Save();

        #endregion
    }

    /// <summary>
    /// IObjectContext interface
    /// </summary>
    public interface IObjectContext : IDisposable
    {
	    /// <summary>
        /// Gets or sets a value indicating whether [lazy loading enabled].
        /// </summary>
        /// <value><c>true</c> if [lazy loading enabled]; otherwise, <c>false</c>.</value>
        bool LazyLoadingEnabled {get;set; }

        /// <summary>
        /// Gets or sets a value indicating whether [proxy creation enabled].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [proxy creation enabled]; otherwise, <c>false</c>.
        /// </value>
        bool ProxyCreationEnabled { get; set; }

        #region Public Methods

        /// <summary>
        /// The change object state.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="entityState">
        /// The entity state.
        /// </param>
        void ChangeObjectState(object entity, EntityState entityState);

        /// <summary>
        /// The create object set.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// IObjectSet generic T
        /// </returns>
        IObjectSet<T> CreateObjectSet<T>() where T : class;

		    /// <summary>
        /// Executes the function or sproc
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>affect rows</returns>
        int ExecuteFunction(string functionName, params ObjectParameter[] parameters);
        
        /// <summary>
        /// ExecuteStoreCommand
        /// </summary>
        /// <param name="commandText">sqltest</param>
        /// <param name="parameters">parameters</param>
        /// <returns>affect rows</returns>
        int ExecuteStoreCommand(string commandText, params object[] parameters);

        /// <summary>
        /// The save changes.
        /// </summary>
        void SaveChanges();

        #endregion
    }

    /// <summary>
    /// ObjectContextAdapter
    /// </summary>
    public class ObjectContextAdapter : IObjectContext
    {
        #region Constants and Fields

        /// <summary>
        /// The object context.
        /// </summary>
        private readonly ObjectContext _context;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectContextAdapter"/> class.
        /// </summary>
        /// <param name="dbcontext">
        /// The dbcontext.
        /// </param>
        public ObjectContextAdapter(DbContext dbcontext)
        {
            this._context = (dbcontext as IObjectContextAdapter).ObjectContext;
        }

        #endregion

        #region Implemented Interfaces

        #region IDisposable

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this._context.Dispose();
        }

        #endregion

        #region IObjectContext

		    /// <summary>
        /// Gets or sets a value indicating whether [lazy loading enabled].
        /// </summary>
        /// <value><c>true</c> if [lazy loading enabled]; otherwise, <c>false</c>.</value>
        public bool LazyLoadingEnabled
        {
            get
            {
                return this._context.ContextOptions.LazyLoadingEnabled;
            }
            set
            {
                this._context.ContextOptions.LazyLoadingEnabled = value;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [proxy creation enabled].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [proxy creation enabled]; otherwise, <c>false</c>.
        /// </value>
        public bool ProxyCreationEnabled
        {
            get
            {
                return this._context.ContextOptions.ProxyCreationEnabled;
            }
            set
            {
                this._context.ContextOptions.ProxyCreationEnabled = value;
            }
        }

        /// <summary>
        /// Changes the state of the object.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="entityState">
        /// State of the entity.
        /// </param>
        public void ChangeObjectState(object entity, EntityState entityState)
        {
            this._context.ObjectStateManager.ChangeObjectState(entity, entityState);
        }

        /// <summary>
        /// Creates the object set.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// </returns>
        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return this._context.CreateObjectSet<T>();
        }

		    /// <summary>
        /// Executes the function.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>affect rows</returns>
        public int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            return this._context.ExecuteFunction(functionName, parameters);
        }
        
        /// <summary>
        /// ExecuteStoreCommand
        /// </summary>
        /// <param name="commandText">sqltest</param>
        /// <param name="parameters">parameters</param>
        /// <returns>affect rows</returns>
        public int ExecuteStoreCommand(string commandText, params object[] parameters)
        {
            return this._context.ExecuteStoreCommand(commandText, parameters);
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        #endregion

        #endregion
    }
}