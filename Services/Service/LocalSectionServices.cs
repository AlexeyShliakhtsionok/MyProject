using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Repository;

namespace Project.BLL.Services
{
    class LocalSectionServices : ILocalSectionServices
    {
        private readonly IUnitOfWork _uow;
        public LocalSectionServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
