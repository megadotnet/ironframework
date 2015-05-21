using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DataTransferObject
{
    /// <summary>
    /// UIPaging
    /// </summary>
    [DataContract]
    public class UIPaging
    {
        private int _pageSize = 10;
        private int? _pageIndex;

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        [DataMember]
        public int pageSize
        {
            get
            {
                if (this._pageSize <= 0)
                {
                    return 10;
                }
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the page.
        /// </summary>
        /// <value>
        /// The index of the page.
        /// </value>
        [DataMember]
        public int? pageIndex
        {
            get
            {
                if (this._pageIndex.HasValue && this._pageIndex.Value > 0)
                    return this._pageIndex.Value;
                else
                    return 1;
            }
            set
            {
                this._pageIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the Total count.
        /// </summary>
        /// <value>
        /// The Total count.
        /// </value>
        [DataMember]
        public int TotalCount { get; set; }
    }




}
