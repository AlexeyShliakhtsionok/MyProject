using RailDBProject.Repository.Interface;
using System;


namespace RailDBProject.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDefectRepository Defects { get; }
        IGlobalSectionRepository GlobalSections { get; }
        ICoordinateRepository Coordinates { get; }
        ILocalSectionRepository LocalSections { get; }
        IOrganisationRepository Organisations { get; }
        IUserRepository Users { get; }
        IDefectAuditRepository DefectAudits { get; }
        IOperatorRepository Operators { get; }
        IDefectoScopeRepository DefectoScopes { get; }
        public int SaveChanges();
    }
}
