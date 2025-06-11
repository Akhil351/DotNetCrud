using Microsoft.AspNetCore.Mvc;
using crud.Model;
using crud.Response;
using crud.Service;

namespace crud.Controller;

[ApiController]
[Route("api/[controller]")]
public class StudentController(IStudentService toDoService) : ControllerBase
{
    
    private readonly IStudentService _toDoService=toDoService;
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await _toDoService.GetAll();

        var response = new ApiResponse()
        {
            Data = list,
            Status = "Success",
            Error = null,
            TimeStamp = DateTime.Now 
        };

        return Ok(response);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _toDoService.GetById(id);
        var response = new ApiResponse
        {
            Status = "Success",
            TimeStamp = DateTime.Now 
        };
        if (item == null)
        {
            response.Data = null;
            response.Error="Student not found";
            return NotFound(response);
        }
        response.Data = item;
        response.Error=null;
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        var created = await _toDoService.Add(student);
        var response = new ApiResponse()
        {
            Data = created,
            Status = "Success",
            Error = null,
            TimeStamp = DateTime.Now 
        };
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student student)
    {
        var existingStudent=await _toDoService.Update(id,student);
        var response = new ApiResponse()
        {
            Data = existingStudent,
            Status = "Success",
            Error = null,
            TimeStamp = DateTime.Now 
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleteStudent=await _toDoService.Delete(id);
        var response = new ApiResponse()
        {
            Data = deleteStudent,
            Status = "Success",
            Error = null,
            TimeStamp = DateTime.Now 
        };
        return Ok(response);
    }
    
}