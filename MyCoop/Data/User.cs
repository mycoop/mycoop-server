
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
    
public partial class User
{

    public User()
    {

        this.ModifiedGroups = new HashSet<Group>();

        this.CreatedGroups = new HashSet<Group>();

        this.UserGroups = new HashSet<UserGroup>();

    }


    public int Id { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public int TypeId { get; set; }

    public int PermissionLevelId { get; set; }

    public System.DateTime LastAcitve { get; set; }



    public virtual ICollection<Group> ModifiedGroups { get; set; }

    public virtual ICollection<Group> CreatedGroups { get; set; }

    public virtual PermissionLevel PermissionLevel { get; set; }

    public virtual ICollection<UserGroup> UserGroups { get; set; }

}

}
