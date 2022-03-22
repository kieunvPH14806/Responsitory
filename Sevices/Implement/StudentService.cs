using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo_Responsitory.Entities;
using Demo_Responsitory.Repositories.Interface;
using Demo_Responsitory.Sevices.Interface;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Demo_Responsitory.ViewsModels.ModelsShow;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Demo_Responsitory.Sevices.Implement;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IClassRepository _classRepository;

    public StudentService(IStudentRepository studentRepository, IClassRepository classRepository)
    {
        _studentRepository = studentRepository;
        _classRepository = classRepository;
    }

    public IEnumerable<StudentShow> GetCollection()
    {
        return _studentRepository.GetAll().Select(entity => new StudentShow()
        {
            Name = entity.Name,
            Birth = entity.Birth,
            NameClass = entity.Classes.Select(c => c.Name).ToList(),
            Classroom = entity.Classes.Select(c => c.Classroom).ToList()
        });
    }

    public async Task<StudentShow> GetbyStudentNameAsync(string nameStudent)
    {
        var studentTemp = _studentRepository.GetAll().FirstOrDefaultAsync(entity => Equals(nameStudent, entity.Name));
        return new StudentShow()
        {
            Name = nameStudent,
            Birth = studentTemp.Result.Birth,
            NameClass = studentTemp.Result.Classes.Select(c => c.Name).ToList(),
            Classroom = studentTemp.Result.Classes.Select(c => c.Classroom).ToList(),
        };
    }

    public async Task CreateAsync(StudentCreate student)
    {
        var inputStudent = new Student()
        {
            Name = student.Name,
            Birth = student.Birth,
            Classes = new List<Class>()
            {
                new Class()
                {
                    Name = student.NameClass,
                    Classroom = student.Classroom
                }
            }
        };
        await _studentRepository.AddAsync(inputStudent);
    }

    public async Task UpdateAsync(StudentCreate student)
    {

        var inputStudent = _studentRepository.GetAll().FirstOrDefaultAsync(c => c.Id == student.Id).Result;

        inputStudent.Name = student.Name;
        inputStudent.Birth = student.Birth;
        inputStudent.Classes = new List<Class>()
            {
                new Class()
                {
                    Name = student.NameClass,
                    Classroom = student.Classroom
                }
            };

        await _studentRepository.Update(inputStudent);
    }

    public Task DeleteAsync(StudentCreate student)
    {
        throw new NotImplementedException();
    }
}