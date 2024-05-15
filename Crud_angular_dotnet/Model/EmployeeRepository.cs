using Microsoft.EntityFrameworkCore;

namespace Crud_angular_dotnet.Model
{
    public class EmployeeRepository
    {
        private readonly DatabaseContext _databaseContext;

        public EmployeeRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task AddEmployee(Employee employee)
        {
            await _databaseContext.Set<Employee>().AddAsync(employee);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<List<Employee>> GetEmployee()
        {
          return await _databaseContext.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _databaseContext.Employees.FindAsync(id);
        }
        public async Task UpdateEmployee(int id,Employee model)
        {
            var employee= await _databaseContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found"); 
            }
            employee.Name = model.Name;
            employee.Phone = model.Phone;
            employee.Age = model.Age;
            employee.Salary = model.Salary;
            await _databaseContext.SaveChangesAsync();           
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _databaseContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            _databaseContext.Employees.Remove(employee);
            await _databaseContext.SaveChangesAsync();

        }

    }
}
