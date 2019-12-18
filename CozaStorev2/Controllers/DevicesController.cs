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
using Newtonsoft.Json;
using EntityModel;
using Microsoft.AspNetCore.Authorization;

namespace CozaStorev2.Controllers
{
    [Authorize]
    [Route("api/DevicesController")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repoWrapper;
       
        public DevicesController(IRepositoryWrapper repoWrapper, ILoggerManager logger, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Devices
        [HttpGet]
        public IEnumerable<Devices> GetDevices()
        {
            var devices= _repoWrapper.Device.GetAllDevices();
            
         
            return devices;
        }
        //public IEnumerable<DeviceLocationHistoryAudit> GetDeviceLocationHistoryAudit()
        //{
        //    return _repoWrapper. .FindAll();
        //}
        // GET: api/Devices/5
        [HttpGet("{id}")]
        public  IActionResult GetDevices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var device =  _repoWrapper.Device.FindByCondition(x=>x.Id == id);

            if (device == null)
            {
                _logger.LogError("Cannot save change");
                return NotFound();
            }
            var deviceResult = _mapper.Map<DeviceDto>(device);
            return Ok(deviceResult);
        }
        [Produces("application/json")]
        [HttpGet("{id}/user")]
        public  IActionResult GetDeviceWithDetails(int id)
        {
           
            
                var device = _repoWrapper.Device.GetDeviceWithDatails(id);
                

                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
               
                else
                {
                    _logger.LogInfo($"Returned Device with user details of it: {id}");
                var deviceOwnerDetail = new UserDto();
                deviceOwnerDetail.Id = device.Owner.Id;
                deviceOwnerDetail.Email = device.Owner.Email;
                deviceOwnerDetail.FullName = device.Owner.FullName;
                deviceOwnerDetail.Status = device.Owner.Status;
                deviceOwnerDetail.Avatar = device.Owner.Avatar;
                deviceOwnerDetail.PhoneNumber = device.Owner.PhoneNumber;
                deviceOwnerDetail.CreatedBy = device.Owner.CreatedBy;
                deviceOwnerDetail.CreatedDate = device.Owner.CreatedDate;
                return Ok(deviceOwnerDetail);
                }
            
        }
        [Produces("application/json")]
        // PUT: api/Devices/5
        [HttpPut("{id}")]
        public  IActionResult PutDevices( int id,  DeviceDto device)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }
            
            var DeviceForUpdate = _repoWrapper.Device.FindByCondition(x => x.Id == id).FirstOrDefault();
            if(DeviceForUpdate == null)
            {
                _logger.LogError("null id in database");
                return NotFound();
            }

          
             var reresult = _mapper.Map(device, DeviceForUpdate);
             //var result =_mapper.Map(device, DeviceForUpdate);
             
            _repoWrapper.Device.Update(reresult);
            

            
           

            try
            {
                 _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevicesExists(id))
                {
                    _logger.LogInfo($"Cannot save change");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Devices
        [HttpPost]
        public IActionResult PostDevices(/*[FromBody]*/ Devices devices)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }
            //Devices newDevice = _mapper.Map<Devices>(devices);
            //var updateDevice = _mapper.Map<Devices>(newDevice); ;
            _repoWrapper.Device.Create(devices);
            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevicesExists(devices.Id))
                {
                    _logger.LogInfo($"Cannot save change");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDevices", new { id = devices.Id }, devices);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteDevices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var devices =  _repoWrapper.Device.FindByCondition(x=>x.Id == id).FirstOrDefault();
            if (devices == null)
            {
                _logger.LogError("Not found in the database.");
                return NotFound();
            }

            _repoWrapper.Device.Delete(devices);
            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevicesExists(id))
                {
                    _logger.LogInfo($"Cannot save change");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(devices);
        }

        private bool DevicesExists(int id)
        {
            if (_repoWrapper.Device.FindByCondition(d => d.Id == id) != null)
                return true;
            else return false;
        }
    }
}