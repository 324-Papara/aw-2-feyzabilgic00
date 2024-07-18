using Para.Data.Domain;
namespace Para.Bussiness.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomersByNameAsync(string name);
    Task<List<Customer>> GetCustomersWithIncludesAsync();
}
