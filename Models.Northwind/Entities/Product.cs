using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Northwind.Entities
{
    /// <summary>
    /// The product.
    /// </summary>
    [Table("Products")]
    public partial class Product
    {
        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the supplier id.
        /// </summary>
        public int? SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        public int? CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the quantity per unit.
        /// </summary>
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public decimal? UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the units in stock.
        /// </summary>
        public short? UnitsInStock { get; set; }

        /// <summary>
        /// Gets or sets the units on order.
        /// </summary>
        public short? UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets or sets the reorder level.
        /// </summary>
        public short? ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether discontinued.
        /// </summary>
        public bool Discontinued { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        public virtual Supplier Supplier { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
