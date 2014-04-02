using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2groep04.Models.Domain
{
    public interface ISuggestionRepository
    {
        IQueryable<Suggestion> FindAll();
        Suggestion FindBy(int id);
        IQueryable<Suggestion> FindByUser(int id);
    }
}
