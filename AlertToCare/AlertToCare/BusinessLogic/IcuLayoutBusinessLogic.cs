using System;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.BusinessLogic
{
    public class IcuLayoutBusinessLogic : IIcuLayoutBusinessLogic
    {
        private readonly IIcuLayoutDataRepository _icuLayoutDataRepository;

        public IcuLayoutBusinessLogic(IIcuLayoutDataRepository repo)
        {
            
            this._icuLayoutDataRepository = repo;
        }
        
        private bool IsAllBedAreEnteredInDb(int totalBed, int bedEnteredInDb)
        {
            return totalBed < bedEnteredInDb;
        }

        private bool BedLayoutAllocation(IcuWardLayoutModel objLayout)
        {
            try
            {
                bool flag = AddBedInIcu(objLayout);
                return flag;
            }
            catch
            {
                Console.WriteLine("can not connect to db");
                return false;
            }
        }

        private bool AddBedInIcu(IcuWardLayoutModel objLayout)
        {
            int bedCounter = 1;
            for (int numberOfRow = 1; numberOfRow <= objLayout.NumberOfRow; numberOfRow++)
            {
                for (int numberOfColumn = 1; numberOfColumn <= objLayout.NumberOfColumn; numberOfColumn++)
                {
                    var bedId = string.Concat(objLayout.WardNumber, bedCounter.ToString());
                    var bedInfo = new BedInformation
                    {
                        BedId = bedId,
                        BedInColumn = numberOfColumn,
                        BedInRow = numberOfRow,
                        WardNumber = objLayout.WardNumber
                    };
                    _icuLayoutDataRepository.InsertBed(bedInfo);
                    bedCounter++;
                    bool isAllBedAreEnteredInDb = IsAllBedAreEnteredInDb(objLayout.NumberOfBed, bedCounter);
                    if( isAllBedAreEnteredInDb )
                        return true;
                }
            }
            return true;
        }

        public void AddLayoutInformation(IcuWardLayoutModel objLayout)
        {
            var icuLayout = new IcuWardInformation
            {
                Department = objLayout.Department, 
                WardNumber = objLayout.WardNumber, 
                TotalBed = objLayout.NumberOfBed
            };
            bool isBedLayoutIsEnterInDatabase = BedLayoutAllocation(objLayout);
            if (isBedLayoutIsEnterInDatabase == false)
            {
                Console.WriteLine("Bed are not entered for ward " + objLayout.WardNumber);
            }
            _icuLayoutDataRepository.InsertLayout(icuLayout);
        }
    }
}
