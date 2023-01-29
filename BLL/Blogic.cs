namespace BLL;
using DAL;
using BOL;
using System.Collections.Generic;
public class Blogic
{
    public List<Student> GetAll(){
        StudentManager sm = new StudentManager();
        return sm.GetAll();
    }

    public bool Add(Student addthis){
        StudentManager sm = new StudentManager();
        return sm.Add(addthis);
    }
    public bool Remove(int rmthis){
        StudentManager sm = new StudentManager();
        return sm.Remove(rmthis);
    }
    public Student Edit(int edthis){
        StudentManager sm = new StudentManager();
        return sm.Edit(edthis);
    }
    public bool Update(Student up){
        StudentManager sm = new StudentManager();
        return sm.Update(up);
    }
}
