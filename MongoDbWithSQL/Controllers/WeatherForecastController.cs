using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
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
        public async Task<List<Book>> GetAsync() =>
      await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id)
        {

            var book =  await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            var employeeDetails = context.EmployeeContactDetails.FirstOrDefault(_ => _.EmployeeId == id);
            return book;
        }

        //public async Task CreateAsync(Book newBook) =>
        //    await _booksCollection.InsertOneAsync(newBook);

        //public async Task UpdateAsync(string id, Book updatedBook) =>
        //    await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        //public async Task RemoveAsync(string id) =>
        //    await _booksCollection.DeleteOneAsync(x => x.Id == id);

    }
}