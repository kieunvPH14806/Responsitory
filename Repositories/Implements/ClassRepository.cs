using System;
using System.Linq;
using System.Threading.Tasks;
using Demo_Responsitory.Entities;
using Demo_Responsitory.Repositories.Interface;

namespace Demo_Responsitory.Repositories.Implements;

public class ClassRepository : IClassRepository
{
    private readonly AppilicationDbContext _context;

    public ClassRepository(AppilicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context)); 
    }

    public IQueryable<Class> GetAll()
    {
        return _context.Classes;
    }

    public async Task AddAsync(Class @class)
    {
        await _context.Classes.AddAsync(@class);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Class @class)
    {
        _context.Classes.Update(@class);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Class @class)
    {
        _context.Classes.Remove(@class);
        await _context.SaveChangesAsync();
    }


}
   