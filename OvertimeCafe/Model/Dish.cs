//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OvertimeCafe.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dish
    {
        public Dish()
        {
            this.GuestDish = new HashSet<GuestDish>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Composition { get; set; }
        public int TypeId { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Type Type { get; set; }
        public virtual ICollection<GuestDish> GuestDish { get; set; }
    }
}
