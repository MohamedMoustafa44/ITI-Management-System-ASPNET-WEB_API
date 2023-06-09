﻿using ITISystem.DAL;
using ITISystem.DTO;

namespace ITISystem.BL;

public class Instructor_CourseManager : IInstructor_CourseManager
{
    private readonly IInstructor_CourseRepo _instructor_CourseRepo;

    public Instructor_CourseManager(IInstructor_CourseRepo instructor_CourseRepo)
    {
        _instructor_CourseRepo = instructor_CourseRepo;
    }
    public List<Instructor_CourseReadDto>? GetAllRates()
    {
        List<Instructor_Course>? Students_Instructors_Courses = _instructor_CourseRepo.GetAllRates();
        if(Students_Instructors_Courses == null)
        {
            return null;
        }
        
        List<Instructor_CourseReadDto>? Students_Instructors_CoursesReadDtos = Students_Instructors_Courses
                                                                    .Select(inst_crs => new Instructor_CourseReadDto
                                                                    {
                                                                        StudentName = inst_crs.Student!.Name,
                                                                        InstructorName = inst_crs.Instructor!.Name,
                                                                        CourseName = inst_crs.Course!.Name,
                                                                        Rate = inst_crs.Rate,
                                                                    }).ToList();
        return Students_Instructors_CoursesReadDtos;
    }

    public Instructor_CourseReadDto? GetRateByStdIdInstIdCrsId(int stdId, int instId, int crsId)
    {
        Instructor_Course? Student_Instructor_Course = _instructor_CourseRepo.GetRateByStdIdInstIdCrsId(stdId, instId, crsId);
        if(Student_Instructor_Course == null)
        {
            return null;
        }
        Instructor_CourseReadDto Student_Instructor_CourseDto = new Instructor_CourseReadDto
        {
            StudentName = Student_Instructor_Course.Student!.Name,
            InstructorName = Student_Instructor_Course.Instructor!.Name,
            CourseName = Student_Instructor_Course.Course!.Name,
            Rate = Student_Instructor_Course.Rate,
        };
        return Student_Instructor_CourseDto;
    }

    public List<Instructor_CourseReadDto>? GetRateByStdIdInstId(int stdId, int instId)
    {
        List<Instructor_Course>? Student_Instructor_Courses = _instructor_CourseRepo.GetRateByStdIdInstId(stdId, instId);
        if(Student_Instructor_Courses == null)
        {
            return null;
        }
        List<Instructor_CourseReadDto> Student_Instructor_CoursesDto = Student_Instructor_Courses.Select(inst_crs => new Instructor_CourseReadDto
        {
            StudentName = inst_crs.Student!.Name,
            InstructorName = inst_crs.Instructor!.Name,
            CourseName = inst_crs.Course!.Name,
            Rate = inst_crs.Rate,
        }).ToList();
        return Student_Instructor_CoursesDto;
    }
    public List<Instructor_CourseReadDto>? GetRateByStdIdCrsId(int stdId, int crsId)
    {
        List<Instructor_Course>? Student_Instructors_Course = _instructor_CourseRepo.GetRateByStdIdCrsId(stdId, crsId);
        if (Student_Instructors_Course == null)
        {
            return null;
        }
        List<Instructor_CourseReadDto> Student_Instructors_CourseDto = Student_Instructors_Course.Select(inst_crs => new Instructor_CourseReadDto
        {
            StudentName = inst_crs.Student!.Name,
            InstructorName = inst_crs.Instructor!.Name,
            CourseName = inst_crs.Course!.Name,
            Rate = inst_crs.Rate,
        }).ToList();
        return Student_Instructors_CourseDto;
    }
    public List<Instructor_CourseReadDto>? GetRateByInstIdCrsId(int instId, int crsId)
    {
        List<Instructor_Course>? Students_Instructor_Course = _instructor_CourseRepo.GetRateByInstIdCrsId(instId, crsId);
        if (Students_Instructor_Course == null)
        {
            return null;
        }
        List<Instructor_CourseReadDto> Students_Instructor_CourseDto = Students_Instructor_Course.Select(inst_crs => new Instructor_CourseReadDto
        {
            StudentName = inst_crs.Student!.Name,
            InstructorName = inst_crs.Instructor!.Name,
            CourseName = inst_crs.Course!.Name,
            Rate = inst_crs.Rate,
        }).ToList();
        return Students_Instructor_CourseDto;
    }

    public List<Instructor_CourseReadDto>? GetRatesByInstId(int instId)
    {
        List<Instructor_Course>? students_Instructor_Courses = _instructor_CourseRepo.GetRateByInstId(instId);
        if(students_Instructor_Courses == null)
        {
            return null;
        }
        List<Instructor_CourseReadDto> Students_Instructor_CoursesReadDtos = students_Instructor_Courses.Select(inst_crs => new Instructor_CourseReadDto
        {
            StudentName = inst_crs.Student!.Name,
            InstructorName = inst_crs.Instructor!.Name,
            CourseName = inst_crs.Course!.Name,
            Rate = inst_crs.Rate,
        }).ToList();
        return Students_Instructor_CoursesReadDtos;
    }

    public List<Instructor_CourseReadDto>? GetRatesByCrsId(int crsId)
    {
        List<Instructor_Course>? students_Instructors_Course = _instructor_CourseRepo.GetRateByCrsId(crsId);
        if (students_Instructors_Course == null)
        {
            return null;
        }
        List<Instructor_CourseReadDto> Students_Instructors_CourseReadDtos = students_Instructors_Course.Select(inst_crs => new Instructor_CourseReadDto
        {
            StudentName = inst_crs.Student!.Name,
            InstructorName = inst_crs.Instructor!.Name,
            CourseName = inst_crs.Course!.Name,
            Rate = inst_crs.Rate,
        }).ToList();
        return Students_Instructors_CourseReadDtos;
    }

    public List<Instructor_CourseReadDto>? GetRatesByStdId(int stdId)
    {
        List<Instructor_Course>? student_Instructors_Courses = _instructor_CourseRepo.GetRateByStdId(stdId);
        if (student_Instructors_Courses == null)
        {
            return null;
        }
        List<Instructor_CourseReadDto> Student_Instructors_CoursesReadDtos = student_Instructors_Courses.Select(inst_crs => new Instructor_CourseReadDto
        {
            StudentName = inst_crs.Student!.Name,
            InstructorName = inst_crs.Instructor!.Name,
            CourseName = inst_crs.Course!.Name,
            Rate = inst_crs.Rate,
        }).ToList();
        return Student_Instructors_CoursesReadDtos;
    }
}
