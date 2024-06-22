using InstNwnd.Web.Data.Models.EmployeeCrud;
using InstNwnd.Web.Data.Models.EmployeesCrud;

namespace InstNwnd.Web.Data.Interfaces
{
    public interface IEmployeesDb
    {
        List<EmployeesModels> GetEmployees();
        EmployeesModels GetEmployee(int employeeId);
        void SaveEmployee(EmployeesSaveModels saveEmployee);
        void UpdateEmployee(EmployeesUpdateModels updateEmployee);
        void RemoveEmployee(EmployeesRemoveModels removeEmployee);
    }
}
