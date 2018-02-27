// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="Megadotnet">
//  Copyright (c) 2010-2018 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//  EnumerableExtensions.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Common.Data.LINQ
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// The enumerable extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// The full outer join.
        /// </summary>
        /// <param name="leftItems">
        /// The left items.
        /// </param>
        /// <param name="leftIdSelector">
        /// The left id selector.
        /// </param>
        /// <param name="rightItems">
        /// The right items.
        /// </param>
        /// <param name="rightIdSelector">
        /// The right id selector.
        /// </param>
        /// <param name="projection">
        /// The projection.
        /// </param>
        /// <typeparam name="TLeft">the TLeft</typeparam>
        /// <typeparam name="TRight">the TRight</typeparam>
        /// <typeparam name="TKey">the TKey</typeparam>
        /// <typeparam name="TResult">the TResult</typeparam>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public static IQueryable<TResult> FullOuterJoin<TLeft, TRight, TKey, TResult>(
            this IQueryable<TLeft> leftItems,
            Expression<Func<TLeft, TKey>> leftIdSelector,
            IQueryable<TRight> rightItems,
            Expression<Func<TRight, TKey>> rightIdSelector,
            Expression<Func<LinqJoinObject<TLeft, TRight>, TResult>> projection)
        {
            var leftOuterJoin =
                leftItems.GroupJoin(rightItems, leftIdSelector, rightIdSelector, (left, temp) => new { left, temp })
                    .SelectMany(
                        @t => @t.temp.DefaultIfEmpty(),
                        (@t, right) => new LinqJoinObject<TLeft, TRight> { Left = @t.left, Right = right });

            var rightOuterJoin =
                rightItems.GroupJoin(leftItems, rightIdSelector, leftIdSelector, (right, temp) => new { right, temp })
                    .SelectMany(
                        @t => @t.temp.DefaultIfEmpty(),
                        (@t, left) => new LinqJoinObject<TLeft, TRight> { Left = left, Right = @t.right });

            return leftOuterJoin.Union(rightOuterJoin).Select(projection);
        }
    }
}