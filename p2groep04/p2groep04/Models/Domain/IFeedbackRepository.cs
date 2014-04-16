using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2groep04.Models.Domain
{
    interface IFeedbackRepository
    {
        IQueryable<Feedback> FindAll();
        Feedback FindBy(int id);
    }
}
