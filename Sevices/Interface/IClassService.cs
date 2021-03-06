using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Demo_Responsitory.ViewsModels;
using Demo_Responsitory.ViewsModels.ModelsCreate;
using Demo_Responsitory.ViewsModels.ModelsShow;

namespace Demo_Responsitory.Sevices.Interface;

public interface IClassService
{
    IEnumerable<ClassShow> GetCollection();
    Task<ClassShow> GetbyNameClassAsync(string Studentclass);
    Task CreateAsync(PostClassViewModels @class);
    Task UpdateAsyncNameClass(ClassUpdateViewModels @class);
    Task DeleteAsync(Guid @classId);
    
    


}