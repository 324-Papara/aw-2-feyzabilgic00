using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Para.Bussiness.Services;
using Para.Data.Context;
using Para.Data.Domain;
using Para.Data.UnitOfWork;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ParaSqlDbContext dbContext;
        private readonly ICustomerService _customerService;
        public CustomersController(ParaSqlDbContext dbContext, ICustomerService customerService)
        {
            this.dbContext = dbContext;
            _customerService = customerService;
        }


        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            var entityList1 = await dbContext.Set<Customer>().Include(x=> x.CustomerAddresses).Include(x=> x.CustomerPhones).Include(x=> x.CustomerDetail).ToListAsync();
            var entityList2 = await dbContext.Customers.Include(x=> x.CustomerAddresses).Include(x=> x.CustomerPhones).Include(x=> x.CustomerDetail).ToListAsync();
            return entityList1;
        }

        [HttpGet("{customerId}")]
        public async Task<Customer> Get(long customerId)
        {
            var entity = await dbContext.Set<Customer>().Include(x=> x.CustomerAddresses).Include(x=> x.CustomerPhones).Include(x=> x.CustomerDetail).FirstOrDefaultAsync(x => x.Id == customerId);
            return entity;
        }

        [HttpPost]
        public async Task Post([FromBody] Customer value)
        {
            var entity = await dbContext.Set<Customer>().AddAsync(value);
            await dbContext.SaveChangesAsync();
        }

        [HttpPut("{customerId}")]
        public async Task Put(long customerId, [FromBody] Customer value)
        {
            dbContext.Set<Customer>().Update(value);
            await dbContext.SaveChangesAsync();
        }

        [HttpDelete("{customerId}")]
        public async Task Delete(long customerId)
        {
            var entity = await dbContext.Set<Customer>().FirstOrDefaultAsync(x => x.Id == customerId);
            dbContext.Set<Customer>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
        [HttpGet("GetCustomersByName")]
        public async Task<List<Customer>> GetCustomersByNameAsync(string name)
        {

            return await _customerService.GetCustomersByNameAsync(name);
        }
    }
}