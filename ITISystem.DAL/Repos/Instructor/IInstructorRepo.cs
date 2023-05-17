namespace ITISystem.DAL;

public interface IInstructorRepo
{
    public List<Instructor>? GetInstructors();
    public Instructor? GetInstructorById(int id);
    public Instructor? GetInstructorByName(string name);
    public void AddInstructor(Instructor newInstructor);
    public bool DeleteInstructor(int id);
    public void UpdateInstructor(Instructor instructorToUpdate);
}
