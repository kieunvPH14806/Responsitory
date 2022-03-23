using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        _classRepository = classRepository ?? throw new ArgumentNullException(nameof(classRepository));
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

    public IQueryable<StudentShow> GetbyStudentNameAsync(string nameStudent)
    {
        //if (_studentRepository.GetAll().Any(c => string.Equals(nameStudent, c.Name)) == true)
        //{

        return _studentRepository.GetAll().Where(entity => string.Equals(nameStudent, entity.Name))
            .Select(c => new StudentShow()
            {
                Name = c.Name,
                Birth = c.Birth,
                NameClass = c.Classes.Select(c=>c.Name).ToList(),
                Classroom = c.Classes.Select(c=>c.Classroom).ToList()

            });
        //{
        //    Name = nameStudent,
        //    Birth = studentTemp.Birth,
        //    Classroom = studentTemp.Classes.Select(c=>c.Classroom).ToList(),
        //    NameClass = studentTemp.Classes.Select(c=>c.Classroom).ToList(),
        //};

        //}
        //else
        //{
        //    throw new ArgumentNullException(" không có trong dữ liệu");
        //}

    }

    public async Task CreateAsync(StudentCreate student)
    {
        var inputStudent = new Student();
        if (_classRepository.GetAll().Any(entity => string.Equals(student.NameClass, entity.Name)))
        {
            inputStudent = new Student()
            {
                Id = Guid.NewGuid(),
                Name = student.Name,
                Birth = student.Birth,
                Classes = new Collection<Class>()
                {
                    _classRepository.GetAll().FirstOrDefault(c=> string.Equals(student.NameClass,c.Name))

                }
            };
            await _studentRepository.AddAsync(inputStudent);
        }
        else
        {
            inputStudent = new Student()
            {
                Id = Guid.NewGuid(),
                Name = student.Name,
                Birth = student.Birth,
                Classes = new Collection<Class>()
                {
                    new Class()
                    {
                        Id = Guid.NewGuid(),
                        Name = student.NameClass,
                        Classroom = student.Classroom
                    }

                }
            };
            await _studentRepository.AddAsync(inputStudent);
            // throw new ArgumentNullException("Lớp Học Này Không tồn tại");
        }

    }

    public async Task UpdateAsync(StudentCreate student)
    {

        var inputStudent = _studentRepository.GetAll().FirstOrDefaultAsync(c => c.Id == student.Id).Result;

        var classEdit = _classRepository.GetAll().FirstOrDefault(c => string.Equals(student.NameClass, c.Name));
        classEdit.Name = student.NameClass;
        classEdit.Classroom = student.Classroom;
        Collection<Class> classesTemp = new Collection<Class>();
        classesTemp.Add(classEdit);

        inputStudent.Name = student.Name;
        inputStudent.Birth = student.Birth;
        inputStudent.Classes = classesTemp;

        await _studentRepository.Update(inputStudent);
    }

    public async Task DeleteAsync(Guid studentId)
    {
        var studentRemove = _studentRepository.GetAll().FirstOrDefaultAsync(entity => Equals(studentId, entity.Id)).Result;
        await _studentRepository.Delete(studentRemove);
    }
}