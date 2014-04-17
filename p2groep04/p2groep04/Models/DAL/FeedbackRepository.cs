using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class FeedbackRepository:IFeedbackRepository
    {
        private ProjectContext context;
        private DbSet<Feedback> feedbacks;

        public FeedbackRepository(ProjectContext context)
        {
            this.context = context;
            feedbacks = context.Feedbacks;
        }

        public IQueryable<Feedback> FindAll()
        {
            return feedbacks.OrderBy(r => r.Id);
        }

        public Feedback FindBy(int id)
        {
            return feedbacks.SingleOrDefault(r => r.Id == id);
        }
    }
    }
}