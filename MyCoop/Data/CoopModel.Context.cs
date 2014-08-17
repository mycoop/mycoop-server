﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class CoopEntities : DbContext
{
    public CoopEntities()
        : base("name=CoopEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Component> Components { get; set; }

    public virtual DbSet<DocumentTemplate> DocumentTemplates { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<OrgUnitGroupPermission> OrgUnitGroupPermissions { get; set; }

    public virtual DbSet<OrgUnit> OrgUnits { get; set; }

    public virtual DbSet<OrgUnitUserPermission> OrgUnitUserPermissions { get; set; }

    public virtual DbSet<PermissionLevel> PermissionLevels { get; set; }

    public virtual DbSet<SysEvent> SysEvents { get; set; }

    public virtual DbSet<SysEventType> SysEventTypes { get; set; }

    public virtual DbSet<UserGroup> UserGroups { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkspaceTemplate> WorkspaceTemplates { get; set; }


    public virtual int DeleteGroup(Nullable<int> groupId)
    {

        var groupIdParameter = groupId.HasValue ?
            new ObjectParameter("groupId", groupId) :
            new ObjectParameter("groupId", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteGroup", groupIdParameter);
    }


    public virtual int DeleteUser(Nullable<int> userId)
    {

        var userIdParameter = userId.HasValue ?
            new ObjectParameter("userId", userId) :
            new ObjectParameter("userId", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUser", userIdParameter);
    }


    public virtual int DeleteComponent(Nullable<int> groupId)
    {

        var groupIdParameter = groupId.HasValue ?
            new ObjectParameter("groupId", groupId) :
            new ObjectParameter("groupId", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteComponent", groupIdParameter);
    }

}

}

