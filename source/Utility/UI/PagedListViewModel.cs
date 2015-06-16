using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronFramework.Utility.UI
{
    /// <summary>
    /// PagedListViewModel for UI
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <see cref=""/>
    /// <seealso cref="http://json2csharp.com/"/>
    public class PagedListViewModel<T> where T : class
    {
        public bool IsNextPage { get; set; }
        public bool IsPreviousPage { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        public int Capacity { get; set; }
        public int Count { get; set; }
    }
}
