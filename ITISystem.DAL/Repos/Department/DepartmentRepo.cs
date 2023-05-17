namespace ITISystem.DAL;

public class DepartmentRepo : IDepartmentRepo
{
    private readonly ITIDbContext _context;

    public DepartmentRepo(ITIDbContext context)
    {
        _context = context;
    }

    public List<Department>? GetDepartments()
    {
        return _context.Set<Department>().ToList();
    }

    public Department? GetDepartmentById(int id)
    {
        return _context.Set<Department>().FirstOrDefault(dept => dept.Id == id);
    }

    public Department? GetDepartmentByName(string name)
    {
        return _context.Set<Department>().FirstOrDefault(dept => dept.Name == name);
    }

    public void AddDepartment(Department newDepartment)
    {
        _context.Set<Department>().Add(newDepartment);
        _context.SaveChanges();
    }

    public bool DeleteDepartment(int id)
    {
        Department? department = GetDepartmentById(id);
        if (department == null) { return false; }
        _context.Set<Department>().Remove(department);
        return true;
    }

    public void UpdateDepartment(Department departmentToUpdate)
    {
        _context.SaveChanges();
    }
}
