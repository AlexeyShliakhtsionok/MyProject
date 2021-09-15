using Project.BLL.Services.IServiceIntefaces;
using RailDBProject.Model;
using RailDBProject.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Services.Service
{
    public class OperatorService : IOperatorServices
    {
        private readonly IUnitOfWork _uow;
        public OperatorService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public List<Operator> GetAllOpp()
        {
            return _uow.
                Operators.ReadAll().ToList();
        }

        public Operator GetById(int _id)
        {
            return _uow.Operators.Read(_id);
        }

        public Operator Update(Operator @operator)
        {
            _uow.
                Operators.
                Update(@operator);
            _uow.SaveChanges();
            return @operator;
        }
    }
}
