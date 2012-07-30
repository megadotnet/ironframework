// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   Just for test entlib validation application block
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace UnitTest
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Just for test entlib validation application block
    /// </summary>
    public class Customer
    {
        #region Properties

        /// <summary>
        /// Gets or sets CustomerId.
        /// </summary>
        [Range(0, 50, ErrorMessage = "CustomerId value must be between 0 and 500.")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets CustomerName.
        /// </summary>
        [StringLength(20, ErrorMessage = "CustomerName ID must be 20 characters.")]
        [Required(ErrorMessage = "CustomerName is required.")]
        public string CustomerName { get; set; }

        #endregion
    }
}