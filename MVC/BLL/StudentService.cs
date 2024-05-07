using BOL;
using DAL;

namespace BLL;

public class StudentService
{
    public List<Student> GetAllStudents()
    {
        DBManager db = new DBManager();
        List<Student> ls = db.GetStudents();
        return ls;
    }

    public void InsertStudent(int id, string name, string qual)
    {
        DBManager db = new DBManager();
        db.InsertStudent(id, name, qual);
    }

    public void DeleteStudent(string name)
    {
        DBManager db = new DBManager();
        db.DeletetStudent(name);
    }

    public void UpdateStudent(string name, string nname)
    {
        DBManager db = new DBManager();
        db.UpdatetStudent(name, nname);
    }
}