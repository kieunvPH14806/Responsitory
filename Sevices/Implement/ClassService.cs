using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Demo_Responsitory.Entities;
using Demo_Responsitory.Repositories.Interface;
using Demo_Responsitory.Sevices.Interface;
using Demo_Responsitory.ViewsModels;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Demo_Responsitory.ViewsModels.ModelsShow;

using Microsoft.EntityFrameworkCore;

namespace Demo_Responsitory.Sevices.Implement;

public class ClassService : IClassService
{
    readonly IClassRepository _classRepository;

    public ClassService(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    public IEnumerable<ClassShow> GetCollection()
    {
        return _classRepository.GetAll().Select(entity => new ClassShow()
        {
            NameClass = entity.Name,
            Classroom = entity.Classroom,
        });
    }

    public async Task<ClassShow> GetbyNameClassAsync(string @classname)
    {
        var result = _classRepository.GetAll()
            .FirstOrDefaultAsync(entity => Equals(@classname, entity.Name));
        return new ClassShow()
        {
            NameClass = @classname,
            Classroom = result?.Result.Classroom
        };
    }

    public async Task CreateAsync(ClassCreate @class)
    {
        var classInput = new Class()
        {
            Name = @class.NameClass,
            Classroom = @class.Classroom,

        };
        await _classRepository.AddAsync(classInput);
    }

    public async Task UpdateAsync(ClassCreate @class)
    {
        var classtemp = _classRepository.GetAll().FirstOrDefaultAsync(entity => Equals(@class.Id, entity.Id));
        var classInput = new Class()
        {
            Id = classtemp.Result.Id,
            Name = classtemp.Result.Name,
            Classroom = classtemp.Result.Classroom
        };
        await _classRepository.Update(classInput);
    }

    public async Task DeleteAsync(Guid @classId)
    {
        var classtemp = _classRepository.GetAll().FirstOrDefaultAsync(entity => Equals(@classId, entity.Id));
        var classInput = new Class()
        {
            Id = classtemp.Result.Id,
            Name = classtemp?.Result.Name,
            Classroom = classtemp?.Result.Classroom
        };
        await _classRepository.Delete(classInput);
    }
}