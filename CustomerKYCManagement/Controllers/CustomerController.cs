using CustomerKYCManagement.DTOs;
using CustomerKYCManagement.services;
using Microsoft.AspNetCore.Mvc;
namespace CustomerKYCManagement.controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController(ICustomerService service) : ControllerBase
    {
        private readonly ICustomerService _service = service;

        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> CreateCustomer(CustomerRequest request)
        {
            return Ok(await _service.CreateCustomerAsync(request));
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerResponse>>> GetCustomers()
        {
            return Ok(await _service.GetCustomersAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomer(Guid id)
        {
            return Ok(await _service.GetCustomerAsync(id));
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponse>> UpdateCustomer(Guid id, UpdateCustomerRequest request)
        {
            return Ok(await _service.UpdateCustomerAsync(id, request));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _service.DeleteCustomerAsync(id);
            return NoContent();
        }
        [HttpPatch("{id}/activate")]
        public async Task<IActionResult> Activate(Guid id)
        {
            return Ok(await _service.ActivateCustomerAsync(id));
        }
        [HttpPatch("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            return Ok(await _service.DeactivateCustomerAsync(id));
        }
        [HttpPatch("{id}/kyc/approve")]
        public async Task<IActionResult> ApproveKyc(Guid id)
        {
            return Ok(await _service.ApproveKycAsync(id));
        }
        [HttpPatch("{id}/kyc/reject")]
        public async Task<IActionResult> RejectKyc(Guid id)
        {
            return Ok(await _service.RejectKycAsync(id));
        }
    }
}
