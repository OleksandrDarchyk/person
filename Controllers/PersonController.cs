using Microsoft.AspNetCore.Mvc;

namespace ph.Controllers;

public class PersonController: ControllerBase

{
        
    [HttpPost]
    [Route("/person")]
    public ActionResult GetPerson(Person person)
    {
        FakeDB.db.Add(person);
        return Ok( FakeDB.db);
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

   public Person()
   {
       
   }

   public Person(string name, int age)
   {
      Name=name;
      Age=age;
   }
   
   
}