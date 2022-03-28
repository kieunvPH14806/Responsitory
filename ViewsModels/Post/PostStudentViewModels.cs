using System;
using System.Collections.Generic;
using Demo_Responsitory.Entities;

namespace Demo_Responsitory.ViewsModels.ModelsCreate;

public class PostStudentViewModels
{
    public string Name { get; set; }
    public DateTime Birth { get; set; }
    public string  NameClass { get; set; }
    public string  Classroom { get; set; }
}