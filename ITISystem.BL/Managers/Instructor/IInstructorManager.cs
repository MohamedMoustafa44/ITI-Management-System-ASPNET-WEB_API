using ITISystem.DAL;
using ITISystem.DTO;

namespace ITISystem.BL;

public interface IInstructorManager
{
    public List<InstructorReadDto>? GetInstructors();
    public InstructorReadDto? GetInstructorById(int id);
    public InstructorReadDto? GetInstructorByName(string name);
    public void AddInstructor(InstructorAddDto newInstructor);
    public bool DeleteInstructor(int id);
    public bool UpdateInstructor(InstructorUpdateDto instructorToUpdate);
}
