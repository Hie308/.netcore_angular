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
namespace CozaStorev2.Controllers
{
    [Route("api/UsersController")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    
        private ILoggerManager _logger;
        private IMapper _mapper;
        private IRepositoryWrapper _repoWrapper;

        public UsersController(IRepositoryWrapper repoWrapper, ILoggerManager logger, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _repoWrapper.User.FindAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public IActionResult GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var users =  _repoWrapper.User.FindByCondition(x => x.Id == id);

            if (users == null)
            {
                _logger.LogError("User is null");
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public  IActionResult PutUsers([FromRoute] int id, UserForCreationDto users)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var UserForUpdate = _repoWrapper.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            if (UserForUpdate == null)
            {
                _logger.LogError("null id in database");
                return NotFound();
            }

            Users newUser = new Users()
            {
                Id = id,
                Email = users.Email,
                Password = users.Password,
                FullName = users.FullName,
                Status = users.Status,
                Avatar = users.Avatar,
                PhoneNumber = users.PhoneNumber,
                CreatedBy = users.CreatedBy,
                CreatedDate = users.CreatedDate,
                UpdateBy= users.UpdateBy,
                UpdatedDate = users.UpdatedDate 
            };
            

            _repoWrapper.User.Update(newUser);

          

            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }
            
            _repoWrapper.User.Create(users);
            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(users.Id))
                {
                    _logger.LogInfo($"Cannot save change");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ModelState is failed.");
                return BadRequest(ModelState);
            }

            var users = _repoWrapper.User.FindByCondition(x => x.Id == id).FirstOrDefault();
            if (users == null)
            {
                _logger.LogError("Not found in the database.");
                return NotFound();
            }

            _repoWrapper.User.Delete(users);
            try
            {
                _repoWrapper.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    _logger.LogInfo($"Cannot save change");

                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            if( _repoWrapper.User.FindByCondition(e => e.Id == id) != null)
                return true;
            else return false;
        }
    }
}