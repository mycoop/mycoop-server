
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
    
public partial class WorkspaceDocumentTemplate
{

    public int WorkspaceTemplateId { get; set; }

    public int DocumentTemplateId { get; set; }

    public Nullable<System.DateTime> CreationTime { get; set; }



    public virtual DocumentTemplate DocumentTemplate { get; set; }

    public virtual WorkspaceTemplate WorkspaceTemplate { get; set; }

}

}
