// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileConfigurationSourceElement.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   FileConfigurationSourceElement
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.EntLib.Configuration
{
    using System;
    using System.IO;

    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    /// <summary>
    /// FileConfigurationSourceElement
    /// </summary>
    public class FileConfigurationSourceElement :
        Microsoft.Practices.EnterpriseLibrary.Common.Configuration.FileConfigurationSourceElement
    {
        #region Public Methods

        /// <summary>
        /// Returns a new <see cref="T:Microsoft.Practices.EnterpriseLibrary.Common.Configuration.FileConfigurationSource"/> configured with the receiver's settings.
        /// </summary>
        /// <returns>
        /// A new configuration source.
        /// </returns>
        public override IConfigurationSource CreateSource()
        {
            string configurationFilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, this.FilePath);
            return new FileConfigurationSource(configurationFilepath);
        }

        #endregion
    }
}