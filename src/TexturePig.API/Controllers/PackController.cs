using Microsoft.AspNetCore.Mvc;

[ApiController]
public class Pack : ControllerBase
{
    [HttpGet("pack/home")]
    public ActionResult<IEnumerable<Person>> GetAll()
    {
        return new[]
        {
            new Person { Name = "Ana" },
            new Person { Name = "Felipe" },
            new Person { Name = "Emillia" }
        };
    }
}

public class Person
{
    public string Name { get; set; }
}