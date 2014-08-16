using System.Data.Entity;
using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories.Instances
{
    public class DocumentTemplateRepository : RepositoryBase<DocumentTemplate>, IDocumentTemplateRepository
    {
        public DocumentTemplateRepository(CoopEntities context) : base(context)
        {
        }

        protected override DbSet<DocumentTemplate> ObjectSet
        {
            get { return Context.DocumentTemplates; }
        }

        public Task<DocumentTemplate> GetValue(int id, params string[] includes)
        {
            return GetEntities(includes).SingleAsync(entity => entity.Id == id);
        }
    }
}