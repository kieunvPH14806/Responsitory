using System;
using System.Collections.Generic;

namespace Demo_Responsitory.Entities;

public class Student
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime Birth { get; set; }

    public virtual ICollection<Class> Classes { get; set; }
}