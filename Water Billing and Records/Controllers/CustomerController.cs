using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Water_Billing_and_Records.Data;

namespace Water_Billing_and_Records.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly WaterBillingContext _context;

        public CustomerController(WaterBillingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomers), new { id = customer.CustomerId }, customer);
        }
    }

}
