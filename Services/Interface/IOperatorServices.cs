using RailDBProject.Model;
using System.Collections.Generic;

namespace Project.BLL.Services.IServiceIntefaces
{
    public interface IOperatorServices
    {
        public Operator Update(Operator @operator);
        public List<Operator> GetAllOpp();
        public Operator GetById(int id);
    }
}
