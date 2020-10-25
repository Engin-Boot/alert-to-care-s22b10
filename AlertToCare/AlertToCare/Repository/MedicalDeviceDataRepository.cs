﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public class MedicalDeviceDataRepository: IMedicalDeviceDataRepository
    {
        private readonly DbContext _context;

        public MedicalDeviceDataRepository(DbContext context)
        {
            _context = context;
        }

        public MedicalDevice FetchMedicalDevice(string medicalDevice)
        {
            var device = _context.MedicalDevice.FirstOrDefault(m => m.DeviceName == medicalDevice);
            return device;
        }

        public void InsertMedicalDevice(MedicalDevice device)
        {
            _context.MedicalDevice.Add(device);
            _context.SaveChanges();
        }
        public void TurnOnAlert(BedOnAlert bed)
        {
            _context.BedOnAlert.Add(bed);
            _context.SaveChanges();
        }

        public BedInformation FetchBedLayoutInfo(string bedId)
        {
            var layoutInfo = _context.BedInformation.FirstOrDefault(layout => layout.BedId == bedId);
            return layoutInfo;
        }

        public void TurnOffAlert(string bedId)
        {
            _context.BedOnAlert.RemoveRange(_context.BedOnAlert.Where(bed => bed.BedId == bedId));
            _context.SaveChanges();
        }
        public IEnumerable<BedOnAlert> getAllAlerts(string wardNumber)
        {
            var allAlerts = (from alert in _context.BedOnAlert
                            join
                                bed in _context.BedInformation on
                                alert.BedId equals bed.BedId
                            where bed.WardNumber == wardNumber
                            select alert);
            
            return allAlerts;

        }
        public bool raiseAlert(string bedId, string device,int value)
        {
            BedInformation bedOnAlert = _context.BedInformation.Where(bed => bed.BedId == bedId).FirstOrDefault();
            BedOnAlert bed = new BedOnAlert();

            if (bedOnAlert.PatientId != null)
            {
                bed.BedId = bedId;
                bed.DeviceName = device;
                bed.Value = value;
                _context.BedOnAlert.Add(bed);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
