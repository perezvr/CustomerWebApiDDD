﻿using CustomerWebApiDDD.Application.DTO.DTO;
using CustomerWebApiDDD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        [HttpGet]
        public ActionResult<List<CustomerDTO>> Get()
        {
            try
            {
                return _customerApplicationService.Get();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> Get(int id)
        {
            try
            {
                return _customerApplicationService.Get(id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<CustomerDTO> Post([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                return _customerApplicationService.Insert(customerDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPut("{id}")]
        public ActionResult<CustomerDTO> Put(int id, [FromBody] CustomerDTO customerDTO)
        {
            try
            {
                CustomerDTO existingCustomer = _customerApplicationService.Get(id);

                if (existingCustomer is null)
                    return NotFound();

                return _customerApplicationService.Update(id, customerDTO);
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
                _customerApplicationService.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
