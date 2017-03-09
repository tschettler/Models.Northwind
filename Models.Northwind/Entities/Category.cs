using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Xml.Serialization;

namespace Models.Northwind.Entities
{
    /// <summary>
    /// The category.
    /// </summary>
    [Table("Categories")]
    public partial class Category
    {
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the picture.
        /// </summary>
        public byte[] Picture { get; set; }

        /// <summary>
        /// Gets the picture display.
        /// </summary>
        [NotMapped]
        public byte[] PictureDisplay
        {
            get
            {
                return this.Picture.Skip(78).ToArray();
            }
        }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }
    }
}
