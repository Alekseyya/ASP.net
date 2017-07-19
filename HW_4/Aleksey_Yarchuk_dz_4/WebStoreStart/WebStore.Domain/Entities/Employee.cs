using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Partonymic { get; set; }

        public int Age { get; set; }
        
        public DateTime DateofBirth { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
    }

    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            HasKey(x => x.Id); //[Key]

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity) //DatabaseGenerated(DatabaseGeneratedOption.Identity) 
                .IsRequired(); //[Required]

            Property(x => x.FirstName)
                .HasMaxLength(250) //[MaxLength]
                .IsRequired();

            Property(x => x.FirstName)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Partonymic)
                .HasMaxLength(250)
                .IsRequired();

            Property(x => x.Age)
                .IsRequired();

            Ignore(x => x.DateofBirth);

            HasRequired(x => x.Position);//[ForeignKey]
        }
    }
}
