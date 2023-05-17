namespace ITISystem.DAL;

public interface IStudentRepo
{
    public List<Student>? GetStudents();
    public Student? GetStudentById(int id);
    public Student? GetStudentByName(string name);
    public Student? GetStudentWithDepartment(int id);
    public void AddStudent(Student newStudent);
    public bool DeleteStudent(int id);
    public void UpdateStudent(Student studentToUpdate);
}
