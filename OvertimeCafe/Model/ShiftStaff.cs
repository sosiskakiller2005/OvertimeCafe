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
    
    public partial class ShiftStaff
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int StaffId { get; set; }
    
        public virtual Shift Shift { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
