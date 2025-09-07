using Microsoft.AspNetCore.Mvc;

namespace ph.Controllers;

public class PersonController: ControllerBase

{
    
    [HttpPut]
    [Route("/person/{id}")]
    public Person UpdatePerson([FromRoute] int id, [FromBody] Person person)
    {
        var existigPerson = FakeDB.db.First(p => p.Id == id);
        existigPerson.Name = person.Name;
        return existigPerson;
    }
    
    [HttpGet]
    [Route ("api/person")]
    public List<Person> GetPersons()
    {
        return FakeDB.db.ToList();
    }

   
        


    [HttpPost]
    [Route("/person")]
    public ActionResult GetPerson(Person person)
    {
        FakeDB.db.Add(person);
        return Ok( FakeDB.db);
    }

    public Person DeletePerson([FromRoute] int id)
    {
        var person = FakeDB.db.First(p => p.Id == id);
        FakeDB.db.Remove(person);
        return person;
        
    }
}
public static class FakeDB
{
    public static List<Person> db = new List<Person>();
}




public class Person
{
   public string Name{get;set;}
   public int Age{get;set;}
   
   public int Id{get;set;}

   public Person()
   {
       
   }

   public Person(string name, int age,int id)
   { 
       Id = id;
      Name=name;
      Age=age;
   }
   
   
   
   
   
   
}