
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
    
public partial class PermissionLevel
{

    public PermissionLevel()
    {

        this.Users = new HashSet<User>();

    }


    public int Id { get; set; }

    public string Name { get; set; }



    public virtual ICollection<User> Users { get; set; }

}

}
