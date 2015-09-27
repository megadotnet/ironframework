// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEntity.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   IEntity
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Common.Data.EntityFramewrok
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The i entity.
    /// </summary>
    public interface IEntity
    {
        #region Properties

        /// <summary>
        /// Gets or sets Entity State.
        /// </summary>
        [DataMember]
        State State { get; set; }

        #endregion
    }
}