using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts
{
    public interface IRepositoryWrapper
    {
        IDeviceRepository Device { get; }
        IUserRepository User { get; }
        ILocationRepository Location { get; }
        void Save();
        void SaveAsys();
        
    }
}
