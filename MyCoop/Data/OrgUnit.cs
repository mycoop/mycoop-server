
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
    
public partial class OrgUnit
{

    public OrgUnit()
    {

        this.Children = new HashSet<OrgUnit>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public System.DateTime CreationTime { get; set; }

    public System.DateTime ModificationTime { get; set; }

    public int OwnerId { get; set; }

    public Nullable<int> ParentId { get; set; }

    public double Lat { get; set; }

    public double Lng { get; set; }



    public virtual ICollection<OrgUnit> Children { get; set; }

    public virtual OrgUnit Parent { get; set; }

    public virtual User User { get; set; }

}

}
