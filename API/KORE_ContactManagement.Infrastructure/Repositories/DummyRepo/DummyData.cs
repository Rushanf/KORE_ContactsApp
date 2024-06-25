using KORE_ContactManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Infrastructure.Repositories.DummyRepo
{
    internal class DummyData
    {        
        public static List<Contact> contacts = new List<Contact>
            {
                new Contact { Id = 1, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@sample.org", PhoneNumber = "992-587-8952", Title = "Senior Developer", MiddleInitial = "P" },
                new Contact { Id = 2, FirstName = "Daniel", LastName = "Garcia", Email = "daniel.garcia@example.com", PhoneNumber = "283-269-4350", Title = "DevOps Engineer", MiddleInitial = "M" },
                new Contact { Id = 3, FirstName = "David", LastName = "Miller", Email = "david.miller@demo.net", PhoneNumber = "700-969-6445", Title = "Project Manager", MiddleInitial = "S" },
                new Contact { Id = 4, FirstName = "Olivia", LastName = "Miller", Email = "olivia.miller@test.com", PhoneNumber = "933-882-2548", Title = "Project Manager", MiddleInitial = "Y" },
                new Contact { Id = 5, FirstName = "Sophia", LastName = "Williams", Email = "sophia.williams@test.com", PhoneNumber = "296-959-8166", Title = "DevOps Engineer", MiddleInitial = "T" },
                new Contact { Id = 6, FirstName = "John", LastName = "Jones", Email = "john.jones@sample.org", PhoneNumber = "596-462-3105", Title = "Project Manager", MiddleInitial = "J" },
                new Contact { Id = 7, FirstName = "Olivia", LastName = "Williams", Email = "olivia.williams@example.com", PhoneNumber = "933-965-1745", Title = "Quality Assurance", MiddleInitial = "J" },
                new Contact { Id = 8, FirstName = "Daniel", LastName = "Jones", Email = "daniel.jones@example.com", PhoneNumber = "466-938-4718", Title = "Software Engineer", MiddleInitial = "W" },
                new Contact { Id = 9, FirstName = "Sophia", LastName = "Jones", Email = "sophia.jones@example.com", PhoneNumber = "215-305-9285", Title = "Senior Developer", MiddleInitial = "C" },
                new Contact { Id = 10, FirstName = "David", LastName = "Johnson", Email = "david.johnson@test.com", PhoneNumber = "652-495-9157", Title = "Quality Assurance", MiddleInitial = "G" },
                new Contact { Id = 11, FirstName = "Michael", LastName = "Garcia", Email = "michael.garcia@sample.org", PhoneNumber = "156-951-2740", Title = "Senior Developer", MiddleInitial = "R" },
                new Contact { Id = 12, FirstName = "John", LastName = "Williams", Email = "john.williams@demo.net", PhoneNumber = "857-764-9810", Title = "Software Engineer", MiddleInitial = "D" },
                new Contact { Id = 13, FirstName = "James", LastName = "Miller", Email = "james.miller@sample.org", PhoneNumber = "371-368-1629", Title = "Data Analyst", MiddleInitial = "H" },
                new Contact { Id = 14, FirstName = "Emily", LastName = "Martinez", Email = "emily.martinez@test.com", PhoneNumber = "427-734-9852", Title = "DevOps Engineer", MiddleInitial = "F" },
                new Contact { Id = 15, FirstName = "Jane", LastName = "Williams", Email = "jane.williams@demo.net", PhoneNumber = "708-165-7284", Title = "Project Manager", MiddleInitial = "X" },
                new Contact { Id = 16, FirstName = "Sophia", LastName = "Davis", Email = "sophia.davis@demo.net", PhoneNumber = "334-785-9471", Title = "Senior Developer", MiddleInitial = "M" },
                new Contact { Id = 17, FirstName = "James", LastName = "Smith", Email = "james.smith@test.com", PhoneNumber = "798-645-3219", Title = "Quality Assurance", MiddleInitial = "Z" },
                new Contact { Id = 18, FirstName = "Olivia", LastName = "Smith", Email = "olivia.smith@demo.net", PhoneNumber = "953-438-5029", Title = "Data Analyst", MiddleInitial = "K" },
                new Contact { Id = 19, FirstName = "Michael", LastName = "Garcia", Email = "michael.garcia@test.com", PhoneNumber = "514-279-6432", Title = "Software Engineer", MiddleInitial = "T" },
                new Contact { Id = 20, FirstName = "Sophia", LastName = "Johnson", Email = "sophia.johnson@demo.net", PhoneNumber = "409-482-7104", Title = "Quality Assurance", MiddleInitial = "E" },
                new Contact { Id = 21, FirstName = "David", LastName = "Brown", Email = "david.brown@sample.org", PhoneNumber = "716-498-3942", Title = "Data Analyst", MiddleInitial = "P" },
                new Contact { Id = 22, FirstName = "John", LastName = "Garcia", Email = "john.garcia@test.com", PhoneNumber = "596-458-1237", Title = "Quality Assurance", MiddleInitial = "V" },
                new Contact { Id = 23, FirstName = "Emily", LastName = "Jones", Email = "emily.jones@test.com", PhoneNumber = "167-283-5973", Title = "Project Manager", MiddleInitial = "J" },
                new Contact { Id = 24, FirstName = "James", LastName = "Brown", Email = "james.brown@sample.org", PhoneNumber = "819-763-4523", Title = "Data Analyst", MiddleInitial = "N" },
                new Contact { Id = 25, FirstName = "Emma", LastName = "Johnson", Email = "emma.johnson@demo.net", PhoneNumber = "692-457-8340", Title = "Project Manager", MiddleInitial = "R" },
                new Contact { Id = 26, FirstName = "Daniel", LastName = "Williams", Email = "daniel.williams@demo.net", PhoneNumber = "870-469-1723", Title = "Software Engineer", MiddleInitial = "A" },
                new Contact { Id = 27, FirstName = "Olivia", LastName = "Smith", Email = "olivia.smith@test.com", PhoneNumber = "217-986-5029", Title = "Quality Assurance", MiddleInitial = "H" },
                new Contact { Id = 28, FirstName = "David", LastName = "Doe", Email = "david.doe@sample.org", PhoneNumber = "315-764-8965", Title = "Senior Developer", MiddleInitial = "C" },
                new Contact { Id = 29, FirstName = "John", LastName = "Garcia", Email = "john.garcia@example.com", PhoneNumber = "189-273-4859", Title = "DevOps Engineer", MiddleInitial = "E" },
                new Contact { Id = 30, FirstName = "Sophia", LastName = "Davis", Email = "sophia.davis@sample.org", PhoneNumber = "365-294-1580", Title = "Data Analyst", MiddleInitial = "M" },
                new Contact { Id = 31, FirstName = "David", LastName = "Miller", Email = "david.miller@demo.net", PhoneNumber = "231-649-7830", Title = "DevOps Engineer", MiddleInitial = "P" },
                new Contact { Id = 32, FirstName = "Sophia", LastName = "Martinez", Email = "sophia.martinez@example.com", PhoneNumber = "847-193-4765", Title = "Software Engineer", MiddleInitial = "K" },
                new Contact { Id = 33, FirstName = "Michael", LastName = "Doe", Email = "michael.doe@example.com", PhoneNumber = "452-609-7854", Title = "Senior Developer", MiddleInitial = "N" }
            };

    }
}
