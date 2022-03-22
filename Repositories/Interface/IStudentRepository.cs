using System.Linq;
using System.Threading.Tasks;
using Demo_Responsitory.Entities;

namespace Demo_Responsitory.Repositories.Interface;

public interface IStudentRepository
{
    IQueryable<Student> GetAll();
    Task AddAsync(Student student);
    Task Update(Student student);
    Task Delete(Student student);
   

}