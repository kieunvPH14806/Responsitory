using System;

namespace Demo_Responsitory.ViewsModels.ModelsCreate;

public class StudentCreate
{
    private Guid id;
    private string name;
    private DateTime birth;
    private string nameClass;
    private string classroom;

    public StudentCreate()
    {
        
    }

    public StudentCreate(Guid id, string name, DateTime birth, string nameClass, string classroom)
    {
        this.id = id;
        this.name = name;
        this.birth = birth;
        this.nameClass = nameClass;
        this.classroom = classroom;
    }

    public Guid Id
    {
        get => id;
        set => id = value;
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

    public string NameClass
    {
        get => nameClass;
        set => nameClass = value;
    }

    public string Classroom
    {
        get => classroom;
        set => classroom = value;
    }
}