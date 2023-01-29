namespace DAL;
using BOL;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
public class StudentManager
{
    public List<Student> GetAll(){
        List<Student> slist = new List<Student>();
        /* gets all the data from the database and return the list */
        string conString =@"server=localhost;uid=sankalp;pwd=sankalp;database=world";
        string query = "select * from students";
        
        MySqlConnection connect = new MySqlConnection(conString);
        
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = query;

        connect.Open();
        MySqlDataReader cmr =  cmd.ExecuteReader();
        while(cmr.Read()){
            slist.Add(new Student(){Id=int.Parse(cmr["id"].ToString()),Name=cmr["name"].ToString(),Class=cmr["class"].ToString()});
        }
        connect.Close();
        return slist;

    }

    public bool Add(Student addthis){
        string conString =@"server=localhost;uid=sankalp;pwd=sankalp;database=world";
        string query = "insert into students values("+addthis.Id+",'"+addthis.Name+"','"+addthis.Class+"')";
        
        MySqlConnection connect = new MySqlConnection(conString);
        
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = query;

        connect.Open();
        cmd.ExecuteReader();
        connect.Close();
        return true;
    }
    public bool Remove(int rmthis){
        string conString =@"server=localhost;uid=sankalp;pwd=sankalp;database=world";
        string query = "delete from students where id="+rmthis;
        
        MySqlConnection connect = new MySqlConnection(conString);
        
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = query;

        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
        return true;
    }
    public Student Edit(int edthis){
        string conString =@"server=localhost;uid=sankalp;pwd=sankalp;database=world";
        string query = "select * from students where id="+edthis;
        
        MySqlConnection connect = new MySqlConnection(conString);
        
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = query;
        Student ret = new Student();
        connect.Open();
        MySqlDataReader reader =  cmd.ExecuteReader();
    
        while(reader.Read()){
            ret = new Student(){Id=int.Parse(reader["id"].ToString()),Name=reader["name"].ToString(),Class=reader["class"].ToString()};
        }
        connect.Close();
        return ret;
    }

    public bool Update(Student up){
        string conString =@"server=localhost;uid=sankalp;pwd=sankalp;database=world";
        string query = "update students set id="+up.Id+",name='"+up.Name+"',class='"+up.Class+"' where id="+up.Id;
        
        MySqlConnection connect = new MySqlConnection(conString);
        
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = connect;
        cmd.CommandText = query;

        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
        return true;
    }

}
