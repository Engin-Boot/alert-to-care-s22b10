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
        public IcuWardInformation getLayout(string WardNumber){
            IcuWardInformation wardInformation=_context.IcuWardInformation.Find(WardNumber);
            return wardInformation;
        }
        public IEnumerable<BedInformation> getAllBedsInWard(string wardNumber){
            IcuWardInformation wardInformation = getLayout(wardNumber);
            BedInformation[] bedInformationArray = new BedInformation[wardInformation.TotalBed];
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
