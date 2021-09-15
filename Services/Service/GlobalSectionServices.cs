using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Repository;

namespace Project.BLL.Services
{
    class GlobalSectionServices : IGlobalSectionServices
    {
        private readonly IUnitOfWork _uow;
        public GlobalSectionServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
