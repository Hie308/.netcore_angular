using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CozaStorev2.Models;
using AutoMapper;
using DataContracts;
using EntityModel.DTO;
using NLog;
namespace CozaStorev2.Controllers
{
    [Route("api/LocationsController")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repoWrapper;
        public LocationsController(IRepositoryWrapper repoWrapper, ILoggerManager logger, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Locations
        [HttpGet]
        public IEnumerable<Locations> GetLocations()
        {
            return _repoWrapper.Location.FindAll();
        }

        // GET: api/Locations/5
        [HttpGet("{id}")]
        public  IActionResult GetLocations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var location =  _repoWrapper.Location.FindByCondition(x => x.Id == id);

            if (location == null)
            {
                _logger.LogError("Location is null");
                return NotFound();
            }
            var locationResult = _mapper.Map<LocationDto>(location);
            return Ok(location);
        }

        // PUT: api/Locations/5
        [HttpPut("{id}")]
        public IActionResult PutLocations([FromRoute] int id,  LocationForCreationDto locations)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var LocationForUpdate = _repoWrapper.Location.FindByCondition(x => x.Id == id).FirstOrDefault();
            if (LocationForUpdate == null)
            {
                _logger.LogError("null id in database");
                return NotFound();
            }

            Locations newlocation = new Locations()
            {
                Id = id,
                AreaCode = locations.AreaCode,
                Adrress = locations.Adrress,
                Status = locations.Status,
                Revenue = locations.Revenue,
                Leader = locations.Leader
               
            };
            var result = _mapper.Map(LocationForUpdate, locations);
            _repoWrapper.Location.Update(newlocation);

           

            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationsExists(id))
                {
                    _logger.LogInfo($"Location is null");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Locations
        [HttpPost]
        public  IActionResult PostLocations( Locations locations)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }
            
            _repoWrapper.Location.Create(locations);
            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationsExists(locations.Id))
                {
                    _logger.LogInfo($"Location is null");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        

            return CreatedAtAction("GetLocations", new { id = locations.Id }, locations);
        }

        // DELETE: api/Locations/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLocations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var locations = _repoWrapper.Location.FindByCondition(x => x.Id == id).FirstOrDefault();
            if (locations == null)
            {
                _logger.LogError("Not found in the database.");
                return NotFound();
            }

            _repoWrapper.Location.Delete(locations);
            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationsExists(id))
                {
                    _logger.LogInfo($"Location is null");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            return Ok(locations);
        }

        private bool LocationsExists(int id)
        {
            if( _repoWrapper.Location.FindByCondition(e => e.Id == id) != null) 
                 return true;
            else return false;
        }
    }
}