// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinqJoinObject.cs" company="Megadotnet Co.,LTD">
//   Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The linq join object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.Common.Data.LINQ
{
    /// <summary>
    /// the LinqJoinObject
    /// </summary>
    /// <typeparam name="TLeft">the TLeft</typeparam>
    /// <typeparam name="TRight">the TRight</typeparam>
    public class LinqJoinObject<TLeft, TRight>
    {
        /// <summary>
        /// Gets or sets the left.
        /// </summary>
        public TLeft Left { get; set; }

        /// <summary>
        /// Gets or sets the right.
        /// </summary>
        public TRight Right { get; set; }
    }
}
