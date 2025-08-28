using Domain.Entities;
using Service.Services;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyApp_MiniApp.Controller
{
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
        }

        public async Task CreateAsync()
        {
            Console.WriteLine("Please Enter the Name: ");
        Name: string givenName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(givenName))
            {
                Console.WriteLine("Please Enter the Name!");
                goto Name;
            }

            givenName = givenName.Replace(" ", "");

            if (!Regex.IsMatch(givenName, "^[a-zA-Z]+$"))
            {
                Console.WriteLine("The Name isn't Correct, Please Enter Again!");
                goto Name;
            }


            Console.WriteLine("Please Enter the Surname: ");
        Surname: string givenSurname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(givenSurname))
            {
                Console.WriteLine("Please Enter the Surname!");
                goto Surname;
            }

            givenSurname = givenSurname.Replace(" ", "");

            if (!Regex.IsMatch(givenSurname, "^[a-zA-Z]+$"))
            {
                Console.WriteLine("The Surname isn't Correct, Please Enter Again!");
                goto Surname;
            }

            Console.WriteLine("Please Enter the Age: ");
        Age: string givenAge = Console.ReadLine();
            bool isTrue = int.TryParse(givenAge, out int newAge);
            if (string.IsNullOrWhiteSpace(givenAge))
            {
                Console.WriteLine("Please Enter the Age!");
                goto Age;
            }
            if (!isTrue)
            {
                Console.WriteLine("False Age Format");
                goto Age;
            }
            if (newAge < 18 || newAge > 65)
            {
                Console.WriteLine("The age should be 18 and 65!");
                goto Age;
            }


            Console.WriteLine("Enter the Address: ");
        adres: string givenAddress = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(givenAddress))
            {
                Console.WriteLine("Please Enter the Address!");
                goto adres;
            }

            Console.WriteLine("Please Choose the Department Id: ");
        New: string givenId = Console.ReadLine();
            try
            {
                bool isCorrect = int.TryParse(givenId, out int newId);
                if (!isCorrect)
                {
                    Console.WriteLine("Please Enter the Id Again!");
                    goto New;
                }
                if (newId < 0)
                {
                    Console.WriteLine("Id Can't Be Negative!");
                    goto New;
                }
                if (string.IsNullOrWhiteSpace(givenId))
                {
                    Console.WriteLine("Please Enter the Id!");
                    goto New;
                }

                var department = await _departmentService.GetByIdAsync(newId);
                if (department==null)
                {
                    Console.WriteLine("Department can't be Found!");
                }

                var employee = new Employee
                {
                    DepartmentId = department.Id,
                    Name = givenName,
                    Surname = givenSurname,
                    Age = newAge,
                    Address = givenAddress,
                };

                await _employeeService.CreateAsync(employee);
                Console.WriteLine("Employee Created Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto New;
            }
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Please Enter the Id: ");
        delete: string idForDelete = Console.ReadLine();

            try
            {
                bool isTrueId = int.TryParse(idForDelete, out int deletedId);

                if (!isTrueId)
                {
                    Console.WriteLine("Please Enter a Valid Numeric Id!");
                    goto delete;
                }

                if (deletedId <= 0)
                {
                    Console.WriteLine("Id can't be Negative!");
                    goto delete;
                }

                if (string.IsNullOrWhiteSpace(idForDelete))
                {
                    Console.WriteLine("Please Enter the Id!");
                    goto delete;
                }

                var employee = await _employeeService.GetByIdAsync(deletedId);

                if (employee == null)
                {
                    Console.WriteLine("Employee not found!");
                    goto delete;
                }

                await _employeeService.DeleteAsync(deletedId);
                Console.WriteLine("Employee Deleted Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto delete;
            }
        }




        public async Task GetByIdAsync()
        {
            Console.WriteLine("Please Enter the Id!");
        GetId: string idForGet = Console.ReadLine();
            try
            {
                bool trueId = int.TryParse(idForGet, out int getId);
                if (!trueId)
                {
                    Console.WriteLine("Please Enter the Id Again!");
                    goto GetId;
                }
                if (getId < 0)
                {
                    Console.WriteLine("Id Can't Be Negative!");
                    goto GetId;
                }
                if (string.IsNullOrWhiteSpace(idForGet))
                {
                    Console.WriteLine("Please Enter the Id!");
                    goto GetId;
                }

                var employee = await _employeeService.GetByIdAsync(getId);
                if (employee == null)
                {
                    Console.WriteLine("Employee can't Found!");
                    goto GetId;
                }

                string data = ($"Id: {employee.Id} - Name: {employee.Name} - Surname: {employee.Surname} - Age: {employee.Age} - Adress: {employee.Address} - Department: {employee.Department.Name}");
                Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto GetId;
            }
        }



        public async Task GetAllAsync()
        {
            IEnumerable<Employee> employees =await _employeeService.GetAllAsync();

            if (employees == null || !employees.Any())
            {
                Console.WriteLine("Employee Not Found!");
                return;
            }

            foreach (Employee item in employees)
            {
                string result = ($"Id: {item.Id} - Name: {item.Name} - Surname: {item.Surname} - Age: {item.Age} - Adress: {item.Address} - Department: {item.Department.Name}");
                Console.WriteLine(result);
            }
        }

        public async Task GetAllEmployeesByAgeAsync()
        {
            Console.WriteLine("Please Enter the Age: ");
        GetAge: string checkAge = Console.ReadLine();
            try
            {
                bool isAge = int.TryParse(checkAge, out int intAge);
                if (!isAge)
                {
                    Console.WriteLine("Please Enter the Age Again!");
                    goto GetAge;
                }
                if (string.IsNullOrWhiteSpace(checkAge))
                {
                    Console.WriteLine("Please Enter the Age");
                    goto GetAge;
                }
                IEnumerable<Employee> employees = await _employeeService.GetAllEmployeesByAgeAsync(intAge);
                if (employees == null || !employees.Any())
                {
                    Console.WriteLine("Employee Not Found!");
                    goto GetAge;
                }
                foreach (var item in employees)
                {
                    string result = ($"Id: {item.Id} - Name: {item.Name} - Surname: {item.Surname} - Age: {item.Age} - Adress: {item.Address} - Department: {item.Department.Name}");
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto GetAge;
            }
        }

        public async Task GetEmployeeByDepartmentIdAsync()
        {
            Console.WriteLine("Please Enter the Department Id: ");
        DepId: string checkId = Console.ReadLine();
            try
            {
                bool isIntId = int.TryParse(checkId, out int intId);
                if (!isIntId)
                {
                    Console.WriteLine("Please Enter Id Again!");
                    goto DepId;
                }
                if (intId < 0)
                {
                    Console.WriteLine("Id Can't Be Negative!");
                    goto DepId;
                }
                if (string.IsNullOrWhiteSpace(checkId))
                {
                    Console.WriteLine("Please Enter the Id!");
                    goto DepId;
                }

                IEnumerable<Employee> employees = await _employeeService.GetEmployeeByDepartmentIdAsync(intId);
                if (employees == null || !employees.Any())
                {
                    Console.WriteLine("Employee Not Found!");
                    goto DepId;
                }
                foreach (var item in employees)
                {
                    string res = ($"Id: {item.Id} - Name: {item.Name} - Surname: {item.Surname} - Age: {item.Age} - Adress: {item.Address} - Department: {item.Department.Name}");
                    Console.WriteLine(res);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto DepId;
            }
        }
        public async Task GetEmployeesByDepartmentNameAsync()
        {
            Console.WriteLine("Please Enter the Department Name: ");
        DepN: string depName = Console.ReadLine();
            try
            {
                if (string.IsNullOrWhiteSpace(depName))
                {
                    Console.WriteLine("Please Enter the Department Id!");
                    goto DepN;
                }
                if (!Regex.IsMatch(depName, "^[a-zA-Z]+$"))
                {
                    Console.WriteLine("The Name isn't Correct, Please Enter Again!");
                    goto DepN;
                }

                IEnumerable<Employee> employees = await _employeeService.GetEmployeesByDepartmentNameAsync(depName);
                if (employees == null || !employees.Any())
                {
                    Console.WriteLine("Employee Not Found!");
                }
                foreach (var item in employees)
                {
                    var emp = ($"Id: {item.Id} - Name: {item.Name} - Surname: {item.Surname} - Age: {item.Age} - Adress: {item.Address} - Department: {item.Department.Name}");
                    Console.WriteLine(emp);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto DepN;
            }
        }


        public async Task SearchByNameOrSurnameAsync()
        {
            Console.WriteLine("Please Enter the Name or Surname: ");
        search: string Str = Console.ReadLine();
            try
            {
                if (string.IsNullOrWhiteSpace(Str))
                {
                    IEnumerable<Employee> employees = await _employeeService.GetAllAsync();
                    if (employees == null || !employees.Any())
                    {
                        Console.WriteLine("No Employees Found!");
                        goto search;
                    }

                    foreach (var item in employees)
                    {
                        var emp = ($"Id: {item.Id} - Name: {item.Name} - Surname: {item.Surname} - Age: {item.Age} - Address: {item.Address} - Department: {item.Department.Name}");
                        Console.WriteLine(emp);
                    }
                }
                else
                {
                    if (!Regex.IsMatch(Str, "^[a-zA-Z]+$"))
                    {
                        Console.WriteLine("The Name or Surname aren't Correct, Please Enter Again!");
                        goto search;
                    }

                    IEnumerable<Employee> employees = await _employeeService.SearchByNameOrSurnameAsync(Str);
                    if (employees == null || !employees.Any())
                    {
                        Console.WriteLine("No Employee Found with the given Name or Surname.");
                        Console.WriteLine("Please Enter a valid Name or Surname again.");
                        goto search;
                    }

                    foreach (var item in employees)
                    {
                        var emp = ($"Id: {item.Id} - Name: {item.Name} - Surname: {item.Surname} - Age: {item.Age} - Address: {item.Address} - Department: {item.Department.Name}");
                        Console.WriteLine(emp);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto search;
            }
        }

        public async Task GetCountAsync()
        {
            var count = await _employeeService.GetCountAsync();
            Console.WriteLine($"Employees Count: {count}");
        }


        public async Task SortEmployeesByAgeAsync()
        {
            while (true)
            {
                Console.WriteLine("Sort by Age: ASC/DESC");
                string choice = Console.ReadLine().ToUpper();

                IEnumerable<Employee> employees = await _employeeService.GetAllAsync();

                if (employees == null || !employees.Any())
                {
                    Console.WriteLine("Employee Not Found!");
                    return;
                }

                if (choice == "ASC")
                {
                    var res = await _employeeService.SortEmployeesByAgeAsync("ASC");
                    foreach (var emp in res)
                    {
                        Console.WriteLine($"Id: {emp.Id} - Name: {emp.Name} - Surname: {emp.Surname} - Age: {emp.Age} - Address: {emp.Address} - Department: {emp.Department.Name}");
                    }
                    break;
                }
                else if (choice == "DESC")
                {
                    var res = await _employeeService.SortEmployeesByAgeAsync("DESC");
                    foreach (var emp in res)
                    {
                        Console.WriteLine($"Id: {emp.Id} - Name: {emp.Name} - Surname: {emp.Surname} - Age: {emp.Age} - Address: {emp.Address} - Department: {emp.Department.Name}");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter either 'ASC' or 'DESC' to sort.");
                }
            }
        }


    }
}
