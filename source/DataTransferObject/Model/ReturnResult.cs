using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    /// <summary>
    /// ReturnResult
    /// </summary>
    public class ReturnResult
    {
        /// <summary>
        /// 结果代码
        /// </summary>
        [DataMember]
        public string ResultCode { get; set; }

        /// <summary>
        /// 信息
        /// </summary>
        [DataMember]
        public string Msg { get; set; }
        
    }
}
