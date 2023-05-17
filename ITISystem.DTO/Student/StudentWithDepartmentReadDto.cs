using ITISystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITISystem.DTO.Student;

public class StudentWithDepartmentReadDto : Person
{
    public DepartmentReadDto? Department { get; set; }
}
