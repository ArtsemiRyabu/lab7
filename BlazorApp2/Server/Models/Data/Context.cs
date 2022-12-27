using BlazorApp2.Server.Models;
using BlazorApp2.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BlazorApp2.Server.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentsList> ComponentsLists { get; set; }
        public DbSet<ServicesList> ServicesLists { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TypeComponent> TypeComponents { get; set; }
        public DbSet<ComputerOrder> ComputerOrders { get; set; }
        public DbSet<ComputerService> ComputerServices { get; set; }
    }
}
