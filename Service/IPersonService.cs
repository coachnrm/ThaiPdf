using PdfTest.Models;

namespace PdfTest.Service
{
    public interface IPersonService
    {
        bool AddUpdate(Person person);
        bool Delete(int id);
        List<Person> GetAll();
        Person FindById(int id);
    }
}