using Para.Data.Domain;
using Para.Data.UnitOfWork;
using System.Linq.Expressions;

namespace Para.Bussiness.Services;

public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<Customer>> GetCustomersWithIncludesAsync()
    {
        var customers = _unitOfWork.Customers
            .IncludeAsync(x => x.CustomerAddresses, x => x.CustomerPhones);

        return await customers;
    }

    public async Task<List<Customer>> GetCustomersByNameAsync(string name)
    {
        return await _unitOfWork.Customers.WhereAsync(x => x.FirstName == name);
    }
}
