//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Большая_пачка
{
    using System;
    using System.Collections.Generic;
    
    public partial class Продукция
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Продукция()
        {
            this.Каталог_готовой_продукции = new HashSet<Каталог_готовой_продукции>();
            this.Склад = new HashSet<Склад>();
        }
    
        public int ID_Продукции { get; set; }
        public string Наименование { get; set; }
        public string Тип_материала { get; set; }
        public Nullable<int> ID_Поставщика { get; set; }
        public string Количество_в_упакове { get; set; }
        public string Единица_измерения { get; set; }
        public string Количество { get; set; }
        public string Описание { get; set; }
        public string Изображение_товара { get; set; }
        public string Стоимость { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Каталог_готовой_продукции> Каталог_готовой_продукции { get; set; }
        public virtual Поставщик Поставщик { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Склад> Склад { get; set; }
    }
}
