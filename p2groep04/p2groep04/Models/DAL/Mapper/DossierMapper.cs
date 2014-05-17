using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using p2groep04.Models.Domain;

namespace p2groep04.Models.DAL.Mapper
{
    public class DossierMapper : EntityTypeConfiguration<Dossier>
    {
        public DossierMapper()
        {
            HasKey(d => d.Id);
            //HasOptional(s => s.Suggestion).WithOptionalDependent(s => s.Dossier);
        }
    }
}