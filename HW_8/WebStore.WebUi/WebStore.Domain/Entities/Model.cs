﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Model
    {
        public int Id { get; set; }

        public int MarkaId { get; set; }
        public Marka Marka { get; set; }

        public string Name { get; set; }
        public string Years_Body { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string TecDoc { get; set; }
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }

        public bool Main { get; set; }
        public bool Market { get; set; }
        public bool Type { get; set; }
    }

    public class ModelConfiguration : EntityTypeConfiguration<Model>
    {
        public ModelConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.Name)                
                .IsRequired();

            Property(x => x.Years_Body)
                .IsRequired();

            Property(x => x.Start)
                .IsRequired();

            Property(x => x.End)
               .IsRequired();

            Property(x => x.TecDoc)
               .IsRequired();

            HasRequired(x => x.Marka);//[ForeignKey]
            HasRequired(x => x.Photo);
        }
    }
}
