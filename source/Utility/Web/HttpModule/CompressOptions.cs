// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressOptions.cs" company="Megadotnet">
//    Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   CompressOptions
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace IronFramework.Utility.Web.HttpModule
{
    /// <summary>
    /// CompressOptions
    /// </summary>
    /// <seealso cref="http://en.wikipedia.org/wiki/Zcat#gunzip_and_zcat"/>
    /// <seealso cref="http://en.wikipedia.org/wiki/DEFLATE"/>
    public enum CompressOptions
    {
        /// <summary>
        /// The g zip.
        /// </summary>
        GZip, 

        /// <summary>
        /// The deflate.
        /// </summary>
        Deflate, 

        /// <summary>
        /// The none.
        /// </summary>
        None
    }
}