using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Core.Entities;

namespace Product.Infrastructure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(128);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

            //Seeding 
            builder.HasData(
                new Products {Id=1, Name= "Product 1", Description="Description 1", Price=100, Categoryid=1 },
                new Products { Id = 2, Name = "Product 2", Description = "Description 2", Price = 300, Categoryid = 1 },
                new Products { Id = 3, Name = "Product 3", Description = "Description 3", Price = 500, Categoryid = 3 },
                new Products { Id = 4, Name = "Product 4", Description = "Description 4", Price = 900, Categoryid = 2 }
                );
        }
    }
}
