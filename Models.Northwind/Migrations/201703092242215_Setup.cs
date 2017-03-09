namespace Models.Northwind.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Setup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 15),
                        Description = c.String(),
                        Picture = c.Binary(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 40),
                        SupplierID = c.Int(),
                        CategoryID = c.Int(),
                        QuantityPerUnit = c.String(maxLength: 20),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        UnitsInStock = c.Short(),
                        UnitsOnOrder = c.Short(),
                        ReorderLevel = c.Short(),
                        Discontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID)
                .Index(t => t.SupplierID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Order Details",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Short(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductID })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.String(maxLength: 5),
                        EmployeeID = c.Int(),
                        OrderDate = c.DateTime(),
                        RequiredDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        ShipVia = c.Int(),
                        Freight = c.Decimal(precision: 18, scale: 2),
                        ShipName = c.String(maxLength: 40),
                        ShipAddress = c.String(maxLength: 60),
                        ShipCity = c.String(maxLength: 15),
                        ShipRegion = c.String(maxLength: 15),
                        ShipPostalCode = c.String(maxLength: 10),
                        ShipCountry = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID)
                .ForeignKey("dbo.Shippers", t => t.ShipVia)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeID)
                .Index(t => t.ShipVia);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 5),
                        CompanyName = c.String(maxLength: 40),
                        ContactName = c.String(maxLength: 30),
                        ContactTitle = c.String(maxLength: 30),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 15),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.CustomerCustomerDemo",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 5),
                        CustomerTypeId = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.CustomerTypeId })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.CustomerDemographics", t => t.CustomerTypeId, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.CustomerTypeId);
            
            CreateTable(
                "dbo.CustomerDemographics",
                c => new
                    {
                        CustomerTypeID = c.String(nullable: false, maxLength: 10),
                        CustomerDesc = c.String(),
                    })
                .PrimaryKey(t => t.CustomerTypeID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        Title = c.String(maxLength: 30),
                        TitleOfCourtesy = c.String(maxLength: 25),
                        BirthDate = c.DateTime(),
                        HireDate = c.DateTime(),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 15),
                        HomePhone = c.String(maxLength: 24),
                        Extension = c.String(maxLength: 4),
                        Photo = c.Binary(),
                        Notes = c.String(),
                        ReportsTo = c.Int(),
                        PhotoPath = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Employees", t => t.ReportsTo)
                .Index(t => t.ReportsTo);
            
            CreateTable(
                "dbo.EmployeeTerritories",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        TerritoryID = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => new { t.EmployeeID, t.TerritoryID })
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Territories", t => t.TerritoryID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.TerritoryID);
            
            CreateTable(
                "dbo.Territories",
                c => new
                    {
                        TerritoryID = c.String(nullable: false, maxLength: 20),
                        TerritoryDescription = c.String(nullable: false, maxLength: 50),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TerritoryID)
                .ForeignKey("dbo.Region", t => t.RegionID, cascadeDelete: true)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false),
                        RegionDescription = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RegionID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ShipperID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.ShipperID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        ContactName = c.String(maxLength: 30),
                        ContactTitle = c.String(maxLength: 30),
                        Address = c.String(maxLength: 60),
                        City = c.String(maxLength: 15),
                        Region = c.String(maxLength: 15),
                        PostalCode = c.String(maxLength: 10),
                        Country = c.String(maxLength: 15),
                        Phone = c.String(maxLength: 24),
                        Fax = c.String(maxLength: 24),
                        HomePage = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Order Details", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Orders", "ShipVia", "dbo.Shippers");
            DropForeignKey("dbo.Order Details", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Employees", "ReportsTo", "dbo.Employees");
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Territories", "RegionID", "dbo.Region");
            DropForeignKey("dbo.EmployeeTerritories", "TerritoryID", "dbo.Territories");
            DropForeignKey("dbo.EmployeeTerritories", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerTypeId", "dbo.CustomerDemographics");
            DropForeignKey("dbo.CustomerCustomerDemo", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Territories", new[] { "RegionID" });
            DropIndex("dbo.EmployeeTerritories", new[] { "TerritoryID" });
            DropIndex("dbo.EmployeeTerritories", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "ReportsTo" });
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerTypeId" });
            DropIndex("dbo.CustomerCustomerDemo", new[] { "CustomerID" });
            DropIndex("dbo.Orders", new[] { "ShipVia" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Order Details", new[] { "ProductID" });
            DropIndex("dbo.Order Details", new[] { "OrderID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shippers");
            DropTable("dbo.Region");
            DropTable("dbo.Territories");
            DropTable("dbo.EmployeeTerritories");
            DropTable("dbo.Employees");
            DropTable("dbo.CustomerDemographics");
            DropTable("dbo.CustomerCustomerDemo");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Order Details");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
