using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    /// <summary>
    /// DeleteObject用于传删除对象Id
    /// </summary>
    [DataContract]
    public class DeleteObject
    {
        /// <summary>
        /// Gets or sets the ids.
        /// </summary>
        /// <value>
        /// The ids.
        /// </value>
        [DataMember]
        public int[] Ids { get; set; }


    }
}
