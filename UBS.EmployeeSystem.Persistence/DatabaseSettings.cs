using System;
using MongoDB.Bson;
using MongoDB.Driver;
using UBS.EmployeeSystem.Abstractions;

namespace UBS.EmployeeSystem.Persistence
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string connectionString { get; set; }
        public string dbName { get; set; }
        public string employeeCollectionName { get; set; }
        public string adminCollectionName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string connectionString { get; set; }
        string dbName { get; set; }
        string employeeCollectionName { get; set; }
        string adminCollectionName { get; set; }
    }

    //public class Dbsetting
    //{
    //    private readonly IMongoCollection<Employee> _employee;
    //    private readonly IMongoCollection<Admin> _admin;
    //    public Dbsetting(IDatabaseSettings setting)
    //    {
    //        var client = new MongoClient(setting.connectionString);
    //        var database = client.GetDatabase(setting.dbName);
    //        _employee = database.GetCollection<Employee>(setting.employeeCollectionName);
    //        _admin = database.GetCollection<Admin>(setting.adminCollectionName);
    //    }
    //}




}
