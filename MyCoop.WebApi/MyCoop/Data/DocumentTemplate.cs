
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
    
public partial class DocumentTemplate
{

    public DocumentTemplate()
    {

        this.WorkspaceDocumentTemplates = new HashSet<WorkspaceDocumentTemplate>();

    }


    public int Id { get; set; }

    public string Name { get; set; }

    public string Reference { get; set; }

    public string Purpose { get; set; }

    public int PagesCount { get; set; }

    public string Link { get; set; }

    public Nullable<int> ComponentId { get; set; }



    public virtual Component Component { get; set; }

    public virtual ICollection<WorkspaceDocumentTemplate> WorkspaceDocumentTemplates { get; set; }

}

}
