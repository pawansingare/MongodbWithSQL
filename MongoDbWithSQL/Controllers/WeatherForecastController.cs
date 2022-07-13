using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbWithSQL.Model;
using MongoDbWithSQL.Models;

namespace MongoDbWithSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
       
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMongoCollection<Book> _booksCollection;
        private readonly IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings;
        private readonly AppDbContext context;

        public WeatherForecastController(IOptions<BookStoreDatabaseSettings> bookStoreDatabaseSettings,AppDbContext context)
        {
            var mongoClient = new MongoClient(
           bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                bookStoreDatabaseSettings.Value.BooksCollectionName);
            this.bookStoreDatabaseSettings = bookStoreDatabaseSettings;
            this.context = context;
        }

        [HttpGet]
        public async Task<List<UnionModel>> GetAsync()
        {
            try
            {
                List<Book> allBooks = await _booksCollection.Find(_ => true).ToListAsync();
                var ids = allBooks.Select(c => c._id);

                List<EmployeeDetails> employeeDetailsList = context.EmployeeDetails.Where(e => ids.Contains(e.Mongo_docid)).ToList();
                
                return (from book in allBooks
                           join employee in employeeDetailsList on book._id equals employee.Mongo_docid
                           select new UnionModel
                           {
                               Name = book.Name,
                               Department = book.Department,
                               Salary = book.Salary,
                               FirstName = employee.FirstName,
                               LastName = employee.LastName,
                               Address = book.Address!=null ? book.Address: employee.Address,
                               City = employee.City,
                               EmpCode = employee.EmpCode,
                               MobileNo = employee.MobileNo,
                               Mongo_docid = book._id,
                               EmployeeId = employee.EmployeeId
                           }).ToList();               
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}