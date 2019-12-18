using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CozaStorev2.Models;
using DataContracts;
using EntityModel.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CozaStorev2.Controllers
{
    [Route("api/SampleDataController")]
    public class SampleDataController : Controller
    {
        ILoggerManager logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repoWrapper;
        public SampleDataController(IRepositoryWrapper repoWrapper, ILoggerManager logger,  IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
            _mapper = mapper;
    }
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILoggerManager _logger;
       

        //[HttpGet("[action]")]
        //public IEnumerable<WeatherForecast> WeatherForecasts()
        //{
        //    var rng = new Random();
        //    _logger.LogInfo("Here is info message from the controller.");
        //    _logger.LogDebug("Here is debug message from the controller.");
        //    _logger.LogWarn("Here is warn message from the controller.");
        //    _logger.LogError("Here is error message from the controller.");
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    });
        //}
        [HttpGet]
        [Route("Customer")]
        public IActionResult GetDevices()
        {
            _logger.LogInfo("Here is info message from the controller.");
            var devices = _repoWrapper.Device.FindAll();
            var Result = _mapper.Map<IEnumerable<DeviceDto>>(devices);
            return Ok(Result);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Devices>> GetDevice([FromRoute] int id)
        {
            _logger.LogInfo("Here is info message from the controller.");
            var device = _repoWrapper.Device.FindByCondition(x=>x.Id == id);
            return Ok(device);
        }
        [HttpPost]
        public  IActionResult PostUser([FromBody] /*DeviceForCreationDto*/ Devices device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var deviceEF = _mapper.Map<Devices>(device);
            //_repoWrapper.Device.Create(deviceEF);
            //_repoWrapper.Save();
            //var createdDevice = _mapper.Map<DeviceDto>(deviceEF);
            _repoWrapper.Device.Create(device);
            _repoWrapper.Save();
            // return CreatedAtAction("GetDevice", new { id = createdDevice.Id }, createdDevice);
            return CreatedAtAction("GetDevice", new { id = device.Id }, device);
        }
        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
