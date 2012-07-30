// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileConfigurationSource.cs" company="Megadotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   Fix FileConfigurationSource not working on web projects
//   http://entlib.codeplex.com/workitem/26760
//   http://stackoverflow.com/questions/3150878/enterprise-library-5-how-to-configure-fileconfigurationsource-relative-to-asp-ne
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Utility.EntLib.Configuration
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

    /// <summary>
    /// Fix FileConfigurationSource not working on web projects 
    /// http://entlib.codeplex.com/workitem/26760
    /// http://stackoverflow.com/questions/3150878/enterprise-library-5-how-to-configure-fileconfigurationsource-relative-to-asp-ne
    /// </summary>
    /// <remarks>
    /// when replace orginal class in config files,you can not use EntLib 5 console app edit config files unless restore default class
    /// </remarks>
    [ConfigurationElementType(typeof(FileConfigurationSourceElement))]
    public class FileConfigurationSource :
        Microsoft.Practices.EnterpriseLibrary.Common.Configuration.FileConfigurationSource
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfigurationSource"/> class.
        /// </summary>
        /// <param name="configurationFilepath">
        /// The configuration filepath.
        /// </param>
        public FileConfigurationSource(string configurationFilepath)
            : base(configurationFilepath)
        {
        }

        #endregion
    }
}