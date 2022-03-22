using System;
using System.Collections.Generic;

namespace Demo_Responsitory.ViewsModels.ModelsShow;

public class StudentShow
{
    private string name;
    private DateTime birth;
    private List<string> nameClass;
    private List<string> classroom;

    public StudentShow()
    {

    }


    public StudentShow(string name, DateTime birth, List<string> nameClass, List<string> classroom)
    {
        this.name = name;
        this.birth = birth;
        this.nameClass = nameClass;
        this.classroom = classroom;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public DateTime Birth
    {
        get => birth;
        set => birth = value;
    }

    public List<string> NameClass
    {
        get => nameClass;
        set => nameClass = value;
    }

    public List<string> Classroom
    {
        get => classroom;
        set => classroom = value;
    }
}