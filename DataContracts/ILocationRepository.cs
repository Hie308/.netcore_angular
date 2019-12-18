using CozaStorev2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataContracts
{
    public interface ILocationRepository: IRepositoryBase<Locations>
    {
        Locations GetLocationWithDetails(int Id);
    }
     
    
}
