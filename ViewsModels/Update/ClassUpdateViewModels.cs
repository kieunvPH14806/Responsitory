using System;
using System.Collections.Generic;

using Demo_Responsitory.Entities;

namespace Demo_Responsitory.ViewsModels;

public class ClassUpdateViewModels
{
    public Guid Id { get; set; }
    public string NameClass { get; set; }
    public string Classroom { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}