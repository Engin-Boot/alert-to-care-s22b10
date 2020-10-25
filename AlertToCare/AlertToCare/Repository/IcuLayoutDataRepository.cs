using AlertToCare.Models;
using System.Collections.Generic;
using System.Linq;

namespace AlertToCare.Repository
{
    public class IcuLayoutDataRepository: IIcuLayoutDataRepository
    {
        private readonly DbContext _context;

        public IcuLayoutDataRepository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<IcuWardInformation> Get()
        {
            var wardInfo = _context.IcuWardInformation;

            return wardInfo.ToList();

        }

        public void InsertBed(BedInformation bed)
        {
            _context.BedInformation.Add(bed);
            _context.SaveChanges();
        }

        public void InsertLayout(IcuWardInformation layout)
        {
            _context.IcuWardInformation.Add(layout);
            _context.SaveChanges();
        }
    }
}
