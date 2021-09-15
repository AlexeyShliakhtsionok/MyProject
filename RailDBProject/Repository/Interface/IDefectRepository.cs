using RailDBProject.Model;

namespace RailDBProject.Repository.Interface
{
    public interface IDefectRepository : IRepository<Defect>
    {
        public void DeleteById(int id);
    }

}
