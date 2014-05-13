using p2groep04.Models.Domain;
using System.Data.Entity;
using System.Linq;

namespace p2groep04.Models.DAL
{
    public class SuggestionRepository : ISuggestionRepository
    {
        private ProjectContext context;
        private DbSet<Suggestion> suggestions;

        public SuggestionRepository(ProjectContext context)
        {
            this.context = context;
            suggestions = context.Suggestions;
        }

        public IQueryable<Suggestion> FindAll()
        {
            return suggestions.OrderBy(s => s.Subject);
        }

        public Suggestion FindBy(int id)
        {
            return suggestions.SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<Suggestion> FindByUser(int id)
        {
            return suggestions.OrderBy(s => s.Student.Id == id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}