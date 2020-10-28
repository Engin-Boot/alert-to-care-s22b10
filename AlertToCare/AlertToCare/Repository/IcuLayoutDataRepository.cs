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
        private IcuWardInformation GetLayout(string wardNumber){
            IcuWardInformation wardInformation=_context.IcuWardInformation.Find(wardNumber);
            return wardInformation;
        }
        public IEnumerable<BedInformation> getAllBedsInWard(string wardNumber){
            IcuWardInformation wardInformation = GetLayout(wardNumber);
       
             var dataset = 
            (from bed in _context.BedInformation 
             orderby bed.BedInRow,bed.BedInColumn
             where bed.WardNumber == wardNumber 
            select new BedInformation
            {
                BedId = bed.BedId,
                WardNumber = bed.WardNumber,
                BedInRow = bed.BedInRow,
                BedInColumn = bed.BedInColumn,
                PatientId = bed.PatientId,
            }).ToList();
            return dataset;
        }
    }
}
