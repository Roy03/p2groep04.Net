using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class PromotorRepository:IPromotorRepository
    {
        private ProjectContext context;
        private DbSet<Promotor> promotors;

        public PromotorRepository(ProjectContext context)
        {
            this.context = context;
            promotors = context.Promotors;
        }
 
        public IQueryable<Promotor> FindAll()
        {
            return promotors.OrderBy(p => p.LastName);
        }

        public Promotor FindBy(int id)
        {
            return promotors.FirstOrDefault(p => p.Id == id);
        }
    }
}