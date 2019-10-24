using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace UBS.EmployeeSystem.Abstractions
{
    public class Employee
    {
        [BsonId]
        [Required(ErrorMessage = "Please enter Employee Id")]
        public double _id { get; set; }
        public string name { get; set; }
        public string designation { get; set; }
        public string departmentName { get; set; }
        public int salary { get; set; }
    }
}
