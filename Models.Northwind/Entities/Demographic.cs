using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Northwind.Entities
{
    /// <summary>
    /// The demographic.
    /// </summary>
    [Table("CustomerDemographics")]
    public partial class Demographic
    {
        /// <summary>
        /// Gets or sets the customer demographic id.
        /// </summary>
        [Required]
        [StringLength(10, MinimumLength = 10)]
        [Column("CustomerTypeID")]
        public string DemographicID { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [Column("CustomerDesc")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the customer demographics.
        /// </summary>
        public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; }
    }
}
