using ITISystem.DTO;

namespace ITISystem.BL;

public interface IDepartmentManager
{
    public List<DepartmentReadDto>? GetDepartments();
    public DepartmentReadDto? GetDepartmentById(int id);
    public DepartmentReadDto? GetDepartmentByName(string name);
    public void AddDepartment(DepartmentAddDto newDepartment);
    public bool DeleteDepartment(int id);
    public bool UpdateDepartment(DepartmentUpdateDto departmentToUpdate);
}
