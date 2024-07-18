using Microsoft.AspNetCore.Mvc;
using Para.Data.Domain;
using Para.Data.UnitOfWork;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers2Controller : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public Customers2Controller(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            var entityList = await unitOfWork.Customers.GetAll();
            return entityList;
        }

        [HttpGet("{customerId}")]
        public async Task<Customer> Get(long customerId)
        {
            var entity = await unitOfWork.Customers.GetById(customerId);
            return entity;
        }

        [HttpPost]
        public async Task Post([FromBody] Customer value)
        {
            await unitOfWork.Customers.Insert(value);
            await unitOfWork.Customers.Insert(value);
            await unitOfWork.Customers.Insert(value);
            await unitOfWork.Complete();
        }

        [HttpPut("{customerId}")]
        public async Task Put(long customerId, [FromBody] Customer value)
        {
            await unitOfWork.Customers.Update(value);
            await unitOfWork.Complete();
        }

        [HttpDelete("{customerId}")]
        public async Task Delete(long customerId)
        {
            await unitOfWork.Customers.Delete(customerId);
            await unitOfWork.Complete();
        }
    }
}