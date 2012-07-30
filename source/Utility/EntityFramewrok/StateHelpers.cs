// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StateHelpers.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The state for entity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.EntityFramewrok
{
    using System.Data;

    /// <summary>
    /// The state.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// The unchanged.
        /// </summary>
        Unchanged, 

        /// <summary>
        /// The added.
        /// </summary>
        Added, 

        /// <summary>
        /// The modified.
        /// </summary>
        Modified, 

        /// <summary>
        /// The deleted.
        /// </summary>
        Deleted
    }

    /// <summary>
    /// The state helpers.
    /// </summary>
    public static class StateHelpers
    {
        #region Public Methods

        /// <summary>
        /// The get equivalent entity state.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// Entity State
        /// </returns>
        /// <remarks>
        /// this handy method comes from Rowan Miller on the EF team
        /// </remarks>
        public static EntityState GetEquivalentEntityState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Modified:
                    return EntityState.Modified;
                case State.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        #endregion
    }
}