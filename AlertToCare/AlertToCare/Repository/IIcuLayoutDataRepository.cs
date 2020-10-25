﻿using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public interface IIcuLayoutDataRepository
    {
        public void InsertBed(BedInformation bed);
        public void InsertLayout(IcuWardInformation layout);
        public IEnumerable<BedInformation> getAllBedsInWard(string wardNumber);
    }
}
