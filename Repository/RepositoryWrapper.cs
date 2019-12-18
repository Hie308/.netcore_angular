using CozaStorev2.Models;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CozaStoreContext _cozastoreContext;
        private IDeviceRepository _device;
        private IUserRepository _user;
        private ILocationRepository _location;

        public RepositoryWrapper(CozaStoreContext cozastoreContext)
        {
            _cozastoreContext = cozastoreContext;
        }
        public void Save()
        {
            _cozastoreContext.SaveChanges();
        }
        public void SaveAsys()
        {
            _cozastoreContext.SaveChangesAsync();
        }
        public IDeviceRepository Device
        {
            get
            {
                if (_device == null)
                {
                    _device = new DeviceRepository(_cozastoreContext);
                }
                return _device;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_cozastoreContext);
                }
                return _user;
            }
        }
        public ILocationRepository Location
        {
            get
            {
                if (_location == null)
                {
                    _location = new LocationRepository(_cozastoreContext);
                }
                return _location;
            }
        }
    }
}
