using TestWebApiUsingEF.Models;
using TestWebApiUsingEF.ViewModels;

namespace TestWebApiUsingEF.Services
{
    public interface IEmployeeService
    {
        List<Employees> GetAllEmployees();
        Employees GetEmployeeById(int id);
        ResponseModel SaveEmployee(Employees employee);
        ResponseModel DeleteEmployeeById(int id);

    }
}
