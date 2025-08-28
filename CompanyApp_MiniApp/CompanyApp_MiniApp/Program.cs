using CompanyApp_MiniApp.Controller;
using Service.Helpers.Enums;

Console.WriteLine("Hello, World!");


DepartmentController departmentController = new DepartmentController();
EmployeeController employeeController = new EmployeeController();

while (true)
{
    ShowMenu();

Operation1: string operationStr1 = Console.ReadLine();
    bool isCorrectOperation = int.TryParse(operationStr1, out int result);
    if (isCorrectOperation)
    {
        switch (result)
        {
            case (int)Operations.DepartmentCreate:
                await departmentController.CreateAsync();
                break;
            case (int)Operations.DepartmenDelete:
               await departmentController.DeleteAsync();
                break;
            case (int)Operations.DepartmentById:
               await departmentController.GetByIdAsync();
                break;
            case (int)Operations.DepartmentGetAll:
                await departmentController.GetAllAsync();
                break;
            case (int)Operations.DepartmentSearch:
                await departmentController.SearchAsync();
                break;
            case (int)Operations.DepartmentUpdate:
                await departmentController.UpdateDepartmentAsync();
                break;
            case (int)Operations.EmployeeCreate:
                await employeeController.CreateAsync();
                break;
            case (int)Operations.EmployeeDelete:
                await employeeController.DeleteAsync();
                break;
            case (int)Operations.EmployeeById:
                await employeeController.GetByIdAsync();
                break;
            case (int)Operations.EmployeeGetAll:
                await employeeController.GetAllAsync();
                break;
            case (int)Operations.EmployeesByAge:
                await employeeController.GetByIdAsync();
                break;
            case (int)Operations.EmployeeByDepartmentId:
                await employeeController.GetEmployeeByDepartmentIdAsync();
                break;
            case (int)Operations.EmployeeByDepartmentName:
                await employeeController.GetEmployeesByDepartmentNameAsync();
                break;
            case (int)Operations.EmployeeSearch:
                await employeeController.SearchByNameOrSurnameAsync();
                break;
            case (int)Operations.EmployeesCount:
                await employeeController.GetCountAsync();
                break;
            case (int)Operations.EmployeesSortAge:
                await employeeController.SortEmployeesByAgeAsync();
                break;
            
            default:
                Console.WriteLine("Operation Not Found, Please Select Again:");
                goto Operation1;
        }
    }
    else
    {
        Console.WriteLine("Operation Format is Wrong, Please Add Again :");
        goto Operation1;
    }
}





void ShowMenu()
{
    Console.WriteLine("========== MENU ==========");

    Console.WriteLine("1  - Create Department");
    Console.WriteLine("2  - Delete Department");
    Console.WriteLine("3  - Get Department by ID");
    Console.WriteLine("4  - Get All Departments");
    Console.WriteLine("5  - Search Department by Name");
    Console.WriteLine("6 - Update Department");
    Console.WriteLine("7  - Create Employee");
    Console.WriteLine("8  - Delete Employee");
    Console.WriteLine("9  - Get Employee by ID");
    Console.WriteLine("10  - Get All Employees");
    Console.WriteLine("11 - Get Employees by Age");
    Console.WriteLine("12 - Get Employees by Department ID");
    Console.WriteLine("13 - Get Employees by Department Name");
    Console.WriteLine("14 - Search Employee by Name or Surname");
    Console.WriteLine("15 - Get Employees Count");
    Console.WriteLine("16 - Sort Employees by Age");


    Console.WriteLine("===========================");
}