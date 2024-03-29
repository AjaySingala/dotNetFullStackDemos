﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpClientSample
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowEmployee(Employee employee)
        {
            Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}\t" +
                $"Phone: {employee.PhoneNumber}");
        }

        static async Task<Uri> CreateEmployeeAsync(Employee employee)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/employee", employee);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<Employee> GetEmployeeAsync(string path)
        {
            Employee employee = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }
            return employee;
        }

        static async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/employee/{employee.EmployeeId}", employee);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated employee from the response body.
            employee = await response.Content.ReadAsAsync<Employee>();
            return employee;
        }

        static async Task<HttpStatusCode> DeleteEmployeeAsync(long id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/employee/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7054/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new employee
                Employee employee = new Employee
                {
                    FirstName = "Mary",
                    LastName = "Jane",
                    Email = "mjane@gmail.com",
                    DateOfBirth = new DateTime(1982, 05, 21),
                    PhoneNumber = "555-777-8888",
                    Gender = "Female"
                };

                var url = await CreateEmployeeAsync(employee);
                Console.WriteLine($"Created at {url}");

                // Get the employee
                employee = await GetEmployeeAsync(url.PathAndQuery);
                ShowEmployee(employee);

                // Update the employee
                Console.WriteLine("Updating phone number...");
                employee.PhoneNumber = "555-555-8888";
                await UpdateEmployeeAsync(employee);

                // Get the updated employee
                employee = await GetEmployeeAsync(url.PathAndQuery);
                ShowEmployee(employee);

                Console.WriteLine("Employee record created. Please check in DB...");
                Console.WriteLine("Press <ENTER> to Delete this record...");
                Console.ReadLine();

                // Delete the employee
                var statusCode = await DeleteEmployeeAsync(employee.EmployeeId);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}