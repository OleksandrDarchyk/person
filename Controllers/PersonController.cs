using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ph.DTOs;
using ph.Service;

namespace ph.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PersonController: ControllerBase

{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        Console.WriteLine("PersonController");// конструктор контролера, отримує сервіс із DI
        _service = service;
        
    }
    
    [HttpPost(nameof(CreatePerson))]// POST-запит, шлях береться з назви методу ("CreatePerson")
    
    public Person CreatePerson([FromBody] CreateOrUpdatePersonRequestDto dto)
    {
       
        return _service.CreatePerson(dto);
    }

    
    [HttpPut (nameof(UpdatePerson))]
 
    public Person UpdatePerson(
        [FromQuery] string id,
        [FromBody] CreateOrUpdatePersonRequestDto dto
        )
    {
      return _service.UpdatePerson(id, dto);
    }
    
    [HttpDelete (nameof(DeletePerson))]
    public Person DeletePerson(string id)
    {
       return _service.DeletePerson(id);
        
    }

 
}





   
   
   
