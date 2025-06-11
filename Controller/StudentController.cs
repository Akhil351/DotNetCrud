using Crud.Exceptions;
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
        try
        {
            var list = await _toDoService.GetAll();

            var response = new ApiResponse()
            {
                Data = list,
                Status = "Success",
                TimeStamp = DateTime.Now
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = "An internal error occured",
            };
            return NotFound(response);
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var item = await _toDoService.GetById(id);
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Data = item,
            };
            return Ok(response);
        }
        catch (NotFoundException e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = e.Message,
            };
            return NotFound(response);
        }
        catch (Exception e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = "An internal error occured",
            };
            return NotFound(response);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Student student)
    {
        try
        {
            var created = await _toDoService.Add(student);
            var response = new ApiResponse()
            {
                Data = created,
                Status = "Success",
                TimeStamp = DateTime.Now 
            };
            return Ok(response);
        }
        catch (Exception e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = "An internal error occured",
            };
            return NotFound(response);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student student)
    {
        try
        {
            var existingStudent = await _toDoService.Update(id, student);
            var response = new ApiResponse()
            {
                Data = existingStudent,
                Status = "Success",
                TimeStamp = DateTime.Now
            };
            return Ok(response);
        }
        catch (NotFoundException e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = e.Message,
            };
            return NotFound(response);
        }
        catch (Exception e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = "An internal error occured",
            };
            return NotFound(response);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var deleteStudent=await _toDoService.Delete(id);
            var response = new ApiResponse()
            {
                Data = deleteStudent,
                Status = "Success",
                TimeStamp = DateTime.Now 
            };
            return Ok(response);
        }
        catch (NotFoundException e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = e.Message,
            };
            return NotFound(response);
        }
        catch (Exception e)
        {
            var response = new ApiResponse
            {
                Status = "Success",
                TimeStamp = DateTime.Now,
                Error = "An internal error occured",
            };
            return NotFound(response);
        }
    }
    
}