namespace ph;


public class FakeDB
{
    public  List<Person> AllPerson { get; set; } = new List<Person>();
}


public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public string Id { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public Person()
    {

    }

    public Person(string name, int age, string id)
    {
        Id = id;
        Name = name;
        Age = age;
        CreatedAt = DateTime.UtcNow;
    }
    
   

}

public class  PersonResponseDto
{
    public string PersonName { get; set; }
    public int PersonAge { get; set; }
    public string PersonId { get; set; }
    public DateTime CreatedAt { get; set; }

    public PersonResponseDto(Person person)
    {
        PersonName = person.Name;
        PersonAge = person.Age;
        PersonId = person.Id;
        CreatedAt = person.CreatedAt;
    }
}