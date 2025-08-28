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
    public class DepartmentController
    {
        private readonly IDepartmentService _deparmentService;
        public DepartmentController()
        {
            _deparmentService = new DepartmentService();
        }

        public async Task CreateAsync()
        {
        Name:
            try
            {
                Console.WriteLine("Please Enter the Departmen Name: ");
                string depName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(depName))
                {
                    Console.WriteLine("Please Enter the Departmen Name: ");
                    goto Name;
                }
                depName = depName.Replace(" ", "");

                if (!Regex.IsMatch(depName, "^[a-zA-Z0-9]+$"))
                {
                    Console.WriteLine("The Name isn't Correct, Please Enter Again!");
                    goto Name;
                }

                var existDep = await _deparmentService.SearchAsync(depName);
                if (existDep != null && existDep.Any(d => d.Name.Equals(depName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("This Department Name is Already Exist! Please Enter Another Name.");
                    goto Name;
                }

                Console.WriteLine("Please Enter the Department Capacity: ");
            Cap: string depCap = Console.ReadLine();
                bool isCorrect = int.TryParse(depCap, out int givenCap);
                if (!isCorrect)
                {
                    Console.WriteLine("Capacity Format is Wrong, Please Enter Again!");
                    goto Cap;
                }
                if (string.IsNullOrWhiteSpace(depCap))
                {
                    Console.WriteLine("Please Enter the Department Capaity!");
                    goto Cap;
                }
                if (givenCap <= 0)
                {
                    Console.WriteLine("Department Capacity can't be Negative or Zero!");
                    goto Cap;
                }

                var department = new Department
                {
                    Name = depName,
                    Capacity = givenCap
                };

                await _deparmentService.CreateAsync(department);
                Console.WriteLine("Department Created Successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Name;
            }
        }



        public async Task DeleteAsync()
        {
        Delete:
            try
            {
                Console.WriteLine("Please Enter the Id!");
                string delId = Console.ReadLine();
                bool isInt = int.TryParse(delId, out int givenInt);
                if (!isInt)
                {
                    Console.WriteLine("Department Id's Format is Wrong! Please Try Again.");
                    goto Delete;
                }
                if (string.IsNullOrWhiteSpace(delId))
                {
                    Console.WriteLine("Please Enter the Id!");
                    goto Delete;
                }
                if (givenInt <= 0)
                {
                    Console.WriteLine("Department Id can't be Negative or Zero!");
                    goto Delete;
                }

                var deletedDep = _deparmentService.GetByIdAsync(givenInt);

                if (deletedDep == null)
                {
                    Console.WriteLine("Department not Found!");
                    goto Delete;
                }
                await _deparmentService.DeleteAsync(givenInt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Delete;
            }
        }

        public async Task GetAllAsync()
        {
            IEnumerable<Department> departments = await _deparmentService.GetAllAsync();
            if (departments == null || !departments.Any())
            {
                Console.WriteLine("Department can't Found!");
                return;
            }
            foreach (var item in departments)
            {
                string depart = ($"Id: {item.Id} - Name: {item.Name} - Capacity: {item.Capacity}");
                Console.WriteLine(depart);
            }
        }

        public async Task GetById()
        {
        Id:
            try
            {
                Console.WriteLine("Please Enter the Id!");
                string exId = Console.ReadLine();
                bool isInt = int.TryParse(exId, out int nextId);
                if (!isInt)
                {
                    Console.WriteLine("Department Id's Format is Wrong! Please Try Again.");
                    goto Id;
                }
                if (string.IsNullOrWhiteSpace(exId))
                {
                    Console.WriteLine("Please Enter the Id!");
                    goto Id;
                }
                if (nextId <= 0)
                {
                    Console.WriteLine("Department Id can't be Negative or Zero!");
                    goto Id;
                }

                await _deparmentService.GetByIdAsync(nextId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Id;
            }

        }


        public async Task SearchAsync()
        {
            while (true)
            {
                Console.WriteLine("Please Enter Name for Search: ");
                string searchName = Console.ReadLine();

                try
                {
                    if (string.IsNullOrWhiteSpace(searchName))
                    {
                        IEnumerable<Department> department = await _deparmentService.GetAllAsync();

                        if (department == null || department.Any())
                        {
                            Console.WriteLine("Department Not Found!");
                            continue;
                        }

                        foreach (var item in department)
                        {
                            string final = ($"Id: {item.Id} - Name: {item.Name} - Capacity: {item.Capacity}");
                            Console.WriteLine(final);
                        }
                    }
                    else
                    {
                        IEnumerable<Department> department = await _deparmentService.SearchAsync(searchName);

                        if (department == null || department.Any())
                        {
                            Console.WriteLine("Department not Found with the Given Name.");
                            continue;
                        }
                        else
                        {
                            foreach (var item in department)
                            {
                                string final = ($"Id: {item.Id} - Name: {item.Name} - Capacity: {item.Capacity}");
                                Console.WriteLine(final);
                            }
                        }
                    }

                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }

        public async Task UpdateDepartmentAsync()
        {
        top:

            try
            {
                Console.WriteLine("Please Enter the Department Id:");
                string Id = Console.ReadLine();
                int givenId;

                bool isTrueFormat = int.TryParse(Id, out givenId);
                if (!isTrueFormat)
                {
                    Console.WriteLine("Id Format is Wrong!");
                    goto top;
                }
                if (givenId <= 0)
                {
                    Console.WriteLine("Id can't be Negative!");
                    goto top;
                }
                var existingDepartment = await _deparmentService.GetByIdAsync(givenId);
                if (existingDepartment == null)
                {
                    Console.WriteLine("Department not Found!");
                    goto top;
                }
                Console.WriteLine($"Current department name is {existingDepartment.Name}");

            nameUpdate:
                Console.WriteLine("Please Enter the New Name: ");
                string newName = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    newName = existingDepartment.Name;
                }

                var existingDepartments = await _deparmentService.SearchAsync(newName);
                if (existingDepartments != null && existingDepartments.Any(d => d.Name.Equals(newName, StringComparison.OrdinalIgnoreCase) && d.Id != existingDepartment.Id))
                {
                    Console.WriteLine("This Department Name is Already Exist! Please Enter Another one: ");
                    goto nameUpdate;
                }
            capacityUpdate:
                Console.WriteLine($"Current capacity is: {existingDepartment.Capacity}");
                Console.WriteLine("Please Enter the New Capacity");

                string newCapacityInput = Console.ReadLine();
                int givencapacity;
                bool isCorrect = int.TryParse(newCapacityInput, out givencapacity);
                if (!isCorrect)
                {
                    Console.WriteLine("Capacity Format ia Wrong! Please Insert Again: ");
                    goto capacityUpdate;
                }

                if (string.IsNullOrWhiteSpace(newCapacityInput))
                {
                    newCapacityInput = existingDepartment.Capacity.ToString();
                }



                if (givencapacity <= 0)
                {
                    Console.WriteLine("Capacity Must be a Positive Number!");
                    goto capacityUpdate;
                }

                existingDepartment.Name = newName;
                existingDepartment.Capacity = givencapacity;

                await _deparmentService.UpdateDepartmentAsync(givenId, existingDepartment);
                Console.WriteLine("Department Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto top;
            }
        }
    }
}
