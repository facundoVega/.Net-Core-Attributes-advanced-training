#define LOG_INFO
using AttributesExamples.Models;
using LogginComponent;
using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValidationComponent;

[assembly: AssemblyDescription("My Assembly Description")]

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            Department dept = new Department();

            string empId = null;
            string firstName = null;
            string postCode = null;
            string deptShortName = null;



            Type employeeType = typeof(Employee);
            Type departmentType = typeof(Department);


            if (GetInput(employeeType, "Please enter the employee's id", "Id", out empId ))
            {
                emp.Id = Int32.Parse(empId);
            }

            if (GetInput(employeeType, "Please enter the employee's first name", "FirstName", out firstName))
            {
                emp.FirstName = firstName;
            }

            if (GetInput(employeeType, "Please enter the employee's post code", "PostCode", out postCode))
            {
                emp.PostCode = postCode;
            }
            if (GetInput(departmentType, "Please enter the department's long name", "DeptShortName", out deptShortName))
            {
                dept.DeptShortName = deptShortName;
            }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Thank you! Employee with first name, { emp.FirstName } and Id {emp.Id} has been entered successfully!!");
            Console.ResetColor();

            Console.ReadKey();

            var employeeJSON = JsonSerializer.Serialize<Employee>(emp);

            Console.WriteLine(employeeJSON);
        }

        private static bool GetInput(Type t , string promptText, string fieldName, out string fieldValue)
        {
            fieldValue = "";
            string enteredValue = "";
            string errorMessage = null;


            do
            {
                Console.WriteLine(promptText);
                enteredValue = Console.ReadLine();

                if (!Validation.PropertyValueIsValid(t, enteredValue, fieldName, out errorMessage))
                {
                    fieldValue = null;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(errorMessage);
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    fieldValue = enteredValue;
                    break;
                }
            }
            while (true);


            return true;
        }
        private static void OutputGlobalAttributeInformation()
        {
            Assembly thisAssem = typeof(Program).Assembly;

            AssemblyName thisAssemName = thisAssem.GetName();

            Version thisAssemVersion = thisAssemName.Version;

            object[] attributes = thisAssem.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);

            var thisAssemDescriptionAttribute = attributes[0] as AssemblyDescriptionAttribute;

            Console.WriteLine($"Assembly Name: {thisAssemName}");
            Console.WriteLine($"Assembly Version: {thisAssemVersion}");

            if (thisAssemDescriptionAttribute != null)
                Console.WriteLine($"Assembly Descrpition: {thisAssemDescriptionAttribute.Description}");
        }
    }
}