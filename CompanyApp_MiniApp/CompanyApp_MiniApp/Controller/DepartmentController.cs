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
        
        public async Task CreateAsyn()
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
            }
            catch (Exception)
            {

                throw;
            }
        } 
    }

}
