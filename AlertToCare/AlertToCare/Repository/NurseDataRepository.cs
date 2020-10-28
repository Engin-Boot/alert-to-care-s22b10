using AlertToCare.Models;
using System.Collections.Generic;
using System.Linq;


namespace AlertToCare.Repository
{
    public class NurseDataRepository : INurseDataRepository
    {
        private readonly DbContext _context;

        public NurseDataRepository(DbContext context)
        {
            _context = context;
        }

        public void AddNurse(NurseDataModel nurse)
        {
            _context.NurseInfo.Add(nurse);
            _context.SaveChanges();
        }

        public IEnumerable<NurseDataModel> GetAll()
        {
            var nurses = _context.NurseInfo;

            return nurses.ToList();
        }
    }
}
