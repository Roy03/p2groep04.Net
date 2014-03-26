using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL
{
    public class BPCoordinatorRepository:IBPCoordinatorRepository
    {
        private ProjectContext context;
        private DbSet<BPCoordinator> bpCoordinators;

        public BPCoordinatorRepository(ProjectContext context)
        {
            this.context = context;
            bpCoordinators = context.BpCoordinators;
        }

        public IQueryable<BPCoordinator> FindAll()
        {
            return bpCoordinators.OrderBy(b => b.FirstName);
        }

        public BPCoordinator FindBy(int id)
        {
            return bpCoordinators.FirstOrDefault(b => b.Id == id);
        }
    }
}