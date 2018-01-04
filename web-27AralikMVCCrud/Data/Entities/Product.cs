using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_27AralikMVCCrud.Data.Entities
{
    //POCO classlarının veya POCO class propertylerinin üzerine attribute -[Required()]- gibi tanımlama yapma işlemine DataAnnotations denir. SOLID prensiplerine göre sınıflar sadece veri taşıma görevi üstlenmeli ve DB ile ilgili herhangi bir ayar içermemelidir. Bu sebeple Fluent API yöntemini DataAnnotations yerine tercih ettik.
    //POCO Classes
    public class Product : EntityBase
    {
        //Yazdığımız propertylerin PK olması için ID veya Id ile bitmesi gerekir.
        //Bunu yapan EntityFramework Default Conventions.
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        //Category ile Product ilişkili olduğundan dolayı bu property FK olacaktır. Bunu yapan da EntityFramework Default Convertions'dır.
        public int CategoryId { get; set; }
        //Virtual ön takısı koyulduğu anda otomatik olarak tablolar arası lazy loading, eager loading gibi ilişkili tabloların çalışma zamanında yüklenmesi gibi EntityFramework'e ait stratejiler ayağa kalkar.
        //Virtual yazmasakta ilişki vardır. Sadece yukarıdaki stratejilere yer verilmez.
        public virtual Category Category { get; set; }

    }
}