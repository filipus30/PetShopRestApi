using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petshop.Core.ApplicationService;
using Petshop.Core.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Petshop.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class owners : Controller

    {
        private readonly IPetService _petservice;
        private readonly IOwnerService _ownerservice;
        private readonly IPetTypeService _pettypeservice;

        public owners(IPetService petService, IOwnerService ownerService, IPetTypeService petTypeService)
        {
            _petservice = petService;
            _ownerservice = ownerService;
            _pettypeservice = petTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get([FromQuery] FilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.SearchTerm) && string.IsNullOrEmpty(filter.SearchValue))
            {
                try
                {
                    return Ok(_ownerservice.GetOwners());
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }
            }

            else
            {

                try
                {
                    return Ok(_ownerservice.GetOwnersFiltered(filter));
                }
                catch (Exception)
                {
                    return StatusCode(500, "Internal Server Error");
                }

            }
        }




        [HttpGet("{Id}")]
        public ActionResult<Owner> Get(int Id)
        {
            try
            {
                return _ownerservice.GetOwnerById(Id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }



        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return Created("Owner Created", _ownerservice.NewOwner(owner));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] PetType updatedPetType)
        {
            if (updatedPetType.PetTypeId != id)
            {
                return BadRequest("Id's mismatch");
            }
            if (updatedPetType.PetTypeName.Equals(null))

            {
                return BadRequest("Put Name");
            }
            try
            {
                PetType p = _pettypeservice.UpdatePetType(id, updatedPetType.PetTypeName);
                return Accepted("PetType updated", p);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }


        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            try
            {
                PetType p = _pettypeservice.DeletePetType(id);
                return Accepted("petType has been deleted", p);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

    }
}
