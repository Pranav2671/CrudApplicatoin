using System.Collections.Generic;
using System.Threading.Tasks;
using CrudApplicatoin.Models;

namespace CrudApplicatoin.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(int id);
    }
}
