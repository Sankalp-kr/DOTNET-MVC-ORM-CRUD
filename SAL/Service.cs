namespace SAL;
using BLL;
using BOL;
public class Service
{
    public List<Student> GetAll(){
        Blogic bl = new Blogic(); 
        return bl.GetAll();
    }

    public bool Add(Student addthis){
        Blogic bl = new Blogic();
        return bl.Add(addthis);
    }

    public bool Remove(int rmthis){
        Blogic bl = new Blogic();
        return bl.Remove(rmthis);
    }

    public Student Edit(int edthis){
        Blogic bl = new Blogic();
        return bl.Edit(edthis);
    }
    public bool Update(Student up){
        Blogic bl = new Blogic();
        return bl.Update(up);
    }
}
