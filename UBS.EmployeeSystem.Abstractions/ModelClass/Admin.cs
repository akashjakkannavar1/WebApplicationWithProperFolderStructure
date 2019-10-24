using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel.DataAnnotations;

namespace UBS.EmployeeSystem.Abstractions
{
    public class Admin
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string iid { get; set; }
        public double eid { get; set; }
        public string username { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
}
