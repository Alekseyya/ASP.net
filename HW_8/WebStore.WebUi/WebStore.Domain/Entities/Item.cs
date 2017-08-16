using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string BriefDescriptions { get; set; }
        public string Descriptions { get; set; }
        public decimal Price { get; set; }
        public bool Show { get; set; }
        public bool Popular { get; set; }
        public string Brand { get; set; }
        public int Status { get; set; }

    }

    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.BriefDescriptions)
                .IsRequired();

            Property(x => x.Descriptions)
                .IsRequired();

            Property(x => x.Descriptions)
                .IsRequired();

            Property(x => x.Price)
                .HasPrecision(10, 0)
                .IsRequired();

            Property(x => x.Brand)
               .IsRequired();

            Property(x => x.Status)
               .IsRequired();

        }
    }
}
