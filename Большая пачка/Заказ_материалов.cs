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
    
    public partial class Заказ_материалов
    {
        public int ID_Заказа_материалов { get; set; }
        public int ID_Материалов { get; set; }
        public string Количество_материала { get; set; }
        public int ID_Мастера { get; set; }
    
        public virtual Мастер_производства Мастер_производства { get; set; }
        public virtual Материалы Материалы { get; set; }
    }
}
