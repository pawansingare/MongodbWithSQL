namespace MongoDbWithSQL.Model
{
    public class UnionModel
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? EmpCode { get; set; }
        public long MobileNo { get; set; }
        public string? Mongo_docid { get; set; }

       


       
        public string Name { get; set; } = null!;

       
        public string Department { get; set; }

       
        public string Salary { get; set; } = null!;
    }
}
