using CozaStorev2.Models;
using DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Repository.Repository;

namespace Repository
{
    class LocationRepository : RepositoryBase<Locations>, ILocationRepository
    {
        public LocationRepository(CozaStoreContext cozaContext)
            : base(cozaContext)
        {
        }
        public Locations GetLocationWithDetails(int Id)
        {
            return FindByCondition(loca => loca.Id == Id).FirstOrDefault();
                
        }
    }
}
