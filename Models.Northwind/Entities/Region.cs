using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Northwind.Entities
{
    /// <summary>
    /// The region.
    /// </summary>
    [Table("Region")]
    public partial class Region
    {
        /// <summary>
        /// Gets or sets the region id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }

        /// <summary>
        /// Gets or sets the region description.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string RegionDescription { get; set; }

        /// <summary>
        /// Gets or sets the territories.
        /// </summary>
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
