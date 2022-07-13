using System.ComponentModel.DataAnnotations;

namespace MongoDbWithSQL.Model
{
    public class ChangedAudit
    {
        [Key]
        public int Id { get; set; }
        public string? Mongodb_docid { get; set; }
        public string? columnname { get; set; }
        public string? columnvalue { get; set; }
    }
}
