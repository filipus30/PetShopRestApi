using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Petshop.Core.ApplicationService;
using Petshop.Core.Entity;

namespace Petshop.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class pets : ControllerBase
    {
        private readonly IPetService _petservice;
        private readonly IOwnerService _ownerservice;


        public pets(IPetService petService, IOwnerService ownerService)
        {
            _petservice = petService;
            _ownerservice = ownerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] FilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.SearchTerm) && string.IsNullOrEmpty(filter.SearchValue))
            {
                try
                {
                    return Ok(_petservice.GetPets());
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
                        return Ok(_petservice.GetPetsFiltered(filter));
                    }
                    catch (Exception)
                    {
                        return StatusCode(500, "Internal Server Error");
                    }
                
            }
        }




        [HttpGet("{Id}")]
        public ActionResult<Pet> Get(int Id)
        {
            try
            {
                return _petservice.GetPetById(Id);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }



        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            try
            {
                return Created("Pet Created", _petservice.NewPet(pet));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet updatedPet)
        {
            if (updatedPet.ID != id)
            {
                return BadRequest("Id's mismatch");
            }
            if (updatedPet.Price == 0)

            {
                return BadRequest("Put Price");
            }
            try
            {
                Pet p = _petservice.UpdatePetPrice(id, updatedPet.Price);
                return Accepted("Pet updated", p);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            } 

        }


        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            try
            {
               Pet p = _petservice.DeletePet(id);
                return Accepted(" pet has been deleted",p);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }






    }
}
    

