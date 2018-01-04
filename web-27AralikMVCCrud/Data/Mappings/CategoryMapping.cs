using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using web_27AralikMVCCrud.Data.Entities;

namespace web_27AralikMVCCrud.Data.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            ToTable("Kategori Tablosu");
            HasKey<int>(x => x.Id); //PK

            Property(x => x.Id)
                .HasColumnName("Id");

            Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnName("Kategori Adı")
                .IsRequired()
                .IsUnicode()
                .HasColumnOrder(1);

            Property(x => x.Description)
                .HasMaxLength(200)
                .HasColumnName("Açıklama")
                .IsOptional()
                .IsUnicode()
                .HasColumnType("nvarchar")
                .HasColumnOrder(2);
        }
    }
}