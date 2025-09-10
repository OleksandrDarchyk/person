using System.ComponentModel.DataAnnotations;
using ph.DTOs;

namespace ph.Service;

public interface IPersonService
{
    Person CreatePerson(CreateOrUpdatePersonRequestDto dto);
    Person UpdatePerson(string id, CreateOrUpdatePersonRequestDto dto);
    Person DeletePerson(string id);
    List<PersonResponseDto> GetAllPersons();
    
}

public class PersonServise : IPersonService


{
    private readonly FakeDB _db;

    public PersonServise(FakeDB db)
    {
        Console.WriteLine("This is exepler of (PersonServise)");
        _db = db;
    }

    public Person CreatePerson(CreateOrUpdatePersonRequestDto dto)
    {
        Validator.ValidateObject(//перевіряємо обєкт на відповідність 
            dto ,new ValidationContext(dto),
            true
            );

        var person = new Person()
        {
            Name = dto.Name,
            Age = dto.Age,
            CreatedAt = DateTime.Now,
            Id = Guid.NewGuid().ToString()
        };
        
        _db.AllPerson.Add(person);
        return person;
    }

   public Person UpdatePerson(string id, CreateOrUpdatePersonRequestDto dto)
    {
        var existPerson = _db.AllPerson.First(p => p.Id == id);
        existPerson.Name = dto.Name;
        existPerson.Age = dto.Age;
        
        return existPerson;
    }

  public  Person DeletePerson(string id)
    {
        var existPerson = _db.AllPerson.First(p => p.Id == id);
        if (existPerson == null)
        {
            throw new KeyNotFoundException("Person not found");
        }
        var success = _db.AllPerson.Remove(existPerson);
        if (!success)
        {
            throw new KeyNotFoundException("Person not found");
        }
        return existPerson;
    }
    
    

    public List<PersonResponseDto> GetAllPersons()//те що отримуємо з сервера
    {
        
            return _db.AllPerson
                .Select(p=>new PersonResponseDto(p))
                .ToList();
    }
    
    
   
}