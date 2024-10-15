using PdfTest.Data;
using PdfTest.Models;

namespace PdfTest.Service
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _ctx;
        public PersonService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public List<Person> GetAll()
        {
            return _ctx.Person.ToList();
        }
    }
}