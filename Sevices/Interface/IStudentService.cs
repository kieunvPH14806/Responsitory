using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Demo_Responsitory.ViewsModels.ModelsShow;

namespace Demo_Responsitory.Sevices.Interface;

public interface IStudentService
{
    IEnumerable<StudentShow> GetCollection();
    IQueryable<StudentShow> GetbyStudentNameAsync(string nameStudent);
    Task CreateAsync(StudentCreate student);
    Task UpdateAsync(StudentCreate student);
    Task DeleteAsync(Guid studentId);

}