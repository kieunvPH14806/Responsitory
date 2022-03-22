namespace Demo_Responsitory.ViewsModels.ModelsShow;

public class ClassShow
{
    private string nameClass;
    private string classroom;

    public ClassShow()
    {
        
    }

    public ClassShow(string nameClass, string classroom)
    {
        this.nameClass = nameClass;
        Classroom = classroom;
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