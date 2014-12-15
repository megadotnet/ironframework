using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntiies
{
    /// <summary>
    /// Address
    /// </summary>
    public partial class Address
    {
        /// <summary>
        /// Gets or sets the edm modified date.
        /// </summary>
        /// <value>
        /// The edm modified date.
        /// </value>
        [NotMapped]
        public DateTimeOffset? EdmModifiedDate
        {
            // Assume the CreateOn property stores UTC time.
            get
            {
                return ModifiedDate.HasValue ? new DateTimeOffset(ModifiedDate.Value, TimeSpan.FromHours(0)) : (DateTimeOffset?)null;
            }
            set
            {
                ModifiedDate = value.HasValue ? value.Value.UtcDateTime : (DateTime?)null;
            }
        }
    }
}
