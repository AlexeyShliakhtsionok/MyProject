using RailDBProject.Repository.Interface;

namespace RailDBProject.Repository.Repository
{
    public class DefectAuditRepository : Repository<DefectAuditRepository>, IDefectAuditRepository
    {
        public DefectAuditRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }
    }
}
