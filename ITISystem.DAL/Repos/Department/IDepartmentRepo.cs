namespace ITISystem.DAL;

public interface IDepartmentRepo
{
    public List<Department>? GetDepartments();
    public Department? GetDepartmentById(int id);
    public Department? GetDepartmentByName(string name);
    public void AddDepartment(Department newDepartment);
    public bool DeleteDepartment(int id);
    public void UpdateDepartment(Department departmentToUpdate);
}
