
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
    
public partial class OrgUnitGroupPermission
{

    public int OrgUnitId { get; set; }

    public int GroupId { get; set; }

    public int PermissionLevelId { get; set; }



    public virtual Group Group { get; set; }

    public virtual OrgUnit OrgUnit { get; set; }

    public virtual PermissionLevel PermissionLevel { get; set; }

}

}