
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MyCoop.Data
{

using System;
    using System.Collections.Generic;
    
public partial class SysEventType
{

    public SysEventType()
    {

        this.SysEvents = new HashSet<SysEvent>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }



    public virtual ICollection<SysEvent> SysEvents { get; set; }

}

}
