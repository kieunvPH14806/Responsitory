using System.Linq;
using System.Threading.Tasks;
using Demo_Responsitory.Entities;

namespace Demo_Responsitory.Repositories.Interface;

public interface IClassRepository
{
    IQueryable<Class> GetAll();
    Task AddAsync(Class student);
    Task Update(Class student);
    Task Delete(Class student);
    

}