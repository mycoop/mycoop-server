using System;
using System.Linq;
using MyCoop.Data;
using MyCoop.WebApi.Models.Components;

namespace MyCoop.WebApi.Models.WorkspaceTemplates
{
    public class WorkspaceTemplateModel
    {
        private readonly WorkspaceTemplate _workspaceTemplate;
        private readonly int _documentCount;
        private readonly ComponentModel[] _components;

        public WorkspaceTemplateModel(WorkspaceTemplate workspaceTemplate)
        {
            _workspaceTemplate = workspaceTemplate;
            _documentCount = workspaceTemplate.DocumentTemplates.Count;
            _components = workspaceTemplate.Components.Select(c => new ComponentModel(c)).ToArray();
        }

        public int Id
        {
            get { return _workspaceTemplate.Id; }
        }

        public string Name
        {
            get { return _workspaceTemplate.Name; }
        }

        public DateTime CreationTime
        {
            get { return _workspaceTemplate.CreationTime; }
        }

        public DateTime ModificationTime
        {
            get { return _workspaceTemplate.ModificationTime; }
        }

        public int CreatedByUserId
        {
            get { return _workspaceTemplate.CreatedByUserId; }
        }

        public int ModifiedByUserId
        {
            get { return _workspaceTemplate.ModifiedByUserId; }
        }

        public int DocumentCount
        {
            get { return _documentCount; }
        }

        public ComponentModel[] Components
        {
            get { return _components; }
        }
    }
}