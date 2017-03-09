using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Northwind.Entities
{
    /// <summary>
    /// The order.
    /// </summary>
    [Table("Orders")]
    public partial class Order
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        [StringLength(5, MinimumLength = 5)]
        public string CustomerID { get; set; }

        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        public int? EmployeeID { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the required date.
        /// </summary>
        public DateTime? RequiredDate { get; set; }

        /// <summary>
        /// Gets or sets the shipped date.
        /// </summary>
        public DateTime? ShippedDate { get; set; }

        /// <summary>
        /// Gets or sets the shipper id.
        /// </summary>
        [Column("ShipVia")]
        public int? ShipperID { get; set; }

        /// <summary>
        /// Gets or sets the freight.
        /// </summary>
        public decimal? Freight { get; set; }

        /// <summary>
        /// Gets or sets the ship name.
        /// </summary>
        [StringLength(40)]
        public string ShipName { get; set; }

        /// <summary>
        /// Gets or sets the ship address.
        /// </summary>
        [StringLength(60)]
        public string ShipAddress { get; set; }

        /// <summary>
        /// Gets or sets the ship city.
        /// </summary>
        [StringLength(15)]
        public string ShipCity { get; set; }

        /// <summary>
        /// Gets or sets the ship region.
        /// </summary>
        [StringLength(15)]
        public string ShipRegion { get; set; }

        /// <summary>
        /// Gets or sets the ship postal code.
        /// </summary>
        [StringLength(10)]
        public string ShipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the ship country.
        /// </summary>
        [StringLength(15)]
        public string ShipCountry { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the employee.
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Gets or sets the shipper.
        /// </summary>
        public virtual Shipper Shipper { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
