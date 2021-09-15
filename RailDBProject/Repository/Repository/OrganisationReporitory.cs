using RailDBProject.Model;
using RailDBProject.Repository.Interface;

namespace RailDBProject.Repository.Repository
{
    public class OrganisationReporitory : Repository<Organisation>, IOrganisationRepository
    {
        public OrganisationReporitory(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
        public override void Delete(Organisation organisation)
        {
            organisation.IsDeleted = true;
            _context.Update(organisation);
        }
    }
}
