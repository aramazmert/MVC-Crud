using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using web_27AralikMVCCrud.Data.Entities;

namespace web_27AralikMVCCrud.Data.Mappings
{
    //DB özelliklerini girdiğimiz sınıflar.
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        //Fluent API ile POCO sınıflarının DB tarafında konfigurasyonlarının yapılması işlemi.
        public ProductMapping()
        {
            ToTable("Ürün Tablosu");

            Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(20)
                .HasColumnName("Ürün Adı")
                .HasColumnOrder(1);

            Property(x => x.Price)
                .HasPrecision(16, 2)
                .IsRequired()
                .HasColumnName("Fiyat")
                .HasColumnOrder(2);

            Property(x => x.Stock)
                .IsOptional()
                .HasColumnName("Stok Miktarı")
                .HasColumnOrder(3)
                .HasColumnType("int");

            HasKey<int>(x => x.Id); //PK alanı tanımlaması.

            //HasRequired(x => x.Category)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey<int>(x => x.CategoryId);
        }
    }
}