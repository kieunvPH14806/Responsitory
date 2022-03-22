using System;

namespace Demo_Responsitory.ViewsModels.ModelsCreate;

public class ClassCreate
{
    private Guid id;
    private string nameClass;
    private string classroom;

    public ClassCreate()
    {
        
    }

    public ClassCreate(Guid id, string nameClass, string classroom)
    {
        this.id = id;
        this.nameClass = nameClass;
        this.classroom = classroom;
    }

    public Guid Id
    {
        get => id;
        set => id = value;
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