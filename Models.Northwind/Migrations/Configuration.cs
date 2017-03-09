using Models.Northwind.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Text;

namespace Models.Northwind.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<NorthwindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NorthwindContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
            
            // This method will be called after migrating to the latest version.
            var entityTypes = new List<Type>
            {
                typeof(Category),
                typeof(Customer),
                typeof(CustomerDemographic),
                typeof(Demographic),
                typeof(Employee),
                typeof(EmployeeTerritory),
                typeof(Order),
                typeof(OrderDetail),
                typeof(Product),
                typeof(Region),
                typeof(Shipper),
                typeof(Supplier),
                typeof(Territory)
            };

            var ns = typeof(Configuration).Assembly.FullName.Split(',')[0];
            var dataNS = $"{ns}.Data";
            foreach (var type in entityTypes)
            {
                var dataFile = $"{dataNS}.{type.Name.ToLower()}.json";
                var json = GetResource(dataFile);

                var listType = typeof(IEnumerable<>).MakeGenericType(type);

                var entities = JsonConvert.DeserializeObject(json, listType);

                var dbset = context.Set(type);

                dbset.AddRange(entities as IEnumerable);
            }

            context.SaveChanges();
        }

        private string GetResource(string resourceName)
        {
            var result = string.Empty;
            var assembly = typeof(Configuration).Assembly;

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream, Encoding.GetEncoding("iso-8859-1")))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
