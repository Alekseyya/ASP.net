using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Variant
    {
        public int Id { get; set; }

        public int ModificationId { get; set; }
        public Modification Modification { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string New { get; set; }
    }

    public class VariantConfiguration : EntityTypeConfiguration<Variant>
    {
        public VariantConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.ItemId)                
                .IsRequired();

            Property(x => x.New)
                .IsRequired();

            HasRequired(x => x.Modification);//[ForeignKey]
        }
    }
}
