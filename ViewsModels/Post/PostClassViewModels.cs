using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo_Responsitory.Entities;

namespace Demo_Responsitory.ViewsModels.ModelsCreate;

public class PostClassViewModels
{
    public string NameClass { get; set; }
    public string Classroom { get; set; }
}