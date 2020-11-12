using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Application.Interfaces;
using CustomerWebApiDDD.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerWebApiDDD.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public CustomerController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<CustomerDTO>> Get()
        {
            try
            {
                return _customerApplicationService.Get();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> Get(int id)
        {
            try
            {
                return _customerApplicationService.Get(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                _customerApplicationService.Insert(customerDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerDTO customerDTO)
        {
            try
            {
                CustomerDTO existingCustomer = _customerApplicationService.Get(id);

                if (existingCustomer is null)
                    return NotFound();

                _customerApplicationService.Update(id, customerDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _customerApplicationService.Delete(id);
                return Ok();

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
