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
        _classRepository = classRepository ?? throw new ArgumentNullException(nameof(classRepository));
        //Khởi tạo một phiên bản mới của lớp System.ArgumentNullException với tên của tham số gây ra ngoại lệ này.
    }

    public IEnumerable<ClassShow> GetCollection()
    {
        return _classRepository.GetAll().Select(entity => new ClassShow()
        {
            NameClass = entity.Name,
            Classroom = entity.Classroom,
        });
    }



    public async Task<ClassShow> GetbyNameClassAsync(string classname)
    {
        var result = _classRepository.GetAll()
            .FirstOrDefaultAsync(entity => string.Equals(classname, entity.Name));

        return new ClassShow()
        {
            NameClass = @classname,
            Classroom = result?.Result.Classroom
        };

    }

    public async Task CreateAsync(ClassCreate classNew)
    {
        if (_classRepository.GetAll().Any(c => Guid.Equals(classNew.Id,c.Id)) == false)
        {
            var classInput = new Class()
            {
                Name = classNew.NameClass,
                Classroom = classNew.Classroom,
            };
            await _classRepository.AddAsync(classInput);
        }
        else
        {
            throw new ArgumentNullException("Lớp này đã tồn tại");
        }
    }

    public async Task UpdateAsync(ClassCreate @class)
    {
        if (_classRepository.GetAll().Any(c => c.Equals(@class.Id)))
        {
            var classtemp = _classRepository.GetAll().FirstOrDefaultAsync(entity => Equals(@class.Id, entity.Id))
                .Result;
            classtemp.Name = @class.NameClass;
            classtemp.Classroom = @class.Classroom;
            await _classRepository.Update(classtemp);
        }
        else
        {
            throw new ArgumentNullException("Không có dữ liệu này");
        }
    }

    public async Task DeleteAsync(Guid @classId)
    {
        if (_classRepository.GetAll().Any(c => c.Equals(@classId)))
        {
            var classTemp = _classRepository.GetAll().FirstOrDefaultAsync(entity => Equals(@classId, entity.Id)).Result;

            await _classRepository.Delete(classTemp);
        }
        else
        {
            throw new ArgumentNullException("không có dữ liệu");
        }
    }
}