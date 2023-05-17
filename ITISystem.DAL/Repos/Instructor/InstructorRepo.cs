namespace ITISystem.DAL;

public class InstructorRepo : IInstructorRepo
{
    private readonly ITIDbContext _context;

    public InstructorRepo(ITIDbContext context)
    {
        _context = context;
    }

    public List<Instructor>? GetInstructors()
    {
        return _context.Set<Instructor>().ToList();
    }

    public Instructor? GetInstructorById(int id)
    {
        return _context.Set<Instructor>().FirstOrDefault(x => x.Id == id);
    }

    public Instructor? GetInstructorByName(string name)
    {
        return _context.Set<Instructor>().FirstOrDefault(x => x.Name == name);
    }

    public void AddInstructor(Instructor newInstructor)
    {
        _context.Set<Instructor>().Add(newInstructor);
        _context.SaveChanges();
    }

    public bool DeleteInstructor(int id)
    {
        Instructor? instructorToDelete = _context.Set<Instructor>().FirstOrDefault(inst => inst.Id == id);
        if (instructorToDelete == null)
        {
            return false;
        }
        _context.Set<Instructor>().Remove(instructorToDelete);
        _context.SaveChanges();
        return true;
    }

    public void UpdateInstructor(Instructor instructorToUpdate)
    {
        _context.SaveChanges();
    }
}
