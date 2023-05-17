using ITISystem.DAL;
using ITISystem.DTO;

namespace ITISystem.BL;

public class DepartmentManager : IDepartmentManager
{
    private readonly IDepartmentRepo _departmentRepo;

    public DepartmentManager(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    public List<DepartmentReadDto>? GetDepartments()
    {
        return _departmentRepo.GetDepartments()?.Select(dept => new DepartmentReadDto
        {
            Id = dept.Id,
            Name = dept.Name,
            Capacity = dept.Capacity,
        }).ToList();
    }

    public DepartmentReadDto? GetDepartmentById(int id)
    {
        Department? department = _departmentRepo.GetDepartmentById(id);
        DepartmentReadDto departmentReadDto = new DepartmentReadDto
        {
            Id = department?.Id ?? 0,
            Name = department?.Name ?? "",
            Capacity = department?.Capacity ?? 0,
        };
        return departmentReadDto;
    }

    public DepartmentReadDto? GetDepartmentByName(string name)
    {
        Department? department = _departmentRepo.GetDepartmentByName(name);
        DepartmentReadDto departmentReadDto = new DepartmentReadDto
        {
            Id = department?.Id ?? 0,
            Name = department?.Name ?? "",
            Capacity = department?.Capacity ?? 0,
        };
        return departmentReadDto;
    }

    public void AddDepartment(DepartmentAddDto newDepartment)
    {
        Department department = new Department
        {
            Name = newDepartment.Name,
            Capacity = newDepartment.Capacity,
        };
        _departmentRepo.AddDepartment(department);
    }

    public bool DeleteDepartment(int id)
    {
        bool isDeleted = _departmentRepo.DeleteDepartment(id);
        return isDeleted;
    }

    public bool UpdateDepartment(DepartmentUpdateDto departmentToUpdate)
    {
        Department? department = _departmentRepo.GetDepartmentById(departmentToUpdate.Id);
        if (department == null) { return false; }
        department.Name = departmentToUpdate.Name;
        department.Capacity = departmentToUpdate.Capacity;
        _departmentRepo.UpdateDepartment(department);
        return true;
    }
}
