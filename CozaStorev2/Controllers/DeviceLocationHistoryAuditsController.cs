using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CozaStorev2.Models;
using EntityModel;

namespace CozaStorev2.Controllers
{
    [Route("api/DeviceLocationHistoryAuditsController")]
    [ApiController]
    public class DeviceLocationHistoryAuditsController : ControllerBase
    {
        private readonly CozaStoreContext _context;

        public DeviceLocationHistoryAuditsController(CozaStoreContext context)
        {
            _context = context;
        }

        // GET: api/DeviceLocationHistoryAudits
        [HttpGet]
        public IEnumerable<DeviceLocationHistoryAudit> GetDeviceLocationHistoryAudit()
        {
            return _context.DeviceLocationHistoryAudit;
        }

        // GET: api/DeviceLocationHistoryAudits/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceLocationHistoryAudit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceLocationHistoryAudit = await _context.DeviceLocationHistoryAudit.FindAsync(id);

            if (deviceLocationHistoryAudit == null)
            {
                return NotFound();
            }

            return Ok(deviceLocationHistoryAudit);
        }

        // PUT: api/DeviceLocationHistoryAudits/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeviceLocationHistoryAudit([FromRoute] int id, [FromBody] DeviceLocationHistoryAudit deviceLocationHistoryAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceLocationHistoryAudit.DlhistoryId)
            {
                return BadRequest();
            }

            _context.Entry(deviceLocationHistoryAudit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceLocationHistoryAuditExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DeviceLocationHistoryAudits
        [HttpPost]
        public async Task<IActionResult> PostDeviceLocationHistoryAudit([FromBody] DeviceLocationHistoryAudit deviceLocationHistoryAudit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeviceLocationHistoryAudit.Add(deviceLocationHistoryAudit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeviceLocationHistoryAuditExists(deviceLocationHistoryAudit.DlhistoryId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeviceLocationHistoryAudit", new { id = deviceLocationHistoryAudit.DlhistoryId }, deviceLocationHistoryAudit);
        }

        // DELETE: api/DeviceLocationHistoryAudits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeviceLocationHistoryAudit([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deviceLocationHistoryAudit = await _context.DeviceLocationHistoryAudit.FindAsync(id);
            if (deviceLocationHistoryAudit == null)
            {
                return NotFound();
            }

            _context.DeviceLocationHistoryAudit.Remove(deviceLocationHistoryAudit);
            await _context.SaveChangesAsync();

            return Ok(deviceLocationHistoryAudit);
        }

        private bool DeviceLocationHistoryAuditExists(int id)
        {
            return _context.DeviceLocationHistoryAudit.Any(e => e.DlhistoryId == id);
        }
    }
}