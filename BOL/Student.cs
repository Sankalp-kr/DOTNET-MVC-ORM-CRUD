namespace BOL;
public class Student
{
    public int Id{get;set;}
    public string Name{get;set;}
    public string Class{get;set;}
    public Student(int Id,string Name, string Class){
        this.Id = Id;
        this.Name =Name;
        this.Class= Class;
    }
    public Student(){}

}
