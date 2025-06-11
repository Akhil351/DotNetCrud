using crud.Data;
using Crud.Exceptions;
using crud.Model;
using Microsoft.EntityFrameworkCore;

namespace crud.Service;
public class StudentService(Db context) : IStudentService

{
    private readonly Db _context=context;
    public async Task<IList<Student>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> GetById(long id)
    {
        var student=await _context.Students.FindAsync(id);
        if (student == null)
        {
            throw new NotFoundException("student details not found");
        }

        return student;
    }



    public async Task<Student> Add(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<string> Update(long id, Student student)
    {
        var existingStudent= await _context.Students.FindAsync(id);
        if (existingStudent == null)
        {
            throw new NotFoundException("student details not found");
        }
        existingStudent.Name=student.Name;
        _context.Students.Update(existingStudent);
        await _context.SaveChangesAsync();
        return "student details updated";
    }

    public async Task<string> Delete(long id)
    {
        var existingStudent= await _context.Students.FindAsync(id);
        if (existingStudent == null)
        {
            throw new NotFoundException("student details not found");
        }
        _context.Students.Remove(existingStudent);
        await _context.SaveChangesAsync();
        return "student Details Deleted";
    }
}