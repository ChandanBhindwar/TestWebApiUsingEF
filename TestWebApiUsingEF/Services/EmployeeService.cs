using TestWebApiUsingEF.Models;
using TestWebApiUsingEF.ViewModels;

namespace TestWebApiUsingEF.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmpContext _context;

        public EmployeeService(EmpContext empContext)
        {
            _context = empContext;
        }


        public List<Employees> GetAllEmployees()
        {
            List<Employees> empList;
            try
            {
                empList = _context.Set<Employees>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return empList;
        }

        public Employees GetEmployeeById(int empId)
        {
            Employees? emp;
            try
            {
                emp = _context.Find<Employees>(empId);
            }
            catch (Exception)
            {

                throw;
            }
            return emp;
        }
        public ResponseModel DeleteEmployeeById(int id)
        {
            ResponseModel model = new ResponseModel();

            try
            {
                Employees _temp = GetEmployeeById(id);
                if (_temp != null)
                {
                    _context.Remove<Employees>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Message = "Employee Deleted SuccessFully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Message = "Employee Not Found";
                }
            }
            catch (Exception ex)
            {

                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel SaveEmployee(Employees employee)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Employees _temp = GetEmployeeById(employee.EmployeeId);
                if (_temp != null)
                {
                    _temp.Designation = employee.Designation;
                    _temp.Salary = employee.Salary;
                    _temp.FirstName = employee.FirstName;
                    _temp.LastName = employee.LastName;
                    _context.Update<Employees>(_temp);
                    model.Message = "Employee Updated Successfully";
                }
                else
                {
                    _context.Add<Employees>(employee);
                    model.Message = "Employee Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Message = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
