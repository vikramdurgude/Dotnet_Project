using BOL;
using MySql.Data.MySqlClient;

namespace DAL;

public class DBManager
{

    public List<Student> GetStudents()
    {
        List<Student> ls = new List<Student>();
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=localhost; port=3306; user=root; password=manager; database=dotnetproject";
        string query = "select * from student";
        MySqlCommand command = new MySqlCommand(query, conn);
        conn.Open();
        try
        {
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int sid = int.Parse(reader["id"].ToString());
                string sname = reader["name"].ToString();
                string squal = reader["qual"].ToString();

                Student s = new Student { id = sid, name = sname, qual = squal };
                ls.Add(s);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

        return ls;
    }

    public void InsertStudent(int id, string name, string qual)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=localhost; port=3306; user=root; password=manager; database=dotnetproject";
        string query = "insert into student values('" + id + "','" + name + "','" + qual + "')";
        MySqlCommand command = new MySqlCommand(query, conn);
        conn.Open();
        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

    }

    public void DeletetStudent(string name)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=localhost; port=3306; user=root; password=manager; database=dotnetproject";
        string query = "delete from student where name='" + name + "'";
        MySqlCommand command = new MySqlCommand(query, conn);
        conn.Open();
        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

    }

    public void UpdatetStudent(string name, string nname)
    {
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString = "server=localhost; port=3306; user=root; password=manager; database=dotnetproject";
        string query = "update student set name='" + nname + "' where name='" + name + "'";
        MySqlCommand command = new MySqlCommand(query, conn);
        conn.Open();
        try
        {
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            conn.Close();
        }

    }

}