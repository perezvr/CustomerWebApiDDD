using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CustomerWebApiDDD.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressApplicationService _addressApplicationService;

        public AddressController(IAddressApplicationService addressApplicationService)
        {
            _addressApplicationService = addressApplicationService;
        }

        [HttpGet]
        public ActionResult<List<AddressDTO>> Get()
        {
            try
            {
                return _addressApplicationService.Get();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AddressDTO> Get(int id)
        {
            try
            {
                return _addressApplicationService.Get(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<AddressDTO> Post([FromBody] AddressDTO addressDTO)
        {
            try
            {
                return _addressApplicationService.Insert(addressDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<AddressDTO> Put(int id, [FromBody] AddressDTO addressDTO)
        {
            try
            {
                return _addressApplicationService.Update(id, addressDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _addressApplicationService.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
