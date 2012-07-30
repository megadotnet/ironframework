// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountModels.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The change password model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MvcApp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    /// <summary>
    /// The change password model.
    /// </summary>
    public class ChangePasswordModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets ConfirmPassword.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets NewPassword.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        /// Gets or sets OldPassword.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        #endregion
    }

    /// <summary>
    /// The log on model.
    /// </summary>
    public class LogOnModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether RememberMe.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Gets or sets UserName.
        /// </summary>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }

    /// <summary>
    /// The register model.
    /// </summary>
    public class RegisterModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets ConfirmPassword.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets Password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets UserName.
        /// </summary>
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        #endregion
    }
}