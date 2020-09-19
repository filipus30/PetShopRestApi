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
    public class petsType : Controller
    {
        private readonly IPetService _petservice;
        private readonly IOwnerService _ownerservice;
        private readonly IPetTypeService _pettypeservice;


        public petsType(IPetService petService, IOwnerService ownerService,IPetTypeService petTypeService)
        {
            _petservice = petService;
            _ownerservice = ownerService;
            _pettypeservice = petTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get([FromQuery] FilterModel filter)
        {
            if (string.IsNullOrEmpty(filter.SearchTerm) && string.IsNullOrEmpty(filter.SearchValue))
            {
                try
                {
                    return Ok(_pettypeservice.GetPetTypes());
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
                return Accepted(" pet has been deleted", p);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }


    }
}
