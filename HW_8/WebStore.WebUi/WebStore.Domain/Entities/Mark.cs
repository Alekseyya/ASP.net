using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
   public class Marka
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Main { get; set; }
    }
    public class MarkaConfiguration : EntityTypeConfiguration<Marka>
    {
        public MarkaConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
