using System.Collections.Generic;
using TestApp.Models;

namespace TestApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestApp.Models.ApplicationDbContext context)
        {
            var emp = new List<Employee>
            {
                new Employee() {Name="Daniel", ContactNo = "Ikeja", Age = 36, Email = "kahfea@gmail.com"},
                new Employee() {Name="Jane", ContactNo = "Ogba", Age = 36, Email = "kah@gmail.com"},
                new Employee() {Name="David", ContactNo = "Ojodu", Age = 36, Email = "kahfea@yahoo.com"}
            };
            emp.ForEach(e => context.Employees.AddOrUpdate(p => p.Id, e));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
