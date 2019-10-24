using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using MongoDB.Driver;
using UBS.EmployeeSystem.Persistence;
using UBS.EmployeeSystem.Abstractions;

namespace UBS.EmployeeSystem
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;
        private readonly IMongoCollection<Admin> _admin;
        public EmployeeService(IDatabaseSettings setting)
        {
            var client = new MongoClient(setting.connectionString);
            var database = client.GetDatabase(setting.dbName);
            _employee = database.GetCollection<Employee>(setting.employeeCollectionName);
            _admin = database.GetCollection<Admin>(setting.adminCollectionName);
        }

        public List<Employee> GetEmployees()
        {
            var employees = _employee.Find(s => true).ToList();
            return employees;
        }

        public List<Admin> GetAdmins()
        {
            var admins = _admin.Find(s => true).ToList();
            return admins;
        }

        public Admin AddAdmin(Admin admin)
        {
            _admin.InsertOne(admin);
            return admin;
        }

        public Employee GetSingleEmp(double _id)
        {
            var employee = _employee.Find<Employee>(s => s._id == _id).FirstOrDefault();
            return employee;
        }

        public Employee EditEmp(Employee emp)
        {
            var employee = _employee.FindOneAndReplace(s => s._id == emp._id, emp);
            return employee;
        }

        public Employee AddEmployee(Employee emp)
        {
            _employee.InsertOne(emp);
            return emp;
        }

        public DeleteResult RemoveEmp(double _id)
        {
            var employee = _employee.DeleteOne(s => s._id == _id);
            return employee;
        }

        public List<Employee> GetEmpDept(string dname)
        {
            var employees = _employee.Find<Employee>(s => s.departmentName == dname).ToList();
            return employees;
        }
    }
}
