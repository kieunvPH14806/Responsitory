using System;
using System.Linq;
using System.Threading.Tasks;
using Demo_Responsitory.Entities;
using Demo_Responsitory.Repositories.Interface;

namespace Demo_Responsitory.Repositories.Implements;

public class StudentRespository:IStudentRepository
{
     private readonly AppilicationDbContext _context;

    public StudentRespository(AppilicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public IQueryable<Student> GetAll()
    {
        return _context.Students;
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Student student)
    {
       _context.Students.Remove(student);
       await _context.SaveChangesAsync();


    }

   
}