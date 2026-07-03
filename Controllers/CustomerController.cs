using BankPOS.DTOs;
using BankPOS.Entities;
using BankPOS.Interfaces;
using BankPOS.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankPOS.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("/api/createCustomer")]
        public async Task<ActionResult<CreateCustomerResponse>> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                CustomerName = request.CustomerName,
                CustomerNationalId = request.CustomerNationalId,
                CustomerPhone = request.CustomerPhone
            };
            var createdCustomer = await _customerService.CreateCustomerAsync(customer);
            return Ok(new CreateCustomerResponse(
                createdCustomer.CustomerId,
                createdCustomer.CustomerName,
                createdCustomer.CustomerNationalId,
                createdCustomer.CustomerPhone
            ));
        }

        [HttpPost("/api/getCustomerProfile")]
        public async Task<ActionResult<GetCustomerProfileRequest>> GetCustomerProfile([FromBody] GetCustomerProfileRequest request)
        {
            var customer = await _customerService.GetCustomerProfileAsync(request.CustomerId);
            return Ok(new GetCustomerProfileResponse(
                customer.CustomerId,
                customer.CustomerName,
                customer.CustomerNationalId,
                customer.CustomerPhone
            ));
        }
    }
}