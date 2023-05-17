using ITISystem.DAL;
using ITISystem.DTO;

namespace ITISystem.BL;

public class InstructorManager : IInstructorManager
{
    private readonly IInstructorRepo _instructorRepo;

    public InstructorManager(IInstructorRepo instructorRepo)
    {
        _instructorRepo = instructorRepo;
    }

    public List<InstructorReadDto>? GetInstructors()
    {
        List<Instructor>? instructorsList = _instructorRepo.GetInstructors();
        if (instructorsList == null)
        {
            return null;
        }
        List<InstructorReadDto>? instructorReadDtos = instructorsList?.Select(inst => new InstructorReadDto
        {
            Id = inst.Id,
            Name = inst.Name,
            Age = inst.Age,
            Email = inst.Email,
            Phone = inst.Phone,
        }).ToList();
        return instructorReadDtos;
    }

    public InstructorReadDto? GetInstructorById(int id)
    {
        Instructor? instructor = _instructorRepo.GetInstructorById(id);
        if (instructor == null)
        {
            return null;
        }
        InstructorReadDto instructorReadDto = new InstructorReadDto
        {
            Id= instructor.Id,
            Name = instructor.Name,
            Age = instructor.Age,
            Email = instructor.Email,
            Phone = instructor.Phone,
        };
        return instructorReadDto;
    }

    public InstructorReadDto? GetInstructorByName(string name)
    {
        Instructor? instructor = _instructorRepo.GetInstructorByName(name);
        if (instructor == null)
        {
            return null;
        }
        InstructorReadDto instructorReadDto = new InstructorReadDto
        {
            Id = instructor.Id,
            Name = instructor.Name,
            Age = instructor.Age,
            Email = instructor.Email,
            Phone = instructor.Phone,
        };
        return instructorReadDto;
    }

    public void AddInstructor(InstructorAddDto newInstructor)
    {
        if (newInstructor == null)
        {
            return;
        }
        Instructor? instructor = new Instructor
        {
            Name = newInstructor.Name,
            Age = newInstructor.Age,
            Email = newInstructor.Email,
            Phone = newInstructor.Phone
        };
        _instructorRepo.AddInstructor(instructor);
    }

    public bool DeleteInstructor(int id)
    {
        bool isDeleted = _instructorRepo.DeleteInstructor(id);
        return isDeleted;
    }

    public bool UpdateInstructor(InstructorUpdateDto instructorToUpdate)
    {
        Instructor? instructor = _instructorRepo.GetInstructorById(instructorToUpdate.Id);
        if (instructor == null) { return false; }
        instructor.Name = instructorToUpdate.Name;
        instructor.Age = instructorToUpdate.Age;
        instructor.Email = instructorToUpdate.Email;
        instructor.Phone = instructorToUpdate.Phone;
        _instructorRepo.UpdateInstructor(instructor);
        return true;

    }
}
