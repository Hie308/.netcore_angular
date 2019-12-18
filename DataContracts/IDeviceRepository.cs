using CozaStorev2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts
{
    public interface IDeviceRepository: IRepositoryBase<Devices>
    {
         void UpdateDevice(Devices device);
        Devices GetDeviceWithDatails(int deviceId);
        IEnumerable<Devices> GetAllDevices();
    }
}

