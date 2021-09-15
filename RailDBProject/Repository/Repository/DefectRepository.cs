using RailDBProject.Model;
using RailDBProject.Repository.Interface;
using System;

namespace RailDBProject.Repository.Repository
{
    public class DefectRepository : Repository<Defect>, IDefectRepository
    {
        public DefectRepository(RailDBContext context) : base(context)
        {
        }
        public RailDBContext RailDBContext
        {
            get { return _context; }
        }

        public override void Create(Defect defect)
        {
            defect.IsDeleted = false;
            defect.DateOfDetection = DateTime.Now;
            _context.Update(defect);
        }
        public override void Delete(Defect defect)
        {
            DefectAudit defectTransfer = new DefectAudit(); 
            defectTransfer = defect;
            defect.IsDeleted = true;
            _context.Update(defect);
            _context.Update(defectTransfer);
        }

        public void DeleteById(int id)
        {
            var entity = _context.Defects.Find(id);
            DefectAudit defectTransfer = new DefectAudit();
            defectTransfer = entity;
            entity.IsDeleted = true;
            _context.DefectAudits.Add(defectTransfer);
            _context.Update(entity);
        }
    }
}
