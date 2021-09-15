using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using RailDBProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Project.BLL.Services
{
    public class DefectServices : IDefectServices
    {
        private readonly IUnitOfWork _uow;
        public DefectServices(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public List<Defect> GetAll()
        {
            return _uow.Defects
                  .ReadAll().Where(d => d.IsDeleted == false).ToList();
        }
    }
}