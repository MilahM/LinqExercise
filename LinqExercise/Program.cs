﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Sockets;


namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers - DONE

            int sum = numbers.Sum();
            Console.WriteLine($"The sum of the numbers in the array is: {sum}");

            //TODO: Print the Average of numbers - DONE

            double avg = numbers.Average();
            Console.WriteLine($"The average of the numbers in the array is: {avg}");

            //TODO: Order numbers in ascending order and print to the console - DONE

            var numbersArray = numbers.OrderBy(n => n);

            foreach (var n in numbersArray)
            {
                Console.WriteLine($"Numbers array in ascending order : {n}");
            }

            //TODO: Order numbers in decsending order and print to the console - DONE

            var descOrder = numbers.OrderByDescending(n => n);

            foreach (var n in descOrder)
            {
                Console.WriteLine($"Numbers in array in descending order: {n}");
            }

            //TODO: Print to the console only the numbers greater than 6 - DONE

            var numsGreater = numbers.Where(n => n > 6);

            foreach (var n in numsGreater)
            {
                Console.WriteLine($"Here are the numbers from the array that are greater than 6: {n}");
            }

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!** - DONE

            var nums = numbersArray.Take(4);

            foreach (var n in nums)
            {
                Console.WriteLine(n);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order - DONE

            numbers[4] = 27;

            var num = numbers.OrderByDescending(n => n);

            foreach (var n in num)
            {
                Console.WriteLine($"Numbers in ascending order: {n}");
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName. - DONE

            var names = employees.Where(name => name.FirstName.StartsWith('C') || name.FirstName.StartsWith('S')).OrderBy(name => name.FirstName);

            foreach (var name in names)
            {
                Console.WriteLine(name.FirstName);
            }


            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result. - DONE

            var fullName = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);

            foreach (var x in fullName)
            {
                Console.WriteLine($"Age: {x.Age} Name: {x.FullName}");
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35. - DONE

            var years = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience);

            var avgYOE = employees.Average(x => x.YearsOfExperience);

            Console.WriteLine($"YOE Sum: {years} YOE Average: {avgYOE}");

            //TODO: Add an employee to the end of the list without using employees.Add() - DONE

            var addEmployee = employees.Append(new Employee("jane", "doe", 37, 13)).ToList();

            foreach (var employee in addEmployee)
            {
                Console.WriteLine($"New Employee: {employee.FirstName} {employee.LastName}");
            }



            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
