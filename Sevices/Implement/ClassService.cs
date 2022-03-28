using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Demo_Responsitory.Entities;
using Demo_Responsitory.Mapping;
using Demo_Responsitory.Repositories.Interface;
using Demo_Responsitory.Sevices.Interface;
using Demo_Responsitory.ViewsModels;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Demo_Responsitory.ViewsModels.ModelsShow;

using Microsoft.EntityFrameworkCore;

namespace Demo_Responsitory.Sevices.Implement;

public class ClassService : IClassService
{
    private readonly IClassRepository _classRepository;
    private readonly IMapper _mapper;

    public ClassService(IClassRepository classRepository, IMapper mapper)
    {
        _classRepository = classRepository ?? throw new ArgumentNullException(nameof(classRepository));
        //Khởi tạo một phiên bản mới của lớp System.ArgumentNullException với tên của tham số gây ra ngoại lệ này.
        _mapper=mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public IEnumerable<ClassShow> GetCollection()
    {
        return _classRepository.GetAll().Select(entity => new ClassShow()
        {
            NameClass = entity.NameClass,
            Classroom = entity.Classroom,
        });
    }



    public async Task<ClassShow> GetbyNameClassAsync(string classname)
    {
        var result = _classRepository.GetAll()
            .FirstOrDefaultAsync(entity => string.Equals(classname, entity.NameClass));
        return new ClassShow()
        {
            NameClass = result.Result.NameClass,
            Classroom = result.Result?.Classroom
        };

    }

    public async Task CreateAsync(PostClassViewModels classNew)
    {
        if (_classRepository.GetAll().Any(c => string.Equals(classNew.NameClass, c.NameClass)) == false)
        {
            var classInput = _mapper.Map<Class>(classNew);
            await _classRepository.AddAsync(classInput);
        }
        else
        {
            throw new ArgumentNullException("Lớp này đã tồn tại");
        }
    }

    public async Task UpdateAsyncNameClass(ClassUpdateViewModels classNameNew)
    {//Update NameClass
        if (_classRepository.GetAll().Any(c => c.Equals(classNameNew.Id)))
        {
            var classtemp = _classRepository.GetAll().FirstOrDefault(entity => Equals(classNameNew.NameClass, entity.NameClass))
                ;
            classtemp = _mapper.Map<Class>(classNameNew);
            await _classRepository.Update(classtemp);
        }
        else
        {
            throw new ArgumentNullException("Không có dữ liệu này");
        }
    }

    public async Task UpdateAsyncClassroom(ClassUpdateViewModels classroomNew)
    {//Update ClassRoom
        if (_classRepository.GetAll().Any(c=>c.Equals(classroomNew.NameClass)))
        {
            var classtemp = _classRepository.GetAll()
                .FirstOrDefault(entity => Equals(classroomNew.NameClass, entity.NameClass));
            classtemp = _mapper.Map<Class>(classtemp);
            await _classRepository.Update(classtemp);

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