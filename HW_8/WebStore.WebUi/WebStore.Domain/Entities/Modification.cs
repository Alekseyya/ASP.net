using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Modification
    {
        public int Id { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public string Name { get; set; }
        public int TypeSort { get; set; }
    }

    public class ModificationConfiguration : EntityTypeConfiguration<Modification>
    {
        public ModificationConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)
                .IsRequired();


            Property(x => x.TypeSort)
                .IsRequired();

            HasRequired(x => x.Model);//[ForeignKey]            

        }
    }
}
