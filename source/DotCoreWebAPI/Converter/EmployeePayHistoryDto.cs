using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DotCoreWebAPI.Converter
{
    [DataContract()]
    public partial class EmployeePayHistoryDto
    {
        [Key()]
        [Required]
        [DataMember]
        public int EmployeeID { get; set; }
        [Key()]
        [Required]
        [DataMember]
        public System.DateTime RateChangeDate { get; set; }

        [Required]
        [DataMember]
        public decimal Rate { get; set; }

        [Required]
        [DataMember]
        public byte PayFrequency { get; set; }

        [Required]
        [DataMember]
        public System.DateTime ModifiedDate { get; set; }

        //[DataMember] 
        //[JsonProperty("Employees")]
        //public virtual Employee Employees { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
