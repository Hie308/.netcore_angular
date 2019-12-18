using CozaStorev2.Models;
using DataContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Repository.Repository;

namespace Repository
{
    class DeviceRepository : RepositoryBase<Devices>, IDeviceRepository
    {
        public DeviceRepository(CozaStoreContext cozaContext)
            : base(cozaContext)
        {
        }
        IEnumerable<Devices> GetDeviceById(int? deviceId)
        {
            var result = FindByCondition(x => x.Id == deviceId);
            if (result == null)
                return null;
            return FindByCondition(x => x.Id == deviceId);
        }

        public void UpdateDevice(Devices device)
        {
            Update(device);
        }
        public Devices GetDeviceWithDatails( int deviceId)
        {
            var result = FindByCondition(device => device.Id.Equals(deviceId))
                .Include(owner => owner.Owner).ToList().FirstOrDefault();
                
            return result;
        }
        public IEnumerable<Devices> GetAllDevices()
        {
            return FindAll()
                .OrderBy(dv => dv.FullName)
                .ToList();
        }

    }
}
