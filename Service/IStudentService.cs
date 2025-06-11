using crud.Model;

namespace crud.Service;

public interface IStudentService
{
    Task<IList<Student>>  GetAll();
    Task<Student> GetById(long id);
    Task<Student> Add(Student item);
    Task<string> Update(long id,Student item);
    Task<string> Delete(long id);
}