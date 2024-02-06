using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Product.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Data.Config
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x=>x.Name).HasMaxLength(50);
            builder.Property(x => x.Description ).HasMaxLength(50);
            //Asp.Net Core 8 Web API :https://www.youtube.com/watch?v=UqegTYn2aKE&list=PLazvcyckcBwitbcbYveMdXlw8mqoBDbTT&index=1

            //Seeding 
            builder.HasData(
             new Category { Id = 1, Name = "category 1", Description = "description 1" },
             new Category { Id = 2, Name = "category 2", Description = "description 2" },
             new Category { Id = 3, Name = "category 3", Description = "description 3" }
            );
        }
    }
}
