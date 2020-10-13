using System;
using AlertToCare.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = AlertToCare.Context.DbContext;

namespace AlertToCare.UnitTest.Repository
{
    public class InMemoryContext: IDisposable
    {
        protected readonly Context.DbContext _context;

        public InMemoryContext()
        {
            var option = new DbContextOptionsBuilder<Context.DbContext>().UseInMemoryDatabase(
                databaseName: Guid.NewGuid().ToString()).Options;
            _context = new Context.DbContext(option);
            _context.Database.EnsureCreated();
            InitializeDatabase(_context);

        }

        private void InitializeDatabase(DbContext context)
        {
            var patient = new PatientDataModel
            {
                PatientName = "TestPatient", 
                Address = "TestAddr", 
                Email = "TestEmail", 
                Mobile = "9898989898"
            };
            context.Add(patient);

            var bed = new BedInformation
            {
                PatientId = 1,
                BedId = "1A1",
                BedInColumn = 1,
                BedInRow = 2,
                WardNumber = "1A"
            };
            context.Add(bed);

            var medicalDevice = new MedicalDevice 
                {
                    DeviceName = "TestDevice", 
                    MaxValue = 160, 
                    MinValue = 80
                };
            context.Add(medicalDevice);

            var wardInfo = new IcuWardInformation()
            {
                WardNumber = "1B",
                Department = "Dept",
                TotalBed = 2
            };
            context.Add(wardInfo);

            var bed2 = new BedInformation
            {
                PatientId = null,
                BedId = "1B1",
                BedInColumn = 1,
                BedInRow = 2,
                WardNumber = "1B"
            };
            context.Add(bed2);
            context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
