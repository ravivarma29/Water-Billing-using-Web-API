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

        //[HttpPost]
        //public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
        //{
        //    _context.Customers.Add(customer);
        //    await _context.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetCustomers), new { id = customer.CustomerId }, customer);
        //}

        [HttpPost]
        public async Task<IActionResult> AddCustomers([FromBody] List<Customer> customers)
        {
            if (customers == null || !customers.Any())
            {
                return BadRequest("Customer list is empty.");
            }

            try
            {
                // Add multiple customers to the database
                _context.Customers.AddRange(customers);
                await _context.SaveChangesAsync();

                return Ok(new { Message = $"{customers.Count} customers added successfully." });
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest("Customer ID mismatch");
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
